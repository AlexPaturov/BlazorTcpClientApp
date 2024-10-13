
namespace BlazorTcpClientApp.Services
{
    public class UserServiceTwo : IUserService
    {
        private UserModel _user;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public UserServiceTwo()
        {
            _user = new UserModel
            {
                //Id = 0,
                //PcName = string.Empty
            };
        }

        public async Task<UserModel> GetUserModelAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task GetPcNameAsync(string pcName)
        {
            await _semaphore.WaitAsync();
            try
            {
                //_user.PcName = pcName;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task UpdatePcNameFromServiceAsync(string data)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.ReceivedData = data;
                //_user.LastUpdated = DateTime.UtcNow;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task UpdateUserModelAsync(UserModel updatedUser)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user = updatedUser;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
