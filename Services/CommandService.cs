namespace BlazorTcpClientApp.Services
{
    public class CommandService
    {
        private readonly TcpClientService _tcpClientService;
        private readonly ILogger<CommandService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly UserService _userService;

        public CommandService(TcpClientService tcpClientService, 
                              ILogger<CommandService> logger, 
                              IServiceProvider serviceProvider,
                              UserService userService)
        {
            _tcpClientService = tcpClientService;
            _logger = logger;
            _serviceProvider = serviceProvider;
            _userService = userService;
        }

        // мне кажется здесь нужно изменить логику вызова 1
        public async Task ExecuteAsync(CancellationToken stoppingToken = default)
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

                    string command = "<Request method='getPcName'/>";
                    try
                    {
                        await _tcpClientService.SendCommandAsync(command);
                        _logger.LogInformation($"Sent command: {command}");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error sending command: {ex.Message}");
                        await _userService.UpdateErrorTextAsync(ex.Message);
                        await _userService.UpdateIsErrorAsync(true);
                    }
                }
                else 
                {
                    await _userService.UpdateErrorTextAsync("CommandService : BackgroundService -> _tcpClientService.Connect -> false");
                    await _userService.UpdateIsErrorAsync(true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to connect or send command: {ex.Message}");
                // если не доступен IP адрес
                await _userService.UpdateErrorTextAsync(ex.Message);
                await _userService.UpdateIsErrorAsync(true);
            }
            _logger.LogInformation("CommandService has completed its execution.");
        }

        /// <summary>
        /// Callback method invoked when data is received from the TCP server.
        /// </summary>
        private async Task OnDataReceived(string data)
        {
            _logger.LogInformation($"CommandService received data: {data}");
            
            // Заменить на try catch !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            
            // Create a new scope to retrieve scoped services
            using (var scope = _serviceProvider.CreateScope())
            {
                var userService = scope.ServiceProvider.GetRequiredService<UserService>();
                await userService.UpdatePcNameFromServiceAsync(data);
            }
        }
    }
}
