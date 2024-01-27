using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Core.DTO.Herds;
using SheepManager.Core.Services_Contracts.Herds;

namespace SheepManager.Core.Services.Herds
{
    public class HerdsGetterService : IHerdsGetterService
    {
        #region Fields

        private readonly IHerdsRepository _herdsRepository;

        #endregion

        #region Ctor

        public HerdsGetterService(IHerdsRepository herdsRepository)
        {
            _herdsRepository = herdsRepository;
        }

        #endregion

        #region Methods

        public async Task<List<HerdResponse>?> GetAllHerds()
        {
            var allHerds = await _herdsRepository.GetAllHerds();
            if (allHerds.Count <= 0 || allHerds == null)
            {
                return null;
            }

            var allHerdResponse = allHerds.Select(s => s.ToHerdResponse()).ToList();
            return allHerdResponse;
        }

        public async Task<HerdResponse?> GetHerdById(Guid herdId)
        {
            var herd = await _herdsRepository.GetHerdById(herdId);
            return herd?.ToHerdResponse();
        }

        #endregion
    }
}
