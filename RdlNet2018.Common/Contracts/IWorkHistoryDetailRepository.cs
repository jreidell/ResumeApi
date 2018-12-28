using RdlNet2018.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNet2018.Common.Contracts
{
    public interface IWorkHistoryDetailRepository : IDisposable
    {
        Task<IEnumerable<WorkHistoryDetail>> GetAllWorkHistoryDetailItemsAsync();
        Task<WorkHistoryDetail> GetWorkHistoryDetailByIdAsync(Guid workHistoryDetailId);
        Task CreateWorkHistoryDetailAsync(WorkHistoryDetail workHistoryDetail);
        Task UpdateWorkHistoryDetailAsync(WorkHistoryDetail workHistoryDetail);
        Task DeleteWorkHistoryDetailAsync(WorkHistoryDetail workHistoryDetail);
    }
}
