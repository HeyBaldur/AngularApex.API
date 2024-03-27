using AngularApex.Data.Data;
using AngularApex.Data.Models;
using AngularApex.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace AngularApex.API.Controllers
{
    /// <summary>
    /// User authentication controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="identityService"></param>
        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        /// <summary>
        /// Sign up
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [SwaggerOperation(
            Description = "Register a new user",
            Summary = "Create account")]
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _identityService.RegisterUserAsync(model);
                return Ok(result);
            }
        }

        /// <summary>
        /// Get access token.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [SwaggerOperation(
            Description = "Log in a new user",
            Summary = "Get access token")]
        [HttpPost("token")]
        public async Task<IActionResult> SignIn(LoginUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _identityService.LoginUserAsync(model);
                return Ok(result);
            }
        }
    }
}
