using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Core.DTO.Sheeps;
using SheepManager.Core.Services_Contracts.Sheeps;

namespace SheepManager.Core.Services.Sheeps
{
    public class SheepsAdderService : ISheepsAdderService
    {
        #region Fields

        private readonly ISheepsRepository _sheepsRepository;

        #endregion

        #region Ctor

        public SheepsAdderService(ISheepsRepository sheepsRepository)
        {
            _sheepsRepository = sheepsRepository;
        }

        #endregion

        #region Methods

        public async Task<SheepResponse> AddSheep(SheepAddRequest sheepAddRequest)
        {
            var newSheep = sheepAddRequest.ToSheep();
            newSheep.SheepId = Guid.NewGuid();

            await _sheepsRepository.AddNewSheep(newSheep);
            var sheepResponse = newSheep.ToSheepResponse();

            return sheepResponse;
        }

        #endregion
    }
}
