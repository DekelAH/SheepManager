using SheepManager.Core.DTO.Herds;

namespace SheepManager.Core.Services_Contracts.Herds
{
    public interface IHerdUpdaterService
    {
        #region Methods

        public Task<HerdResponse> UpdateHerd(HerdUpdateRequest herdUpdateRequest);

        #endregion
    }
}
