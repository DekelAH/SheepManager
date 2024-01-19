using SheepManager.Core.Domain.Entities;

namespace SheepManager.Core.Domain.Repository_Contracts
{
    public interface IVaccinesRepository
    {
        #region Methods

        Task<List<Vaccine>> GetAllVaccines();
        Task<List<Vaccine>>? GetVaccinesByTagNumber(int tagNumber);
        Task<Vaccine> AddNewVaccine(Vaccine newVaccine);
        Task<Vaccine> UpdateVaccine(Vaccine vaccineToUpdate);

        #endregion
    }
}
