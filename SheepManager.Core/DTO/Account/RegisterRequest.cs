using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.DTO.Account
{
    public class RegisterRequest
    {
        #region Properties

        [Required(ErrorMessage = "Username cant be blank")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage = "Email cant be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password cant be blank")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword cant be blank")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        #endregion
    }
}
