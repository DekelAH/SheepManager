using Microsoft.IdentityModel.Tokens;
using SheepManager.Core.Domain.Entities;

namespace SheepManager.Core.Domain.MatchCreator
{
    public class MatchesCreator : IMatchesCreator
    {
        #region Methods

        public async Task<List<Match>> CreateMatches(List<Sheep> allMales, List<Sheep> allFemales)
        {
            if (allMales.IsNullOrEmpty() || allFemales.IsNullOrEmpty())
            {
                var paramName = "No sheeps to match";
                throw new ArgumentNullException(paramName);
            }

            var matches = await MatchesCreation(allMales, allFemales);
            return matches;
        }

        private static Task<List<Match>> MatchesCreation(List<Sheep> males, List<Sheep> females)
        {
            var matchesCreatedList = new List<Match>();

            foreach (var male in males)
            {
                foreach (var female in females)
                {
                    if (!HaveGeneticRelation(male, female) && female.GetAge() >= 1.0)
                    {
                        if (female is { Gender: "Female", IsPregnant: false, IsDead: false, IsSold: false, Selection: "Breed", Weight: >= 60.0 })
                        {
                            var newMatch = new Match()
                            {
                                MatchId = new Guid(),
                                MaleTagNumber = male.TagNumber,
                                FemaleTagNumber = female.TagNumber
                            };

                            matchesCreatedList.Add(newMatch);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return Task.FromResult(matchesCreatedList);
        }

        private static bool HaveGeneticRelation(Sheep maleToCheck, Sheep femaleToCheck)
        {
            if (maleToCheck.TagNumber != femaleToCheck.FatherTagNumber)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
