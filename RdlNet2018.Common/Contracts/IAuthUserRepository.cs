﻿using RdlNet2018.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNet2018.Common.Contracts
{
    public interface IAuthUserRepository : IDisposable
    {
        Task<IEnumerable<AuthUser>> AuthLoginAsync(string uid, string pwd);
        Task<IEnumerable<AuthUser>> GetAllAuthUsersAsync();
        Task<AuthUser> GetAuthUserByIdAsync(Guid authUserId);
        Task CreateAuthUserAsync(AuthUser careerInfo);
        Task UpdateAuthUserAsync(AuthUser careerInfo);
        Task DeleteAuthUserAsync(AuthUser careerInfo);
        Task<TokenData> GetToken();
    }
}
