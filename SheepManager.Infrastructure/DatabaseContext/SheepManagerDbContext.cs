using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SheepManager.Core.Domain.Entities;

namespace SheepManager.Infrastructure.DatabaseContext
{
    public class SheepManagerDbContext : DbContext
    {
        #region Properties

        public virtual DbSet<Livestock> Livestocks { get; set; }
        public virtual DbSet<Herd> Herds { get; set; }
        public virtual DbSet<Sheep> Sheeps { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }
        #endregion

        #region Ctor

        public SheepManagerDbContext(DbContextOptions options) : base(options)
        {

        }

        #endregion

        #region SP Methods

        #region Sheeps_SP Methods
        public List<Sheep> Sp_GetAllSheeps()
        {
            return Sheeps.FromSqlRaw("EXECUTE [dbo].[GetAllSheeps]").AsNoTracking().ToList();
        }

        public List<Sheep> Sp_GetAllMales()
        {
            return Sheeps.FromSqlRaw($"EXECUTE [dbo].[GetAllMales]").AsNoTracking().ToList();
        }

        public List<Sheep> Sp_GetAllFemales()
        {
            return Sheeps.FromSqlRaw($"EXECUTE [dbo].[GetAllFemales]").AsNoTracking().ToList();
        }

        public Sheep? Sp_GetSheepById(Guid sheepId)
        {
            var returnedSheep = Sheeps.FromSql($"EXECUTE [dbo].[GetSheepById] {sheepId}").AsNoTracking().ToList();

            if (returnedSheep == null)
            {
                return null;
            }

            return returnedSheep.Where(s => s.SheepId == sheepId).FirstOrDefault();
        }

        public int Sp_AddSheep(Sheep newSheep)
        {
            SqlParameter[] sheepParameters = new SqlParameter[]
            {
                new SqlParameter("@SheepId", newSheep.SheepId),
                new SqlParameter("@TagNumber", newSheep.TagNumber),
                new SqlParameter("@HerdId", newSheep.HerdId),
                new SqlParameter("@Weight", newSheep.Weight),
                new SqlParameter("@Gender", newSheep.Gender),
                new SqlParameter("@Race", newSheep.Race),
                new SqlParameter("@BloodType", newSheep.BloodType),
                new SqlParameter("@Selection", newSheep.Selection),
                new SqlParameter("@Birthdate", newSheep.Birthdate),
                new SqlParameter("@MotherTagNumber", newSheep.MotherTagNumber),
                new SqlParameter("@FatherTagNumber", newSheep.FatherTagNumber),
                new SqlParameter("@IsDead", newSheep.IsDead),
                new SqlParameter("@IsSold", newSheep.IsSold),
                new SqlParameter("@IsPregnant", newSheep.IsPregnant)
            };

            int rowAffected = Database.ExecuteSqlRaw("EXECUTE [dbo].[AddSheep] @SheepId, @TagNumber, @HerdId, @Weight, @Gender, @Race, " +
                "@BloodType, @Selection, @Birthdate, @MotherTagNumber, @FatherTagNumber, @IsDead, @IsSold, " +
                "@IsPregnant", sheepParameters);

            return rowAffected;
        }

        public int Sp_UpdateSheep(Sheep sheepToUpdate)
        {
            SqlParameter[] sheepParameters = new SqlParameter[]
            {
                new SqlParameter("@SheepId", sheepToUpdate.SheepId),
                new SqlParameter("@TagNumber", sheepToUpdate.TagNumber),
                new SqlParameter("@HerdId", sheepToUpdate.HerdId),
                new SqlParameter("@Weight", sheepToUpdate.Weight),
                new SqlParameter("@Gender", sheepToUpdate.Gender),
                new SqlParameter("@Race", sheepToUpdate.Race),
                new SqlParameter("@BloodType", sheepToUpdate.BloodType),
                new SqlParameter("@Selection", sheepToUpdate.Selection),
                new SqlParameter("@Birthdate", sheepToUpdate.Birthdate),
                new SqlParameter("@MotherTagNumber", sheepToUpdate.MotherTagNumber),
                new SqlParameter("@FatherTagNumber", sheepToUpdate.FatherTagNumber),
                new SqlParameter("@IsDead", sheepToUpdate.IsDead),
                new SqlParameter("@IsSold", sheepToUpdate.IsSold),
                new SqlParameter("@IsPregnant", sheepToUpdate.IsPregnant)
            };

            int rowAffected = Database.ExecuteSqlRaw("EXECUTE [dbo].[UpdateSheep] @SheepId, @TagNumber,@HerdId, @Weight, @Gender, @Race, " +
            "@BloodType, @Selection, @Birthdate, @MotherTagNumber, @FatherTagNumber, @IsDead, @IsSold, " +
            "@IsPregnant", sheepParameters);

            return rowAffected;
        }
        #endregion

