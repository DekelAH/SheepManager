using Microsoft.AspNetCore.Mvc;
using SheepManager.Core.DTO.Matches;
using SheepManager.Core.Services_Contracts.Matches;
using SheepManager.Core.Services_Contracts.Sheeps;

namespace SheepManager.WebAPI.Controllers
{
    public class MatchesController : CustomControllerBase
    {
        #region Fields

        private readonly IMatchesService _matchesService;
        private readonly ISheepsGetterService _sheepsGetterService;

        private readonly ILogger<MatchesController> _logger;

        #endregion

        #region Ctors

        public MatchesController
            (IMatchesService matchesService, 
             ISheepsGetterService sheepsGetterService,
             ILogger<MatchesController> logger
            )
        {
            _matchesService = matchesService;
            _sheepsGetterService = sheepsGetterService;
            _logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<ActionResult<List<MatchResponse>>> GetAllMatches()
        {
            _logger.LogInformation(message: "Getting all matches...");

            var allMales = await _sheepsGetterService.GetAllMales();
            if (allMales == null || allMales.Count <= 0)
            {
                _logger.LogInformation(message: "Can't find any males sheeps...");
                return NotFound();
            }

            var allFemales = await _sheepsGetterService.GetAllFemales();
            if (allFemales == null || allFemales.Count <= 0)
            {
                _logger.LogInformation(message: "Can't find any females sheeps...");
                return NotFound();
            }

            var allMatches = await _matchesService.GetAllMatches(allMales, allFemales);
            if (allMatches.Count <= 0 || allMatches == null)
            {
                return NotFound();
            }

            _logger.LogInformation(message: "Retrieved {matchesSum} matches", allMatches.Count);
            return Ok(allMatches);
        }

        #endregion
    }
}
