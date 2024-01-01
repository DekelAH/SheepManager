using SheepManager.Core.Domain.Entities;

namespace SheepManager.Core.Domain.Repository_Contracts
{
    public interface ISheepsRepository
    {
        #region Methods

        Task<List<Sheep>> GetAllSheeps();
        Task<Sheep?> GetSheepById(Guid id);
        Task<Sheep> AddNewSheep(Sheep newSheep);
        Task<Sheep> UpdateSheep(Sheep sheepToUpdate);
        Task<bool> DeleteSheepById(Guid id);

        #endregion
    }
}
