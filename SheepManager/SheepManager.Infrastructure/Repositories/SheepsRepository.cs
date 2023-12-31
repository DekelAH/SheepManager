﻿using SheepManager.Core.Domain.Entities;
using SheepManager.Core.Domain.Repository_Contracts;
using SheepManager.Infrastructure.DatabaseContext;

namespace SheepManager.Infrastructure.Repositories
{
    public class SheepsRepository : ISheepsRepository
    {
        #region Fields

        private readonly ApplicationDbContext _applicationDbContext;

        #endregion

        #region Ctor

        public SheepsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        #endregion

        #region Methods

        public async Task<List<Sheep>> GetAllSheeps()
        {
            throw new NotImplementedException();
        }

        public async Task<Sheep?> GetSheepById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Sheep> AddNewSheep(Sheep newSheep)
        {
            throw new NotImplementedException();
        }

        public async Task<Sheep> UpdateSheep(Sheep sheepToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteSheepById(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
