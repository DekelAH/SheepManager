using SheepManager.Core.DTO.Matches;
using SheepManager.Core.DTO.Sheeps;

namespace SheepManager.Core.Services_Contracts.Matches
{
    public interface IMatchesService
    {
        #region Methods

        public Task<List<MatchResponse>> GetAllMatches(List<SheepResponse> males, List<SheepResponse> females);

        #endregion
    }
}
