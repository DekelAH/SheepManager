using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Core.DTO.Sheeps;
using SheepManager.Core.DTO.Vaccines;
using SheepManager.Core.Services_Contracts.Vaccines;

namespace SheepManager.Core.Services.Vaccines
{
    public class VaccinesAdderService : IVaccinesAdderService
    {
        #region Fields

        private readonly IVaccinesRepository _vaccinesRepository;

        #endregion

        #region Ctor

        public VaccinesAdderService(IVaccinesRepository vaccinesRepository)
        {
            _vaccinesRepository = vaccinesRepository;
        }

        #endregion

        #region Methods

        public async Task<VaccineResponse> AddVaccine(VaccineAddRequest vaccineAddRequest)
        {
            var newVaccine= vaccineAddRequest.ToVaccine();
            newVaccine.VaccineId = Guid.NewGuid();

            await _vaccinesRepository.AddNewVaccine(newVaccine);
            var vaccineResponse = newVaccine.ToVaccineResponse();

            return vaccineResponse;
        }

        #endregion
    }
}
