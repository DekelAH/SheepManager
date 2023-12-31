using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.Domain.Entities
{
    public class Vaccine
    {
        #region Properties

        [Key]
        public Guid VaccineId { get; set; }
        public string? VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsForBirth { get; set; }

        #endregion
    }
}
