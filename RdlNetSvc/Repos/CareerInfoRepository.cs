using Microsoft.EntityFrameworkCore;
using RdlNetSvc.Common.Contracts;
using RdlNetSvc.Common.Models;
using RdlNetSvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RdlNetSvc.Common.Repos
{
    public class CareerInfoRepository : RepositoryBase<CareerInfo>, ICareerInfoRepository, IDisposable
    {
        protected RDL2018Context _context { get; set; }

        public CareerInfoRepository(RDL2018Context context) : base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<CareerInfo>> GetAllCareerInfoItemsAsync()
        {
            //var careerInfoItems = await GetAllAsync();
            //return careerInfoItems;
            return await _context.CareerInfo
                .Include(s => s.JobSkills)
                .Include(w => w.WorkHistory)
                    .ThenInclude(d => d.WorkHistoryDetails)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CareerInfo> GetCareerInfoByIdAsync(Guid careerInfoId)
        {
            var careerInfo = await GetWhereExpressionAsync(o => o.CareerInfoId.Equals(careerInfoId));
            return careerInfo.DefaultIfEmpty(new CareerInfo())
                    .FirstOrDefault();
        }

        public async Task CreateCareerInfoAsync(CareerInfo careerInfo)
        {
            Add(careerInfo);
            await SaveDataAsync();
        }

        public async Task UpdateCareerInfoAsync(CareerInfo careerInfo)
        {
            Update(careerInfo);
            await SaveDataAsync();
        }

        public async Task DeleteCareerInfoAsync(CareerInfo careerInfo)
        {
            Delete(careerInfo);
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
