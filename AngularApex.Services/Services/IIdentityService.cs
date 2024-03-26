using AngularApex.Data.DTOs;
using AngularApex.Data.Models;
using System.Threading.Tasks;

namespace AngularApex.Services.Services
{
    public interface IIdentityService
    {
        /// <summary>
        /// Register a user in the DB.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserAccountDto> RegisterUserAsync(RegisterUserModel model);
    }
}