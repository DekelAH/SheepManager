using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.Domain.Entities
{
    public class Match
    {
        #region Properties

        [Key]
        public Guid MatchId { get; set; }
        public int MaleTagNumber { get; set; }
        public int FemaleTagNumber { get; set; }

        #endregion

    }
}
