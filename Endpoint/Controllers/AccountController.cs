using Endpoint.Models.Data;
using Endpoint.Models.Requests;
using Endpoint.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<ApiUser> userManager, IAuthManager authManager)
        {
            this._userManager = userManager;
            this._authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO userDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = new ApiUser() {
                    Email = userDTO.Email,
                    UserName = userDTO.Email,
                };
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if(!result.Succeeded)
                {
                    return BadRequest("$User Registration Attempt Failed: " + result.Errors.First().Description);
                }

                await _userManager.AddToRoleAsync(user, "MANAGER");
                return Accepted();
            }
            catch(Exception ex)
            {
                return Problem($"Something Wnt wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if(!await _authManager.ValidateUser(loginDTO))
                {
                    return Unauthorized();
                }

                return Accepted(new { Token = await _authManager.CreateToken() });
            }
            catch (Exception ex)
            {
                return Problem($"Something Wnt wrong in the {nameof(Login)}", statusCode: 500);
            }
        }
    }
}
