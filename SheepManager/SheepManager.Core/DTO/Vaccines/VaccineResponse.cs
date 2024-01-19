using SheepManager.Core.Domain.Entities;
using SheepManager.Core.DTO.Sheeps;

namespace SheepManager.Core.DTO.Vaccines
{
    public class VaccineResponse
    {
        #region Properties

        public Guid VaccineId { get; set; }
        public string? VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsForBirth { get; set; }
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

    public static class VaccineExtensionMethods
    {
        public static VaccineResponse ToVaccineResponse(this Vaccine vaccine)
        {
            return new VaccineResponse()
            {
                VaccineId = vaccine.VaccineId,
                VaccineName = vaccine.VaccineName,
                VaccinationDate = vaccine.VaccinationDate,
                IsMandatory = vaccine.IsMandatory,
                IsForBirth = vaccine.IsForBirth,
                SheepTagNumber = vaccine.SheepTagNumber
            };
        }
    }
}
