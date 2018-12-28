using RdlNet2018.Data;

namespace RdlNet2018.Common.Contracts
{
    public interface IRepositoryWrapper
    {
        ICareerInfoRepository CareerInfo { get; }
        IJobSkillRepository JobSkill { get; }
        IWorkHistoryRepository WorkHistory { get; }
        IWorkHistoryDetailRepository WorkHistoryDetail { get; }
        void Save();

    }
}
