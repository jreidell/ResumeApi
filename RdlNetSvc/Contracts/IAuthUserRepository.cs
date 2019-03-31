using RdlNetSvc.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNetSvc.Common.Contracts
{
    public interface IAuthUserRepository : IDisposable
    {
        Task<IEnumerable<AuthUser>> AuthLoginAsync(string uid, string pwd);
        Task<IEnumerable<AuthUser>> GetAllAuthUsersAsync();
        Task<AuthUser> GetAuthUserByIdAsync(Guid authUserId);
        Task CreateAuthUserAsync(AuthUser authUser);
        Task UpdateAuthUserAsync(AuthUser authUser);
        Task DeleteAuthUserAsync(AuthUser authUser);
    }
}
