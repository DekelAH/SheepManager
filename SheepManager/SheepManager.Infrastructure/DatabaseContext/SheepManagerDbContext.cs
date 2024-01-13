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

        #endregion

        #region Ctor

        public SheepManagerDbContext(DbContextOptions options) : base(options)
        {

        }

        #endregion

        #region SP Methods

        public List<Sheep> Sp_GetAllSheeps()
        {
            return Sheeps.FromSqlRaw("EXECUTE [dbo].[GetAllSheeps]").ToList();
        }

        public Sheep Sp_GetSheepById(Guid sheepId)
        {
            return null;
            //return Sheeps.FromSqlRaw("EXECUTE [dbo].[GetSheepById]");
        }

        public Sheep Sp_AddSheep(Sheep newSheep)
        {
            return newSheep;
        }

        public Sheep Sp_UpdateSheep(Sheep sheepToUpdate)
        {
            return sheepToUpdate;
        }

        #endregion
    }
}
