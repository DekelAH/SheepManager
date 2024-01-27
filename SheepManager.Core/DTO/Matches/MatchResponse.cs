using SheepManager.Core.Domain.Entities;

namespace SheepManager.Core.DTO.Matches
{
    public class MatchResponse
    {
        #region Properties

        public Guid MatchId { get; set; }
        public int MaleTagNumber { get; set; }
        public int FemaleTagNumber { get; set; }

        #endregion

        #region Methods

        public Match ToMatch()
        {
            return new Match()
            {
                MatchId = MatchId,
                MaleTagNumber = MaleTagNumber,
                FemaleTagNumber = FemaleTagNumber
            };
        }

        #endregion
    }

    public static class MatchExtenstionMethods
    {
        public static MatchResponse ToMatchResponse(this Match match)
        {
            return new MatchResponse()
            {
                MatchId = match.MatchId,
                MaleTagNumber = match.MaleTagNumber,
                FemaleTagNumber = match.FemaleTagNumber
            };
        }
    }
}
