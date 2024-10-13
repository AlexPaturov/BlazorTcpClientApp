// Services/TcpClientService.cs
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BlazorTcpClientApp.Services
{
    public class TcpClientService : IDisposable
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private readonly ILogger<TcpClientService> _logger;
        private readonly byte[] _buffer;
        private bool _isConnected = false;

        // Property to expose connection status
        public bool IsConnected => _isConnected;

        public TcpClientService(ILogger<TcpClientService> logger, int bufferSize = 4096)
        {
            _logger = logger;
            _buffer = new byte[bufferSize];
        }

        /// <summary>
        /// Connects to the specified IP and port asynchronously.
        /// </summary>
        public async Task<bool> ConnectAsync(string ip, int port, TimeSpan sendTimeout, TimeSpan receiveTimeout)
        {
            try
            {
                _client = new TcpClient();
                _client.NoDelay = true;
                _client.SendTimeout = (int)sendTimeout.TotalMilliseconds;
                _client.ReceiveTimeout = (int)receiveTimeout.TotalMilliseconds;
                _client.ReceiveBufferSize = _buffer.Length;

                _logger.LogInformation($"Attempting to connect to {ip}:{port}...");
                await _client.ConnectAsync(ip, port);
                _stream = _client.GetStream();
                _isConnected = true;

                _logger.LogInformation($"Connected to {ip}:{port}.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Connection failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Sends a command to the connected server asynchronously.
        /// </summary>
        public async Task SendCommandAsync(string command)
        {
            if (_stream == null || !_client.Connected)
                throw new InvalidOperationException("Not connected to the server.");

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(command);
                await _stream.WriteAsync(data, 0, data.Length);
                _logger.LogInformation($"Sent command: {command}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending command: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Receives data from the server asynchronously and invokes the callback with the received data.
        /// </summary>
        public async Task ReceiveDataAsync(Func<string, Task> onDataReceived, CancellationToken token)
        {
            try
            {
                _logger.LogInformation("Started receiving data...");
                while (!token.IsCancellationRequested && _client.Connected)
                {
                    if (_stream.DataAvailable)
                    {
                        int bytesRead = await _stream.ReadAsync(_buffer, 0, _buffer.Length, token);
                        if (bytesRead > 0)
                        {
                            string receivedText = Encoding.UTF8.GetString(_buffer, 0, bytesRead);
                            _logger.LogInformation($"Received {bytesRead} bytes: {receivedText}");
                            await onDataReceived(receivedText);
                        }
                    }
                    else
                    {
                        await Task.Delay(100, token); // Adjust delay as needed
                    }
                }
                _logger.LogInformation("Stopped receiving data.");
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Data reception canceled.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Data receiving error: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Disposes the TcpClient and NetworkStream.
        /// </summary>
        public void Dispose()
        {
            try
            {
                _stream?.Close();
                _client?.Close();
                _isConnected = false;
                _logger.LogInformation("TcpClientService disposed.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during disposal: {ex.Message}");
            }
        }
    }
}
