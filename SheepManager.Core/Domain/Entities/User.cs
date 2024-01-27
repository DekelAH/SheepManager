using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepManager.Core.Domain.Entities
{
    public class User
    {
        #region Peroperties

        public Guid UserId { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserEmail { get; set; }
        public Guid LivestockId { get; set; }

        #endregion
    }
}
