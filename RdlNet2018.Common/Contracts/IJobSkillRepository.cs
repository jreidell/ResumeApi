using RdlNet2018.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNet2018.Common.Contracts
{
    public interface IJobSkillRepository
    {
        Task<IEnumerable<JobSkill>> GetAllJobSkillItemsAsync();
        Task<JobSkill> GetJobSkillByIdAsync(Guid jobSkillId);
        Task CreateJobSkillAsync(JobSkill jobSkill);
        Task UpdateJobSkillAsync(JobSkill jobSkill);
        Task DeleteJobSkillAsync(JobSkill jobSkill);

    }
}
