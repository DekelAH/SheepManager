using SheepManager.Core.Domain.Entities;
using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Infrastructure.DatabaseContext;

namespace SheepManager.Infrastructure.Repositories
{
    public class VaccinesRepository : IVaccinesRepository
    {
        #region Fields

        private readonly SheepManagerDbContext _sheepManagerDbContext;

        #endregion

        #region Ctor

        public VaccinesRepository(SheepManagerDbContext sheepManagerDbContext)
        {
            _sheepManagerDbContext = sheepManagerDbContext;
        }

        #endregion

        #region Methods

        public Task<List<Vaccine>> GetAllVaccines()
        {
            return Task.FromResult(_sheepManagerDbContext.Sp_GetAllVaccines());
        }

        public Task<List<Vaccine>>? GetVaccinesByTagNumber(int tagNumber)
        {
            var vaccinesByTagNumber = _sheepManagerDbContext.Sp_GetVaccinesByTagNumber(tagNumber);
            if (vaccinesByTagNumber == null || vaccinesByTagNumber.Count == 0)
            {
                throw new NullReferenceException("No vaccines were found, check tag number input");
            }

            return Task.FromResult(vaccinesByTagNumber);
        }

        public Task<Vaccine> AddNewVaccine(Vaccine newVaccine)
        {
            _sheepManagerDbContext.Sp_AddVaccine(newVaccine);
            return Task.FromResult(newVaccine);
        }

        public Task<Vaccine> UpdateVaccine(Vaccine vaccineToUpdate)
        {
            _sheepManagerDbContext.Sp_UpdateVaccine(vaccineToUpdate);
            return Task.FromResult(vaccineToUpdate);
        }

        #endregion
    }
}
