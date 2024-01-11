using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.Domain.Entities
{
    public class Match
    {
        #region Properties

        [Key]
        public Guid MatchId { get; set; }
        public uint MaleTagNumber { get; set; }
        public uint FemaleTagNumber { get; set; }
        public Guid SheepId { get; set; }

        #endregion

    }
}
