using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Core.DTO.Sheeps;
using SheepManager.Core.Services_Contracts.Sheeps;

namespace SheepManager.Core.Services.Sheeps
{
    public class SheepsUpdaterService : ISheepsUpdaterService
    {
        #region Fields

        private readonly ISheepsRepository _sheepsRepository;

        #endregion

        #region Ctors

        public SheepsUpdaterService(ISheepsRepository sheepsRepository)
        {
            _sheepsRepository = sheepsRepository;
        }

        #endregion

        #region Methods

        public async Task<SheepResponse> UpdateSheep(SheepUpdateRequest sheepUpdateRequest)
        {
            var sheep = sheepUpdateRequest.ToSheep();
            var updatedSheep = await _sheepsRepository.UpdateSheep(sheep);
            var sheepResponse = updatedSheep.ToSheepResponse();
            return sheepResponse;
        }

        #endregion
    }
}
