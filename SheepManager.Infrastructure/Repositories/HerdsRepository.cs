using SheepManager.Core.Domain.Entities;
using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Infrastructure.DatabaseContext;

namespace SheepManager.Infrastructure.Repositories
{
    public class HerdsRepository : IHerdsRepository
    {
        #region Fields

        private readonly SheepManagerDbContext _sheepManagerDbContext;

        #endregion

        #region Ctor

        public HerdsRepository(SheepManagerDbContext sheepManagerDbContext)
        {
            _sheepManagerDbContext = sheepManagerDbContext;
        }

        #endregion

        #region Methods

        public Task<Herd> AddNewHerd(Herd newHerd)
        {
            _sheepManagerDbContext.Sp_AddHerd(newHerd);
            return Task.FromResult(new Herd());
        }

        public Task<List<Herd>> GetAllHerds()
        {
            return Task.FromResult(_sheepManagerDbContext.Sp_GetAllHerds().ToList());
        }

        public Task<Herd>? GetHerdById(Guid herdId)
        {
            var herd = _sheepManagerDbContext.Sp_GetHerdById(herdId);
            if (herd == null)
            {
                return null;
            }
            return Task.FromResult(herd);
        }

        #endregion
    }
}
