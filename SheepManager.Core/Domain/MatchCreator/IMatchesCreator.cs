using SheepManager.Core.Domain.Entities;

namespace SheepManager.Core.Domain.MatchCreator
{
    public interface IMatchesCreator
    {
        #region Methods

        public Task<List<Match>> CreateMatches(List<Match> existingMatches, List<Sheep> allmales, List<Sheep> allFemales);

        #endregion
    }
}