        #region Vaccines_SP Methods

        public List<Vaccine> Sp_GetAllVaccines()
        {
            return Vaccines.FromSqlRaw("EXECUTE [dbo].[GetAllVaccines]").ToList();
        }

        public List<Vaccine>? Sp_GetVaccinesByTagNumber(int tagNumber)
        {
            var returnedVaccines = Vaccines.FromSql($"EXECUTE [dbo].[GetVaccinesByTagNumber] {tagNumber}").ToList();

            if (returnedVaccines == null || returnedVaccines.Count == 0)
            {
                return null;
            }

            return returnedVaccines;
        }

        public int Sp_AddVaccine(Vaccine newVaccine)
        {
            SqlParameter[] vaccineParameters = new SqlParameter[]
            {
                new SqlParameter("@VaccineId", newVaccine.VaccineId),
                new SqlParameter("@VaccineName", newVaccine.VaccineName),
                new SqlParameter("@VaccinationDate", newVaccine.VaccinationDate),
                new SqlParameter("@IsForBirth", newVaccine.IsForBirth),
                new SqlParameter("@IsMandatory", newVaccine.IsMandatory),
                new SqlParameter("@SheepTagNumber", newVaccine.SheepTagNumber)
            };

            int rowAffected = Database.ExecuteSqlRaw("EXECUTE [dbo].[AddVaccine] @VaccineId, @VaccineName, @VaccinationDate, " +
                "@IsForBirth, @IsMandatory, @SheepTagNumber", vaccineParameters);

            return rowAffected;
        }

        public int Sp_UpdateVaccine(Vaccine vaccineToUpdate)
        {
            SqlParameter[] vaccineParameters = new SqlParameter[]
{
                new SqlParameter("@VaccineId", vaccineToUpdate.VaccineId),
                new SqlParameter("@VaccineName", vaccineToUpdate.VaccineName),
                new SqlParameter("@VaccinationDate", vaccineToUpdate.VaccinationDate),
                new SqlParameter("@IsForBirth", vaccineToUpdate.IsForBirth),
                new SqlParameter("@IsMandatory", vaccineToUpdate.IsMandatory),
                new SqlParameter("@SheepTagNumber", vaccineToUpdate.SheepTagNumber)
};

            int rowAffected = Database.ExecuteSqlRaw("EXECUTE [dbo].[UpdateVaccine] @VaccineId, @VaccineName, @VaccinationDate," +
                "@IsForBirth, @IsMandatory, @SheepTagNumber", vaccineParameters);

            return rowAffected;
        }

        #endregion

        #region Matches_SP Methods

        public List<Match> Sp_GetAllMatches()
        {
            return Matches.FromSqlRaw("EXECUTE [dbo].[GetAllMatches]").ToList();
        }

        public int Sp_AddMatch(Match newMatch)
        {
            SqlParameter[] matchParameters = new SqlParameter[]
            {
                new SqlParameter("@MatchId", newMatch.MatchId),
                new SqlParameter("@MaleTagNumber", newMatch.MaleTagNumber),
                new SqlParameter("@FemaleTagNumber", newMatch.FemaleTagNumber)
            };

            int rowAffected = Database.ExecuteSqlRaw("EXECUTE [dbo].[AddMatch] @MatchId, @MaleTagNumber, @FemaleTagNumber", 
                matchParameters);

            return rowAffected;
        }

        #endregion

        #region Herds_SP Methods

        #endregion

        public List<Herd> Sp_GetAllHerds()
        {
            return Herds.FromSqlRaw("EXECUTE [dbo].[GetAllHerds]").AsNoTracking().ToList();
        }

        public Herd Sp_GetHerdById(Guid herdId)
        {
            var foundHerd = Herds.Where(h => h.HerdId == herdId).FirstOrDefault();
            if (foundHerd != null)
            {
                return foundHerd;
            }

            return null;
        }

        public int Sp_AddHerd(Herd newHerd)
        {
            SqlParameter[] herdParameters = new SqlParameter[]
            {
                new SqlParameter("@HerdId", newHerd.HerdId),
                new SqlParameter("@HerdName", newHerd.HerdName)
            };

            int rowAffected = Database.ExecuteSqlRaw("EXECUTE [dbo].[AddHerd] @HerdId, @HerdName",
                herdParameters);

            return rowAffected;
        }

        #endregion
    }
}
