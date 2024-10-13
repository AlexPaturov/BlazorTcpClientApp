// Services/CommandService.cs
namespace BlazorTcpClientApp.Services
{
    public class CommandService : BackgroundService
    {
        private readonly TcpClientService _tcpClientService;
        private readonly ILogger<CommandService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public CommandService(TcpClientService tcpClientService, ILogger<CommandService> logger, IServiceProvider serviceProvider)
        {
            _tcpClientService = tcpClientService;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("CommandService is starting.");

            // Register a callback for cancellation
            stoppingToken.Register(() => _logger.LogInformation("CommandService cancellation requested."));

            // Connect to the TCP server
            try
            {
                bool connected = await _tcpClientService.ConnectAsync("127.0.0.1", 8887, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10));
                if (connected)
                {
                    _logger.LogInformation("CommandService connected to TCP server.");

                    // Start receiving data
                    _ = _tcpClientService.ReceiveDataAsync(OnDataReceived, stoppingToken);

                    // Send the "PING" command once
                    string command = "<Request method='getPcName'/>";
                    try
                    {
                        await _tcpClientService.SendCommandAsync(command);
                        _logger.LogInformation($"Sent command: {command}");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error sending command: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to connect or send command: {ex.Message}");
            }

            _logger.LogInformation("CommandService has completed its execution.");
        }

        /// <summary>
        /// Callback method invoked when data is received from the TCP server.
        /// </summary>
        private async Task OnDataReceived(string data)
        {
            _logger.LogInformation($"CommandService received data: {data}");

            // Create a new scope to retrieve scoped services
            using (var scope = _serviceProvider.CreateScope())
            {
                var userService = scope.ServiceProvider.GetRequiredService<UserService>();
                await userService.UpdatePcNameFromServiceAsync(data);
            }
        }

        public override Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("CommandService is stopping.");
            return base.StopAsync(stoppingToken);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
