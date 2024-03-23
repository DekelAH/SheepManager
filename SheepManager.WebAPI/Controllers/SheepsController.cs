using Microsoft.AspNetCore.Mvc;
using SheepManager.Core.DTO.Sheeps;
using SheepManager.Core.Services_Contracts.Sheeps;

namespace SheepManager.WebAPI.Controllers
{
    public class SheepsController : CustomControllerBase
    {
        #region Fields

        private readonly ISheepsGetterService _sheepsGetterService;
        private readonly ISheepsAdderService _sheepsAdderService;
        private readonly ISheepsUpdaterService _sheepsUpdaterService;

        private readonly ILogger<SheepsController> _logger;

        #endregion

        #region Ctor

        public SheepsController
            (
            ILogger<SheepsController> logger,
            ISheepsGetterService sheepsGetterService,
            ISheepsAdderService sheepsAdderService,
            ISheepsUpdaterService sheepsUpdaterService
            )
        {
            _logger = logger;
            _sheepsGetterService = sheepsGetterService;
            _sheepsAdderService = sheepsAdderService;
            _sheepsUpdaterService = sheepsUpdaterService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<ActionResult<List<SheepResponse>>> GetAllSheeps()
        {
            _logger.LogInformation(message: "Getting all sheeps...");

            var allSheeps = await _sheepsGetterService.GetAllSheeps();
            if (allSheeps is null || allSheeps.Count == 0)
            {
                return NotFound();
            }

            _logger.LogInformation(message: "Retrieved {sheepsSum} sheeps", allSheeps.Count);
            return Ok(allSheeps);
        }

        [HttpGet("{sheepId}")]
        public async Task<ActionResult<SheepResponse>> GetSheepById(Guid sheepId)
        {
            _logger.LogInformation(message: "Searching sheep by id - {sheepId}...", sheepId);

            var foundSheep = await _sheepsGetterService.GetSheepById(sheepId);
            if (foundSheep is null)
            {
                return NotFound();
            }

            _logger.LogInformation(message: "Retrieved sheep with an id - {sheepId}", sheepId);
            return Ok(foundSheep);
        }

        [HttpPost]
        public async Task<ActionResult<SheepResponse>> AddSheep(SheepAddRequest sheepAddRequest)
        {
            _logger.LogInformation(message: "Adding new sheep...");
            if (sheepAddRequest is null)
            {
                return Problem(detail: "Invalid sheep details", statusCode: 400, title: "Add Sheep");
            }

            var addedSheep = await _sheepsAdderService.AddSheep(sheepAddRequest);
            _logger.LogInformation(message: "Sheep - {sheepId} added successfuly", addedSheep.SheepId);
            return Ok(addedSheep);
        }

        [HttpPut("{sheepId}")]
        public async Task<ActionResult<SheepResponse>> UpdateSheep(Guid sheepId, SheepUpdateRequest sheepUpdateRequest)
        {
            _logger.LogInformation(message: "Searching matching sheep...");
            if (sheepId != sheepUpdateRequest.SheepId)
            {
                return BadRequest();
            }
            var matchingSheepResponse = await _sheepsGetterService.GetSheepById(sheepUpdateRequest.SheepId);
            if (matchingSheepResponse is null)
            {
                return Problem(detail: "Invalid sheep id", statusCode: 404, title: "Sheep search");
            }
            var updatedSheepResponse = await _sheepsUpdaterService.UpdateSheep(sheepUpdateRequest);

            return Ok(updatedSheepResponse);
        }

        #endregion

    }
}
