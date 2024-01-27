using SheepManager.Core.DTO.Herds;

namespace SheepManager.Core.Services_Contracts.Herds
{
    public interface IHerdsGetterService
    {
        #region Methods

        public Task<List<HerdResponse>?> GetAllHerds();
        public Task<HerdResponse?> GetHerdById(Guid herdId);

        #endregion
    }
}
