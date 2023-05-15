﻿using SALES_API.Data.WorkUnit.Interfaces;

namespace SALES_API.Data.WorkUnit
{
    public class WorkUnit : IWorkUnit
    {
        private readonly AppDbContext _appDbContext;
        public WorkUnit(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _appDbContext.Database.BeginTransaction();
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.Database.CommitTransactionAsync();
        }

        public void Rollback()
        {
            _appDbContext.Database.RollbackTransaction();
        }

        public async Task DeleteAsync()
        {
            await _appDbContext.Database.EnsureDeletedAsync();
        }
    }
}
