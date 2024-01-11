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
    }
}
