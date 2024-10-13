// Services/UserService.cs
using System.ComponentModel.DataAnnotations;

namespace BlazorTcpClientApp.Services
{
    public class UserService
    {
        private UserModel _user;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly XmlDecodeService _xmlDecodeService;

        public UserService(XmlDecodeService xmlDecodeService)
        {
            _xmlDecodeService = xmlDecodeService;   

            _user = new UserModel
            {
      
                UserName = string.Empty,
                DisplayName = string.Empty,
                PCName  = string.Empty,
                ID = string.Empty,
                IsGdWeighter = false,
                Vesy = "0",
                IsPcGdWeight = false,
                IsPcChugunWeight = false,
                IsPcVesySix = false,
                IsUserAvtoWeighterGroup = false,
                IsUserShiftForeman = false,
                IsUserAVG = false,
                IsUserCanSeeAvtoWeighting = false,
                IsPCAvtoWeighterGroup = false,
                WasCheckedUserRight = false,
                IsError = false,
                ErrorText = string.Empty,
                ReceivedData = string.Empty
            };
        }

        #region UpdateUserNameAsync(string domainName)
        public async Task UpdateUserNameAsync(string domainName)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.UserName = domainName;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetUserNameAsync()
        public async Task<string> GetUserNameAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.UserName;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateDisplayNameAsync(string dispNam)
        public async Task UpdateDisplayNameAsync(string dispNam)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.DisplayName = dispNam;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetDisplayNameAsync()
        public async Task<string> GetDisplayNameAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.DisplayName;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetIDAsync()
        public async Task<string> GetIDAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.ID;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateIDAsync(string usrId)
        public async Task UpdateIDAsync(string usrId)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.ID = usrId;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateIsGdWeighterAsync(bool isGdWeighter)
        public async Task UpdateIsGdWeighterAsync(bool isGdWeighter)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.IsGdWeighter = isGdWeighter;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetIsGdWeighterAsync()
        public async Task<bool> GetIsGdWeighterAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.IsGdWeighter;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateVesyAsync(string vesy)
        public async Task UpdateVesyAsync(string vesy)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.Vesy = vesy;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetVesyAsync()
        public async Task<string> GetVesyAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.Vesy;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateIsPcGdWeightAsync(bool isPcGdWeight)
        public async Task UpdateIsPcGdWeightAsync(bool isPcGdWeight)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.IsPcGdWeight = isPcGdWeight;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetIsPcGdWeightAsync()
        public async Task<bool> GetIsPcGdWeightAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.IsPcGdWeight;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateIsPcChugunWeightAsync(bool isPcChugunWeight)
        public async Task UpdateIsPcChugunWeightAsync(bool isPcChugunWeight)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.IsPcChugunWeight = isPcChugunWeight;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetIsPcChugunWeightAsync()
        public async Task<bool> GetIsPcChugunWeightAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.IsPcChugunWeight;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateIsPcVesySixAsync(bool isPcVesySix)
        public async Task UpdateIsPcVesySixAsync(bool isPcVesySix)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.IsPcVesySix = isPcVesySix;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetIsPcVesySixAsync()
        public async Task<bool> GetIsPcVesySixAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.IsPcVesySix;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateIsUserAvtoWeighterGroupAsync(bool isUserAvtoWeighterGroup)
        public async Task UpdateIsUserAvtoWeighterGroupAsync(bool isUserAvtoWeighterGroup)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.IsUserAvtoWeighterGroup = isUserAvtoWeighterGroup;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetIsUserAvtoWeighterGroupAsync()
        public async Task<bool> GetIsUserAvtoWeighterGroupAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.IsUserAvtoWeighterGroup;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateIsUserShiftForemanAsync(bool isUserShiftForeman)
        public async Task UpdateIsUserShiftForemanAsync(bool isUserShiftForeman)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.IsUserShiftForeman = isUserShiftForeman;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetIsUserShiftForemanAsync()
        public async Task<bool> GetIsUserShiftForemanAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.IsUserShiftForeman;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateIsUserAVGAsync(bool isUserAVG)
        public async Task UpdateIsUserAVGAsync(bool isUserAVG)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.IsUserAVG = isUserAVG;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetIsUserAVGAsync()
        public async Task<bool> GetIsUserAVGAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.IsUserAVG;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateIsUserCanSeeAvtoWeightingAsync(bool isUserCanSeeAvtoWeighting)
        public async Task UpdateIsUserCanSeeAvtoWeightingAsync(bool isUserCanSeeAvtoWeighting)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.IsUserCanSeeAvtoWeighting = isUserCanSeeAvtoWeighting;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetIsUserCanSeeAvtoWeightingAsync()
        public async Task<bool> GetIsUserCanSeeAvtoWeightingAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.IsUserCanSeeAvtoWeighting;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateIsPCAvtoWeighterGroupAsync(bool isPCAvtoWeighterGroup)
        public async Task UpdateIsPCAvtoWeighterGroupAsync(bool isPCAvtoWeighterGroup)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.IsPCAvtoWeighterGroup = isPCAvtoWeighterGroup;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetIsPCAvtoWeighterGroupAsync()
        public async Task<bool> GetIsPCAvtoWeighterGroupAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.IsPCAvtoWeighterGroup;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateWasCheckedUserRightAsync(bool wasCheckedUserRight)
        public async Task UpdateWasCheckedUserRightAsync(bool wasCheckedUserRight)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.WasCheckedUserRight = wasCheckedUserRight;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetWasCheckedUserRightAsync()
        public async Task<bool> GetWasCheckedUserRightAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.WasCheckedUserRight;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateIsErrorAsync(bool isError)
        public async Task UpdateIsErrorAsync(bool isError)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.IsError = isError;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetIsErrorAsync()
        public async Task<bool> GetIsErrorAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.IsError;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateErrorTextAsync(string errorText)
        public async Task UpdateErrorTextAsync(string errorText)
        {
            await _semaphore.WaitAsync();
            try
            {
                _user.ErrorText = errorText;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region GetErrorTextAsync()
        public async Task<string> GetErrorTextAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _user.ErrorText;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region UpdateUserModelAsync(UserModel updatedUser)
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
        #endregion
        #region Task<UserModel> GetUserModelAsync()
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
        #endregion
        #region UpdatePcNameFromServiceAsync(string rawXMLdata)
        public async Task UpdatePcNameFromServiceAsync(string rawXMLdata)
        {
            await _semaphore.WaitAsync();
            try
            {
                _xmlDecodeService.SetUserPcName(rawXMLdata, _user);
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
        #region Task<string> GetPcNameAsync()
        public async Task<string> GetPcNameAsync()
        {
            await _semaphore.WaitAsync();
            try
            {

                return _user.PCName;
            }
            finally
            {
                _semaphore.Release();
            }
        }
        #endregion
   
    }
}
