using SheepManager.Core.DTO.Vaccines;

namespace SheepManager.Core.Services_Contracts.Vaccines
{
    public interface IVaccinesAdderService
    {
        #region Methods

        public Task<VaccineResponse> AddVaccine(VaccineAddRequest vaccineAddRequest);

        #endregion
    }
}
