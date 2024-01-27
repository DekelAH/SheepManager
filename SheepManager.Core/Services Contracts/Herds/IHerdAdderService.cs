using SheepManager.Core.DTO.Herds;

namespace SheepManager.Core.Services_Contracts.Herds
{
    public interface IHerdAdderService
    {
        #region Methods

        public Task<HerdResponse> AddHerd(HerdAddRequest herdAddRequest);

        #endregion
    }
}
