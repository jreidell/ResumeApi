using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RdlNet2018.Contracts
{
    public interface IRepositoryWrapper
    {
        ICareerInfoRepository CareerInfo { get; }
    }
}
