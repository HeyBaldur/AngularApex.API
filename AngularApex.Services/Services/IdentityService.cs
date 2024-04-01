using AngularApex.Data;
using AngularApex.Data.Data;
using AngularApex.Data.DTOs;
using AngularApex.Data.Models;
using AngularApex.Services.JWT;
using AngularApex.Services.PasswordHandler;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApex.Services.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly ILogger<IdentityService> _logger;
        private readonly ITokenHandler _tokenHandler;
        public IdentityService(
            IMapper mapper,
            DataContext dataContext,
            ILogger<IdentityService> logger,
            ITokenHandler tokenHandler)
        {
            _mapper = mapper;
            _dataContext = dataContext;
            _logger = logger;
            _tokenHandler = tokenHandler;
        }

        public async Task<TokenDto> LoginUserAsync(LoginUserModel model)
        {
            // Validate if user exists in the DB.
            RegisterUserModel user = await _dataContext.UserAccounts
                .Where(x => x.Email == model.Email)
                .FirstOrDefaultAsync();

            // Validate password
            if (!PasswordHash.VerifyPassword(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                _logger.LogError($"Could not get access token because credentials do not match");
                throw new Exception("Credentials do not match");
            }

            // Return token
            _logger.LogInformation("Generate access token");
            var token = _tokenHandler.GenerateToken(
                user.Id,
                user.Email);

            // Return token object
            return new TokenDto
            {
                Token = token,
            };
        }

        public async Task<UserAccountDto> RegisterUserAsync(RegisterUserModel model)
        {
            try
            {
                // Check if email already exists
                bool emailExists = await _dataContext.UserAccounts
                    .AnyAsync(x => x.Email == model.Email);

                if (emailExists)
                {
                    _logger.LogError($"User with the email {model.Email} already exists in the DB.");
                    return null;
                }

                // Hash the password
                PasswordHash.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
                model.PasswordHash = passwordHash;
                model.PasswordSalt = passwordSalt;
                model.Password = $"{passwordHash}/{passwordSalt}";

                // Save user account to database
                await _dataContext.UserAccounts.AddAsync(model);
                await _dataContext.SaveChangesAsync();

                // Map and return the user account DTO
                _logger.LogInformation($"User has been created.");
                return _mapper.Map<UserAccountDto>(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"System could not complete the request.");
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
