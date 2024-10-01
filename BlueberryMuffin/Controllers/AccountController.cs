using BlueberryMuffin.Contracts;
using BlueberryMuffin.Data;
using BlueberryMuffin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlueberryMuffin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AccountController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        // POST: api/Account/register
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] AccountDetails userDetails)
        {
            var errors = await _authManager.Register(userDetails);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // POST: api/Account/register
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginDetails userDetails)
        {
            var authResponse = await _authManager.Login(userDetails);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }

        // POST: api/Account/refreshToken
        [HttpPost]
        [Route("refreshToken")]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponse request)
        {
            var authResponse = await _authManager.VerifyRefreshToken(request);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }
    }
}
