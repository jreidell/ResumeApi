using RdlNet2018.Common.Contracts;
using RdlNet2018.Data;

namespace RdlNet2018.Common.Repos
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RDL2018Context _context;
        private ICareerInfoRepository _careerInfo;

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

        public RepositoryWrapper(RDL2018Context context)
        {
            _context = context;
        }
    }
}
