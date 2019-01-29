using RdlNet2018.Common.Contracts;
using RdlNet2018.Data;
using System;

namespace RdlNet2018.Common.Repos
{
    public class RepositoryWrapper : IRepositoryWrapper, IDisposable
    {
        private bool disposed = false;
        private RDL2018Context _context;
        private ICareerInfoRepository _careerInfo;
        private IJobSkillRepository _jobSkill;
        private IWorkHistoryRepository _workHistory;
        private IWorkHistoryDetailRepository _workHistoryDetail;
        private IAuthUserRepository _authUser;

        public ICareerInfoRepository CareerInfo
        {
            get
            {
                if (_careerInfo == null)
                {
                    _careerInfo = new CareerInfoRepository(_context);
                }

                return _careerInfo;
            }
        }

        public IJobSkillRepository JobSkill
        {
            get
            {
                if (_jobSkill == null)
                {
                    _jobSkill = new JobSkillRepository(_context);
                }

                return _jobSkill;
            }
        }


        public IWorkHistoryRepository WorkHistory
        {
            get
            {
                if (_workHistory == null)
                {
                    _workHistory = new WorkHistoryRepository(_context);
                }

                return _workHistory;
            }
        }


        public IWorkHistoryDetailRepository WorkHistoryDetail
        {
            get
            {
                if (_workHistoryDetail == null)
                {
                    _workHistoryDetail = new WorkHistoryDetailRepository(_context);
                }

                return _workHistoryDetail;
            }
        }

        public IAuthUserRepository AuthUser
        {
            get
            {
                if (_authUser == null)
                {
                    _authUser = new AuthUserRepository(_context);
                }

                return _authUser;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public RepositoryWrapper(RDL2018Context context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
