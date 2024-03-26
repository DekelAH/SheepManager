using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SheepManager.Core.Domain.IdentityEntities;
using SheepManager.Core.DTO.Account;

namespace SheepManager.WebAPI.Controllers
{
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

        [HttpPost]
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

            IdentityResult result = await _userManager.CreateAsync(user);
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

    }
}
