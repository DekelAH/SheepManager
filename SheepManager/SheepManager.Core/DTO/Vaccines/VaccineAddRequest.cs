using SheepManager.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.DTO.Vaccines
{
    public class VaccineAddRequest
    {
        #region Properties

        public string? VaccineName { get; set; }

        [Required(ErrorMessage = "Birthdate can't be blank")]
        public DateTime VaccinationDate { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsForBirth { get; set; }

        [Required(ErrorMessage = "Tag Number can't be blank")]
        [Range(0, int.MaxValue, ErrorMessage = "Weight can't be lower than 0")]
        public int SheepTagNumber { get; set; }

        #endregion

        #region Methods

        public Vaccine ToVaccine()
        {
            return new Vaccine()
            {
                VaccineName = VaccineName,
                VaccinationDate = VaccinationDate,
                IsMandatory = IsMandatory,
                IsForBirth = IsForBirth,
                SheepTagNumber = SheepTagNumber
            };
        }

        #endregion
    }
}
