using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.Domain.Entities
{
    public class Livestock
    {
        #region Properties

        [Key]
        public Guid LivestockId { get; set; }
        public Guid HerdId { get; set; }
        public Guid HerdStatisticsId { get; set; }

        #endregion
    }
}
