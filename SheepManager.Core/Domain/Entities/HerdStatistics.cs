using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.Domain.Entities
{
    public class HerdStatistics
    {
        #region Properties

        [Key]
        public Guid HerdStatisticsId { get; set; }
        public int SheepsTotal { get; set; }
        public int MothersTotal { get; set; }
        public int RamsTotal { get; set; }
        public int NewBornTotal { get; set; }
        public int NewBornMaleTotal { get; set; }
        public int NewBornFemaleTotal { get; set; }
        public double FertilityAVG { get; set; }
        public Guid HerdId { get; set; }

        #endregion
    }
}
