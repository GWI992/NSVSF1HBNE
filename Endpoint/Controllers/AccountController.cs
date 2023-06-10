using Endpoint.Models.Data;
using Endpoint.Models.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;

        public AccountController(UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
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
                    return BadRequest("$User Registration Attempt Failed:" + result.Errors.First().Description);
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
        public async Task<IActionResult> Login([FromBody] LoginDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, false);
                if(!result.Succeeded)
                {
                    return Unauthorized(result.ToString());
                }

                return Accepted();
            }
            catch (Exception ex)
            {
                return Problem($"Something Wnt wrong in the {nameof(Login)}", statusCode: 500);
            }
        }
    }
}
