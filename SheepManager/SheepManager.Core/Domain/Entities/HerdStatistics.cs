using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.Domain.Entities
{
    public class HerdStatistics
    {
        #region Properties

        [Key]
        public Guid HerdStatisticsId { get; set; }
        public uint SheepsTotal { get; set; }
        public uint MothersTotal { get; set; }
        public uint RamsTotal { get; set; }
        public uint NewBornTotal { get; set; }
        public uint NewBornMaleTotal { get; set; }
        public uint NewBornFemaleTotal { get; set; }
        public double FertilityAVG { get; set; }
        public Guid HerdId { get; set; }

        #endregion
    }
}
