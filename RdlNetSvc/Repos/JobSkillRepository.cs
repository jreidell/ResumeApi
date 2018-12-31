using RdlNetSvc.Common.Contracts;
using RdlNetSvc.Common.Models;
using RdlNetSvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RdlNetSvc.Common.Repos
{
    public class JobSkillRepository : RepositoryBase<JobSkill>, IJobSkillRepository, IDisposable
    {
        protected RDL2018Context _context { get; set; }

        public JobSkillRepository(RDL2018Context context) : base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<JobSkill>> GetAllJobSkillItemsAsync()
        {
            var jobSkillItems = await GetAllAsync();
            return jobSkillItems;
        }

        public async Task<JobSkill> GetJobSkillByIdAsync(Guid jobSkillId)
        {
            var jobSkill = await GetWhereExpressionAsync(o => o.JobSkillId.Equals(jobSkillId));
            return jobSkill.DefaultIfEmpty(new JobSkill())
                    .FirstOrDefault();
        }

        public async Task CreateJobSkillAsync(JobSkill jobSkill)
        {
            Add(jobSkill);
            await SaveDataAsync();
        }

        public async Task UpdateJobSkillAsync(JobSkill jobSkill)
        {
            Update(jobSkill);
            await SaveDataAsync();
        }

        public async Task DeleteJobSkillAsync(JobSkill jobSkill)
        {
            Delete(jobSkill);
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
