using AngularApex.Data.DTOs;
using AngularApex.Data.Models;
using AutoMapper;

namespace AngularApex.API.Utils
{
    /// <summary>
    /// Automapper
    /// </summary>
    public class AutoMapperProfiles : Profile
    {
        /// <summary>
        /// Automapper profiles
        /// </summary>
        public AutoMapperProfiles()
        {
            CreateMap<RegisterUserModel, UserAccountDto>().ReverseMap();
        }
    }
}
