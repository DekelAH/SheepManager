using Microsoft.AspNetCore.Identity;

namespace SheepManager.Core.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        #region Properties

        public string? PersonName { get; set; }

        #endregion
    }
}
