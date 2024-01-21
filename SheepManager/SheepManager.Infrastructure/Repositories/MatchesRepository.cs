using SheepManager.Core.Domain.Entities;
using SheepManager.Core.Domain.MatchCreator;
using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Infrastructure.DatabaseContext;

namespace SheepManager.Infrastructure.Repositories
{
    public class MatchesRepository : IMatchesRepository
    {
        #region Fields

        private readonly SheepManagerDbContext _sheepManagerDbContext;

        #endregion

        #region Ctor

        public MatchesRepository(SheepManagerDbContext sheepManagerDbContext)
        {
            _sheepManagerDbContext = sheepManagerDbContext;
        }

        #endregion

        #region Methods

        public Task<List<Match>> GetAllMatches()
        {
            return Task.FromResult(_sheepManagerDbContext.Sp_GetAllMatches());
        }

        public Task<Match> AddNewMatch(Match newMatch)
        {
            _sheepManagerDbContext.Sp_AddMatch(newMatch);
            return Task.FromResult(newMatch);
        }

        #endregion
    }
}
