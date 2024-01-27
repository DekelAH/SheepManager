using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepManager.Core.Domain.Entities
{
    public class Birth
    {
        #region Properties

        public Guid BirthId { get; set; }
        public int SheepTagNumber { get; set; }
        public DateTime GivingBirthDate { get; set; }
        public int BornQuantity { get; set; }
        public bool IsDroped { get; set; }
        public int DescendantMortality { get; set; }

        #endregion
    }
}
