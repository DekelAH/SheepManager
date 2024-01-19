using SheepManager.Core.DTO.Vaccines;

namespace SheepManager.Core.Services_Contracts.Vaccines
{
    public interface IVaccinesGetterService
    {
        #region Methods

        public Task<List<VaccineResponse>> GetAllVaccines();
        public Task<List<VaccineResponse>>? GetVaccinesByTagNumber(int tagNumber);

        #endregion
    }
}
