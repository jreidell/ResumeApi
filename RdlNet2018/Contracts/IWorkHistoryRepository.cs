using Microsoft.AspNetCore.Mvc;
using RdlNet2018.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNet2018.Contracts
{
    public interface IWorkHistoryRepository
    {
        Task<IEnumerable<WorkHistory>> GetAllWorkHistoryItemsAsync();
        Task<WorkHistory> GetWorkHistoryByIdAsync(Guid workHistoryId);
        Task CreateWorkHistoryAsync(WorkHistory workHistory);
        Task UpdateWorkHistoryAsync(WorkHistory workHistory);
        Task DeleteWorkHistoryAsync(WorkHistory workHistory);
    }
}
