using Microsoft.AspNetCore.Mvc;
using RdlNet2018.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNet2018.Contracts
{
    public interface IWorkHistoryDetailRepository
    {
        Task<IEnumerable<WorkHistoryDetail>> GetAllWorkHistoryDetailItemsAsync();
        Task<WorkHistoryDetail> GetWorkHistoryDetailByIdAsync(Guid workHistoryDetailId);
        Task CreateWorkHistoryDetailAsync(WorkHistoryDetail workHistoryDetail);
        Task UpdateWorkHistoryDetailAsync(WorkHistoryDetail workHistoryDetail);
        Task DeleteWorkHistoryDetailAsync(WorkHistoryDetail workHistoryDetail);
    }
}
