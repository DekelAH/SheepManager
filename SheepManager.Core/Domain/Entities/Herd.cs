using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.Domain.Entities
{
    public class Herd
    {
        #region Properties

        [Key]
        public Guid HerdId { get; set; }
        public string? HerdName { get; set; }

        #endregion
    }
}
