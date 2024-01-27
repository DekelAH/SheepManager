using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Core.DTO.Herds;
using SheepManager.Core.Services_Contracts.Herds;

namespace SheepManager.Core.Services.Herds
{
    public class HerdsAdderService : IHerdAdderService
    {
        #region Fields

        private readonly IHerdsRepository _herdsRepository;

        #endregion

        #region Ctor

        public HerdsAdderService(IHerdsRepository herdsRepository)
        {
            _herdsRepository = herdsRepository;
        }

        #endregion

        #region Methods

        public async Task<HerdResponse> AddHerd(HerdAddRequest herdAddRequest)
        {
            var newHerd = herdAddRequest.ToHerd();
            newHerd.HerdId = Guid.NewGuid();

            await _herdsRepository.AddNewHerd(newHerd);
            var herdResponse = newHerd.ToHerdResponse();

            return herdResponse;
        }


        #endregion
    }
}
