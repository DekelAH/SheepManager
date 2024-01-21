using SheepManager.Core.Domain.Entities;

namespace SheepManager.Core.Domain.Repository_Contracts
{
    public interface ISheepsRepository
    {
        #region Methods

        Task<List<Sheep>> GetAllSheeps();
        Task<List<Sheep>> GetAllMales();
        Task<List<Sheep>> GetAllFemales();
        Task<Sheep?> GetSheepById(Guid id);
        Task<Sheep> AddNewSheep(Sheep newSheep);
        Task<Sheep> UpdateSheep(Sheep sheepToUpdate);

        #endregion
    }
}
