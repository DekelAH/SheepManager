using SheepManager.Core.Domain.Entities;
using SheepManager.Core.DTO.Matches;
using SheepManager.Core.DTO.Sheeps;

namespace SheepManager.Core.DTO.Herds
{
    public class HerdUpdateRequest
    {
        #region Properties

        public Guid HerdId { get; set; }
        public string? HerdName { get; set; }
        public List<SheepResponse>? HerdSheeps { get; set; }
        public List<MatchResponse>? Matches { get; set; }

        #endregion

        #region Methods

        public Herd ToHerd()
        {
            return new Herd()
            {
                HerdId = HerdId,
                HerdName = HerdName,
            };
        }

        #endregion
    }
}
