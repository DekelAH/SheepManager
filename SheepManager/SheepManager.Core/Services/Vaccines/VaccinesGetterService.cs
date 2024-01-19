using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Core.DTO.Vaccines;
using SheepManager.Core.Services_Contracts.Vaccines;

namespace SheepManager.Core.Services.Vaccines
{
    public class VaccinesGetterService : IVaccinesGetterService
    {
        #region Fields

        private readonly IVaccinesRepository _vaccinesRepository;

        #endregion

        #region Ctor

        public VaccinesGetterService(IVaccinesRepository vaccinesRepository)
        {
            _vaccinesRepository = vaccinesRepository;
        }

        #endregion

        #region Methods

        public async Task<List<VaccineResponse>> GetAllVaccines()
        {
            var allVaccines = await _vaccinesRepository.GetAllVaccines();
            if (allVaccines.Count <= 0)
            {
                throw new NullReferenceException(nameof(allVaccines));
            }

            var allVaccinesResponse = allVaccines.Select(v => v.ToVaccineResponse()).ToList();
            return allVaccinesResponse;
        }

        public async Task<List<VaccineResponse>>? GetVaccinesByTagNumber(int tagNumber)
        {
            var matchingVaccinesByTagNumber = await _vaccinesRepository.GetVaccinesByTagNumber(tagNumber)!;
            if (matchingVaccinesByTagNumber.Count <= 0)
            {
                throw new NullReferenceException("No vaccines were found, check tag number input");
            }

            return matchingVaccinesByTagNumber.Select(v => v.ToVaccineResponse()).ToList();
        }

        #endregion

    }
}
