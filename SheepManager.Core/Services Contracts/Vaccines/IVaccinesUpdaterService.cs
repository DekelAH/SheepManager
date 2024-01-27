using SheepManager.Core.DTO.Vaccines;

namespace SheepManager.Core.Services_Contracts.Vaccines
{
    public interface IVaccinesUpdaterService
    {
        #region Methods

        public Task<VaccineResponse> UpdateVaccine(VaccineUpdateRequest vaccineUpdateRequest);

        #endregion
    }
}
