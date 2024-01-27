using SheepManager.Core.DTO.Sheeps;

namespace SheepManager.Core.Services_Contracts.Sheeps
{
    public interface ISheepsAdderService
    {
        #region Methods

        public Task<SheepResponse> AddSheep(SheepAddRequest sheepAddRequest);

        #endregion
    }
}
