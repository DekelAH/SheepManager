using SheepManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepManager.Core.DTO.Vaccines
{
    public class VaccineUpdateRequest
    {
        #region Properties

        public Guid VaccineId { get; set; }
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
                VaccineId = VaccineId,
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
