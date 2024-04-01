using SheepManager.Core.Domain.Entities;
using SheepManager.Core.DTO.Matches;
using SheepManager.Core.DTO.Sheeps;
using SheepManager.Core.DTO.Vaccines;

namespace SheepManager.Core.DTO.Herds
{
    public class HerdResponse
    {
        #region Properties

        public Guid HerdId { get; set; }
        public string? HerdName { get; set; }
        public List<SheepResponse>? HerdSheeps { get; set; }
        public List<MatchResponse>? Matches { get; set; }
        public List<VaccineResponse>? Vaccines { get; set; }

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

    public static class HerdExtensionMethods
    {
        public static HerdResponse ToHerdResponse(this Herd herd)
        {
            return new HerdResponse()
            {
                HerdId = herd.HerdId,
                HerdName = herd.HerdName
            };
        }
    }
}
