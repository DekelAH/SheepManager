using SheepManager.Core.Domain.MatchCreator;
using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Core.DTO.Matches;
using SheepManager.Core.DTO.Sheeps;
using SheepManager.Core.Services_Contracts.Matches;

namespace SheepManager.Core.Services.Matches
{
    public class MatchesService : IMatchesService
    {
        #region Fields

        private readonly IMatchesRepository _matchesRepository;
        private readonly IMatchesCreator _matchCreator;

        #endregion

        #region Ctor

        public MatchesService(IMatchesRepository matchesRepository, IMatchesCreator matchCreator)
        {
            _matchesRepository = matchesRepository;
            _matchCreator = matchCreator;
        }

        #endregion

        #region Methods

        public async Task<List<MatchResponse>> GetAllMatches(List<SheepResponse> males, List<SheepResponse> females)
        {
            await ArrangeAndAddMatches(males, females);

            var allMatches = await _matchesRepository.GetAllMatches();
            if (allMatches.Count <= 0)
            {
                throw new NullReferenceException(nameof(allMatches));
            }

            var allMatchesResponse = allMatches.Select(m => m.ToMatchResponse()).ToList();
            return allMatchesResponse;
        }

        private async Task ArrangeAndAddMatches(List<SheepResponse> males, List<SheepResponse> females)
        {
            var allMales = males.Select(m => m.ToSheep()).ToList();
            var allFemales = females.Select(f => f.ToSheep()).ToList();
            var createdMatches = await _matchCreator.CreateMatches(await _matchesRepository.GetAllMatches(), allMales, allFemales);

            foreach (var match in createdMatches)
            {
                await _matchesRepository.AddNewMatch(match);
            }

            return;
        }

        #endregion
    }
}
