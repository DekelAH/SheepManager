using Microsoft.AspNetCore.Mvc;
using SheepManager.Core.DTO.Herds;
using SheepManager.Core.Services_Contracts.Herds;
using SheepManager.Core.Services_Contracts.Sheeps;

namespace SheepManager.WebAPI.Controllers
{
    public class HerdsController : CustomControllerBase
    {
        #region Fields

        private readonly IHerdsGetterService _herdsGetterService;
        private readonly IHerdAdderService _herdAdderService;
        private readonly ISheepsGetterService _sheepsGetterService;

        private readonly ILogger<HerdsController> _logger;

        #endregion

        #region Ctor

        public HerdsController
            (
            ILogger<HerdsController> logger,
            IHerdsGetterService herdsGetterService,
            IHerdAdderService herdAdderService,
            ISheepsGetterService sheepsGetterService
            )
        {
            _logger = logger;
            _herdsGetterService = herdsGetterService;
            _herdAdderService = herdAdderService;
            _sheepsGetterService = sheepsGetterService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<ActionResult<List<HerdResponse>>> GetAllHerds()
        {
            _logger.LogInformation(message: "Getting all herds...");

            var allHerds = await _herdsGetterService.GetAllHerds();
            if (allHerds == null || allHerds.Count == 0)
            {
                return NotFound();
            }

            _logger.LogInformation(message: "Retrieved {herdSum} herds", allHerds.Count);
            return Ok(allHerds);
        }

        [HttpGet("{herdId}")]
        public async Task<ActionResult<HerdResponse>> GetHerdById(Guid herdId)
        {
            _logger.LogInformation(message: "Searching herd by id - {herdId}...", herdId);

            var foundHerd = await _herdsGetterService.GetHerdById(herdId);
            if (foundHerd == null)
            {
                return NotFound();
            }

            var allSheeps = await _sheepsGetterService.GetAllSheeps();
            foundHerd.HerdSheeps = allSheeps?.Where(s => s.HerdId == herdId).ToList();

            _logger.LogInformation(message: "Retrieved herd with an id - {herdId}", herdId);
            return Ok(foundHerd);
        }

        [HttpPost]
        public async Task<ActionResult<HerdResponse>> AddHerd(HerdAddRequest herdAddRequest)
        {
            _logger.LogInformation(message: "Adding new herd...");
            if (herdAddRequest == null)
            {
                return Problem(detail: "Invalid herd details", statusCode: 400, title: "Add Herd");
            }

            var addedHerd = await _herdAdderService.AddHerd(herdAddRequest);
            _logger.LogInformation(message: "Herd - {herdId} added successfuly", addedHerd.HerdId);
            return Ok(addedHerd);
        }

        #endregion

    }
}
