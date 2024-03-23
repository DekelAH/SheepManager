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

        public async Task<List<SheepResponse>?> GetAllMales()
        {
            var allMaleSheeps = await _sheepsRepository.GetAllMales();
            if (allMaleSheeps.Count <= 0)
            {
                return null;
            }

            var allSheepsResponse = allMaleSheeps.Select(s => s.ToSheepResponse()).ToList();
            return allSheepsResponse;
        }

        public async Task<List<SheepResponse>?> GetAllFemales()
        {
            var allFemaleSheeps = await _sheepsRepository.GetAllFemales();
            if (allFemaleSheeps.Count <= 0)
            {
                return null;
            }

            var allSheepsResponse = allFemaleSheeps.Select(s => s.ToSheepResponse()).ToList();
            return allSheepsResponse;
        }

        public async Task<SheepResponse?> GetSheepById(Guid sheepId)
        {
            var matchingSheep = await _sheepsRepository.GetSheepById(sheepId);
            return matchingSheep?.ToSheepResponse();
        }

        public async Task<List<SheepResponse>?> GetSheepsByHerdId(Guid herdId)
        {
            var allSheeps = await GetAllSheeps();
            var allSheepsByHerd = allSheeps?.Where(s => s.HerdId == herdId).ToList();
            if (allSheepsByHerd is null)
            {
                return null;
            }
            return allSheepsByHerd;
        }

        #endregion
    }
}
