using RdlNetSvc.Common.Contracts;
using RdlNetSvc.Common.Models;
using RdlNetSvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RdlNetSvc.Common.Repos
{
    public class WorkHistoryDetailRepository : RepositoryBase<WorkHistoryDetail>, IWorkHistoryDetailRepository, IDisposable
    {
        protected RDL2018Context _context { get; set; }

        public WorkHistoryDetailRepository(RDL2018Context context) : base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<WorkHistoryDetail>> GetAllWorkHistoryDetailItemsAsync()
        {
            var workHistoryDetailItems = await GetAllAsync();
            return workHistoryDetailItems;
        }

        public async Task<WorkHistoryDetail> GetWorkHistoryDetailByIdAsync(Guid workHistoryDetailId)
        {
            var workHistoryDetail = await GetWhereExpressionAsync(o => o.WorkHistoryDetailId.Equals(workHistoryDetailId));
            return workHistoryDetail.DefaultIfEmpty(new WorkHistoryDetail())
                    .FirstOrDefault();
        }

        public async Task CreateWorkHistoryDetailAsync(WorkHistoryDetail workHistoryDetail)
        {
            Add(workHistoryDetail);
            await SaveDataAsync();
        }

        public async Task UpdateWorkHistoryDetailAsync(WorkHistoryDetail workHistoryDetail)
        {
            Update(workHistoryDetail);
            await SaveDataAsync();
        }

        public async Task DeleteWorkHistoryDetailAsync(WorkHistoryDetail workHistoryDetail)
        {
            Delete(workHistoryDetail);
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
