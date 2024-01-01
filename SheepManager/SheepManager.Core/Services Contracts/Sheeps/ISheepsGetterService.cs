using SheepManager.Core.DTO.Sheeps;

namespace SheepManager.Core.Services_Contracts.Sheeps
{
    public interface ISheepsGetterService
    {
        #region Methods

        public Task<List<SheepResponse>?> GetAllSheeps();
        public Task<SheepResponse?> GetSheepById(Guid id);

        #endregion
    }
}
