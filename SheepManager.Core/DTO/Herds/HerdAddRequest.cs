using SheepManager.Core.Domain.Entities;

namespace SheepManager.Core.DTO.Herds
{
    public class HerdAddRequest
    {
        #region Properties

        public string? HerdName { get; set; }

        #endregion

        #region Methods

        public Herd ToHerd()
        {
            return new Herd()
            {
                HerdName = HerdName,
            };
        }

        #endregion
    }
}
