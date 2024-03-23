using SheepManager.Core.DTO.Herds;
using SheepManager.Core.DTO.Sheeps;
using SheepManager.Core.Services_Contracts.Herds;
using SheepManager.Core.Services_Contracts.Sheeps;

namespace SheepManager.Core.Services.Herds
{
    public class HerdUpdaterService : IHerdUpdaterService
    {
        #region Fields

        private readonly ISheepsUpdaterService _sheepsUpdaterService;
        private readonly ISheepsGetterService _sheepsGetterService;

        #endregion

        #region Ctor

        public HerdUpdaterService(ISheepsUpdaterService sheepsUpdaterService, ISheepsGetterService sheeepsGetterService)
        {
            _sheepsUpdaterService = sheepsUpdaterService;
            _sheepsGetterService = sheeepsGetterService;

        }

        #endregion

        #region Methods

        public async Task<HerdResponse> UpdateHerd(HerdUpdateRequest herdUpdateRequest)
        {
            var herdResponse = new HerdResponse()
            {
                HerdId = herdUpdateRequest.HerdId,
                HerdName = herdUpdateRequest.HerdName,
                HerdSheeps = new List<SheepResponse>(),
                Matches = herdUpdateRequest.Matches
            };

            var allSheepsByHerd = await _sheepsGetterService.GetSheepsByHerdId(herdUpdateRequest.HerdId);

            allSheepsByHerd?.ForEach(async s =>
            {
                var sheepUpdateRequest = herdUpdateRequest.HerdSheeps?.Single(hs => hs.SheepId == s.SheepId);

                if (sheepUpdateRequest is null) { return; }

                var updatedSheep = await _sheepsUpdaterService.UpdateSheep(sheepUpdateRequest.ToSheep().ToSheepUpdateRequest());
                herdResponse.HerdSheeps.Add(updatedSheep);
            });

            return herdResponse;
        }
        

        #endregion
    }
}
