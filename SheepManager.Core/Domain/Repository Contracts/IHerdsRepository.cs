using SheepManager.Core.Domain.Entities;

namespace SheepManager.Core.Domain.Repository_Contracts
{
    public interface IHerdsRepository
    {
        #region Methods

        Task<List<Herd>> GetAllHerds();
        Task<Herd>? GetHerdById(Guid herdId);
        Task<Herd> AddNewHerd(Herd newHerd);

        #endregion
    }
}
