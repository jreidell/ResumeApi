using RdlNetSvc.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNetSvc.Common.Contracts
{
    public interface ICareerInfoRepository : IDisposable
    {
        Task<IEnumerable<CareerInfo>> GetAllCareerInfoItemsAsync();
        Task<CareerInfo> GetCareerInfoByIdAsync(Guid careerInfoId);
        Task CreateCareerInfoAsync(CareerInfo careerInfo);
        Task UpdateCareerInfoAsync(CareerInfo careerInfo);
        Task DeleteCareerInfoAsync(CareerInfo careerInfo);
    }
}
