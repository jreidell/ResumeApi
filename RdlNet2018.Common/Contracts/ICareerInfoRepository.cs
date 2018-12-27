using RdlNet2018.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNet2018.Common.Contracts
{
    public interface ICareerInfoRepository
    {
        Task<IEnumerable<CareerInfo>> GetAllCareerInfoItemsAsync();
        Task<CareerInfo> GetCareerInfoByIdAsync(Guid careerInfoId);
        Task CreateCareerInfoAsync(CareerInfo careerInfo);
        Task UpdateCareerInfoAsync(CareerInfo careerInfo);
        Task DeleteCareerInfoAsync(CareerInfo careerInfo);
    }
}
