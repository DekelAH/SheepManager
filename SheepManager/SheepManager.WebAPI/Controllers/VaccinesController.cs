using Microsoft.AspNetCore.Mvc;
using SheepManager.Core.Domain.Entities;
using SheepManager.Core.DTO.Sheeps;
using SheepManager.Core.DTO.Vaccines;
using SheepManager.Core.Services_Contracts.Vaccines;

namespace SheepManager.WebAPI.Controllers
{
    public class VaccinesController : CustomControllerBase
    {
        #region Fields

        private readonly IVaccinesGetterService _vaccinesGetterService;
        private readonly IVaccinesAdderService _vaccinesAdderService;
        private readonly IVaccinesUpdaterService _vaccinesUpdaterService;

        private readonly ILogger<VaccinesController> _logger;

        #endregion

        #region Ctor

        public VaccinesController
            (
            IVaccinesGetterService vaccinesGetterService,
            IVaccinesAdderService vaccinesAdderService,
            IVaccinesUpdaterService vaccinesUpdaterService,
            ILogger<VaccinesController> logger
            )
        {
            _vaccinesGetterService = vaccinesGetterService;
            _vaccinesAdderService = vaccinesAdderService;
            _vaccinesUpdaterService = vaccinesUpdaterService;
            _logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<ActionResult<List<Vaccine>>> GetAllVaccines()
        {
            _logger.LogInformation(message: "Getting all vaccines...");
            var allVaccines = await _vaccinesGetterService.GetAllVaccines();
            if (allVaccines.Count <= 0 || allVaccines == null)
            {
                return NotFound();
            }

            _logger.LogInformation(message: "Retrieved {vaccinesSum} sheeps", allVaccines.Count);
            return Ok(allVaccines);
        }

        [HttpGet("{tagNumber}")]
        public async Task<ActionResult<List<Vaccine>>> GetVaccinesByTagNumber(int tagNumber)
        {
            _logger.LogInformation(message: "Getting matching vaccines...");
            var matchingVaccines = await _vaccinesGetterService.GetVaccinesByTagNumber(tagNumber)!;
            if (matchingVaccines == null || matchingVaccines.Count <= 0)
            {
                return NotFound("No vaccines matching to the given tag number");
            }

            _logger.LogInformation(message: "Retrieved {vaccinesSum} vaccines with a Tag Number - {tagNumber}",
                matchingVaccines.Count, tagNumber);

            return Ok(matchingVaccines);
        }

        [HttpPost]
        public async Task<ActionResult<VaccineResponse>> AddVaccine(VaccineAddRequest vaccineAddRequest)
        {
            _logger.LogInformation(message: "Adding new vaccine...");
            if (vaccineAddRequest == null)
            {
                return Problem(detail: "Invalid vaccine details", statusCode: 400, title: "Add Vaccine");
            }

            var addedVaccine = await _vaccinesAdderService.AddVaccine(vaccineAddRequest);
            _logger.LogInformation(message: "Vaccine - {vaccineId} added successfuly", addedVaccine.VaccineId);
            return Ok(addedVaccine);
        }

        [HttpPut("{vaccineId}")]
        public async Task<ActionResult<VaccineResponse>> UpdateVaccine(Guid vaccineId, VaccineUpdateRequest vaccineUpdateRequest)
        {
            _logger.LogInformation(message: "Searching matching vaccine...");
            if (vaccineId != vaccineUpdateRequest.VaccineId)
            {
                return BadRequest();
            }

            var allVaccines = await _vaccinesGetterService.GetAllVaccines();
            var matchingVaccineResponse = allVaccines.Where(v => v.VaccineId == vaccineId);
            if (matchingVaccineResponse == null)
            {
                return Problem(detail: "Invalid vaccine id", statusCode: 404, title: "Vaccine search");
            }
            var updatedVaccineResponse = await _vaccinesUpdaterService.UpdateVaccine(vaccineUpdateRequest);

            return Ok(updatedVaccineResponse);
        }

        #endregion
    }
}
