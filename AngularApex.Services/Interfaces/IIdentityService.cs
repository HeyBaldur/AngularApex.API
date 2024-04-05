using AngularApex.Data.Data;
using AngularApex.Data.DTOs;
using AngularApex.Data.Models;
using System.Threading.Tasks;

namespace AngularApex.Services.Interfaces
{
    public interface IIdentityService
    {
        /// <summary>
        /// Register a user in the DB.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserAccountDto> RegisterUserAsync(RegisterUserModelRequest model);

        /// <summary>
        /// Log in a user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<TokenDto> LoginUserAsync(LoginUserModel model);
    }
}