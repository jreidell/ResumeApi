using RdlNet2018.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNet2018.Common.Contracts
{
    public interface IWorkHistoryRepository : IDisposable
    {
        Task<IEnumerable<WorkHistory>> GetAllWorkHistoryItemsAsync();
        Task<WorkHistory> GetWorkHistoryByIdAsync(Guid workHistoryId);
        Task CreateWorkHistoryAsync(WorkHistory workHistory);
        Task UpdateWorkHistoryAsync(WorkHistory workHistory);
        Task DeleteWorkHistoryAsync(WorkHistory workHistory);
    }
}
