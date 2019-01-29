using Microsoft.EntityFrameworkCore;
using RdlNet2018.Common.Contracts;
using RdlNet2018.Common.Models;
using RdlNet2018.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdlNet2018.Common.Repos
{
    public class AuthUserRepository : RepositoryBase<AuthUser>, IAuthUserRepository, IDisposable
    {
        protected RDL2018Context _context { get; set; }

        public AuthUserRepository(RDL2018Context context) : base(context)
        {
            this._context = context;
        }

        public Task<IEnumerable<AuthUser>> AuthLoginAsync(string uid, string pwd)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AuthUser>> GetAllAuthUsersAsync()
        {
            return await _context.AuthUser
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AuthUser> GetAuthUserByIdAsync(Guid authUserId)
        {
            var authUser = await GetWhereExpressionAsync(o => o.AuthUserId.Equals(authUserId));
            return authUser.DefaultIfEmpty(new AuthUser())
                    .FirstOrDefault();
        }

        public async Task CreateAuthUserAsync(AuthUser authUser)
        {
            Add(authUser);
            await SaveDataAsync();
        }

        public async Task DeleteAuthUserAsync(AuthUser authUser)
        {
            Delete(authUser);
            await SaveDataAsync();
        }

        public async Task UpdateAuthUserAsync(AuthUser authUser)
        {
            Update(authUser);
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
