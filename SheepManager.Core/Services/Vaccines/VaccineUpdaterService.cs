using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Core.DTO.Sheeps;
using SheepManager.Core.DTO.Vaccines;
using SheepManager.Core.Services_Contracts.Vaccines;

namespace SheepManager.Core.Services.Vaccines
{
    public class VaccineUpdaterService : IVaccinesUpdaterService
    {
        #region Fields

        private readonly IVaccinesRepository _vaccinesRepository;

        #endregion

        #region Ctor

        public VaccineUpdaterService(IVaccinesRepository vaccinesRepository)
        {
            _vaccinesRepository = vaccinesRepository;
        }

        #endregion

        #region Methods

        public async Task<VaccineResponse> UpdateVaccine(VaccineUpdateRequest vaccineUpdateRequest)
        {
            var vaccine = vaccineUpdateRequest.ToVaccine();
            var updatedVaccine = await _vaccinesRepository.UpdateVaccine(vaccine);
            var vaccineResponse = updatedVaccine.ToVaccineResponse();
            vaccineResponse.VaccineId = vaccineUpdateRequest.VaccineId;
            return vaccineResponse;
        }

        #endregion
    }
}
