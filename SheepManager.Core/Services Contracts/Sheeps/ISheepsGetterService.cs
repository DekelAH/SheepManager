using SheepManager.Core.DTO.Sheeps;

namespace SheepManager.Core.Services_Contracts.Sheeps
{
    public interface ISheepsGetterService
    {
        #region Methods

        public Task<List<SheepResponse>?> GetAllSheeps();
        public Task<List<SheepResponse>?> GetAllMales();
        public Task<List<SheepResponse>?> GetAllFemales();
        public Task<SheepResponse?> GetSheepById(Guid id);
        public Task<List<SheepResponse>?> GetSheepsByHerdId(Guid herdId);

        #endregion
    }
}
