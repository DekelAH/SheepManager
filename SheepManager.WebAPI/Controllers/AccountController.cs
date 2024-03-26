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

        #endregion

        #region Ctor

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
                return Ok("User Registered Successfully");
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
