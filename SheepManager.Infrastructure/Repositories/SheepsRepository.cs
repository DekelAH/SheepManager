using SheepManager.Core.Domain.Entities;
using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Infrastructure.DatabaseContext;

namespace SheepManager.Infrastructure.Repositories
{
    public class SheepsRepository : ISheepsRepository
    {
        #region Fields

        private readonly SheepManagerDbContext _sheepManagerDbContext;

        #endregion

        #region Ctor

        public SheepsRepository(SheepManagerDbContext sheepManagerDbContext)
        {
            _sheepManagerDbContext = sheepManagerDbContext;
        }

        #endregion

        #region Methods

        public Task<List<Sheep>> GetAllSheeps()
        {
            return Task.FromResult(_sheepManagerDbContext.Sp_GetAllSheeps());
        }

        public Task<List<Sheep>> GetAllMales()
        {
            return Task.FromResult(_sheepManagerDbContext.Sp_GetAllMales());
        }

        public Task<List<Sheep>> GetAllFemales()
        {
            return Task.FromResult(_sheepManagerDbContext.Sp_GetAllFemales());
        }

        public Task<Sheep?> GetSheepById(Guid id)
        {
            var sheep = _sheepManagerDbContext.Sp_GetSheepById(id);
            return Task.FromResult(sheep);
        }

        public Task<Sheep> AddNewSheep(Sheep newSheep)
        {
            _sheepManagerDbContext.Sp_AddSheep(newSheep);
            return Task.FromResult(newSheep);
        }

        public Task<Sheep> UpdateSheep(Sheep sheepToUpdate)
        {
            _sheepManagerDbContext.Sp_UpdateSheep(sheepToUpdate);
            return Task.FromResult(sheepToUpdate);
        }

        #endregion
    }
}
