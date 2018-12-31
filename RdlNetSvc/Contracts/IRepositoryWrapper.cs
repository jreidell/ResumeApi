using RdlNetSvc.Data;

namespace RdlNetSvc.Common.Contracts
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
