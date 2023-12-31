using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.Domain.Entities
{
    public class Sheep
    {
        #region Properties

        [Key]
        public Guid SheepId { get; set; }
        public int TagNumber { get; set; }
        public double Weight { get; set; }
        public string? Gender { get; set; }
        public string? Race { get; set; }
        public string? BloodType { get; set; }
        public string? Selection { get; set; }
        public DateTime Birthdate { get; set; }
        public int MotherTagNumber { get; set; }
        public int FatherTagNumber { get; set; }
        public bool IsDead { get; set; }
        public bool IsSold { get; set; }
        public bool IsPregnant { get; set; }
        public Guid BirthId { get; set; }
        public Guid VaccineId { get; set; }

        #endregion
    }
}
