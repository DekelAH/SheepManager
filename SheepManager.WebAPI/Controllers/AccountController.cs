using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SheepManager.Core.Domain.IdentityEntities;
using SheepManager.Core.DTO.Account;

namespace SheepManager.WebAPI.Controllers
{
    [AllowAnonymous]
    public class AccountController : CustomControllerBase
    {
        #region Fields

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        #endregion

        #region Ctor

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #endregion

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(error => error.ErrorMessage);
                return Problem(detail: $"Invalid register details: {errors}", statusCode: 401, title: "Register");
            }

            ApplicationUser user = new()
            {
                PersonName = registerRequest.PersonName,
                Email = registerRequest.Email,
                UserName = registerRequest.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok(user);
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }
            }

            return Problem(detail: $"Invalid register details", statusCode: 401, title: "Register");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(error => error.ErrorMessage);
                return Problem(detail: $"Invalid login details: {errors}", statusCode: 401, title: "Login");
            }

            var result = await _signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password,
                                                                  isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return Ok(true);
            }

            return Problem(detail: $"Invalid login details", statusCode: 401, title: "Login");
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(true);
        }

        public async Task<IActionResult> IsEmailAlreadyExist(string email)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }

    }
}
