using SheepManager.Core.Domain.Entities;

namespace SheepManager.Core.Domain.Repository_Contracts
{
    public interface IMatchesRepository
    {
        #region Methods

        Task<List<Match>> GetAllMatches();
        Task<Match> AddNewMatch(Match newMatch);

        #endregion
    }
}
