using Microsoft.EntityFrameworkCore;
using RdlNet2018.Common.Contracts;
using RdlNet2018.Common.Models;
using RdlNet2018.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RdlNet2018.Common.Repos
{
    public class WorkHistoryRepository : RepositoryBase<WorkHistory>, IWorkHistoryRepository, IDisposable
    {
        protected RDL2018Context _context { get; set; }

        public WorkHistoryRepository(RDL2018Context context) : base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<WorkHistory>> GetAllWorkHistoryItemsAsync()
        {
            return await _context.WorkHistory
                            .Include(d => d.WorkHistoryDetails)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<WorkHistory> GetWorkHistoryByIdAsync(Guid workHistoryId)
        {
            return await Task.Run(() => _context.WorkHistory
                .Where(o => o.WorkHistoryId.Equals(workHistoryId))
                .Include(d => d.WorkHistoryDetails).FirstOrDefault());
        }

        public async Task CreateWorkHistoryAsync(WorkHistory workHistory)
        {
            Add(workHistory);
            await SaveDataAsync();
        }

        public async Task UpdateWorkHistoryAsync(WorkHistory workHistory)
        {
            Update(workHistory);
            await SaveDataAsync();
        }

        public async Task DeleteWorkHistoryAsync(WorkHistory workHistory)
        {
            Delete(workHistory);
            await SaveDataAsync();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
