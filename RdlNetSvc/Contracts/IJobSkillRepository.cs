using RdlNetSvc.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNetSvc.Common.Contracts
{
    public interface IJobSkillRepository : IDisposable
    {
        Task<IEnumerable<JobSkill>> GetAllJobSkillItemsAsync();
        Task<JobSkill> GetJobSkillByIdAsync(Guid jobSkillId);
        Task CreateJobSkillAsync(JobSkill jobSkill);
        Task UpdateJobSkillAsync(JobSkill jobSkill);
        Task DeleteJobSkillAsync(JobSkill jobSkill);

    }
}
