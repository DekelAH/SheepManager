using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.DTO.Account
{
    public class LoginRequest
    {
        #region Properties

        [Required(ErrorMessage = "Email cant be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper format")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password cant be blank")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        #endregion
    }
}
