using SheepManager.Core.DTO.Sheeps;

namespace SheepManager.Core.Services_Contracts.Sheeps
{
    public interface ISheepsUpdaterService
    {
        #region Methods

        public Task<SheepResponse> UpdateSheep(SheepUpdateRequest sheepUpdateRequest);

        #endregion
    }
}
