using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Core.DTO.Sheeps;
using SheepManager.Core.Services_Contracts.Sheeps;

namespace SheepManager.Core.Services.Sheeps
{
    public class SheepsGetterService : ISheepsGetterService
    {
        #region Fields

        private readonly ISheepsRepository _sheepsRepository;

        #endregion

        #region Ctor

        public SheepsGetterService(ISheepsRepository sheepsRepository)
        {
            _sheepsRepository = sheepsRepository;
        }

        #endregion

        #region Methods

        public async Task<List<SheepResponse>?> GetAllSheeps()
        {
            var allSheeps = await _sheepsRepository.GetAllSheeps();
            if (allSheeps.Count <= 0)
            {
                return null;
            }
            var allSheepsResponse = allSheeps.Select(s => s.ToSheepResponse()).ToList();
            return allSheepsResponse;
        }

        public async Task<SheepResponse?> GetSheepById(Guid id)
        {
            var matchingSheep = await _sheepsRepository.GetSheepById(id);
            if (matchingSheep == null)
            {
                return null;
            }
            return matchingSheep.ToSheepResponse();
        }

        #endregion
    }
}
