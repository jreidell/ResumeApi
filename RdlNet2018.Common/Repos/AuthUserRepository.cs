using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RdlNet2018.Common.Contracts;
using RdlNet2018.Common.Models;
using RdlNet2018.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<TokenData> GetToken()
        {

            // CHECK THE ENVIRONMENT. IF WE ARE LOCAL TO DEV, GET SECRET VARS FROM MACHINE ELSE USE PROCESS (AZURE)
            EnvironmentVariableTarget envTarget = EnvironmentVariableTarget.Process;
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", envTarget).Equals("Development", StringComparison.InvariantCultureIgnoreCase))
            {
                envTarget = EnvironmentVariableTarget.Machine;
            }

            var client_id = Environment.GetEnvironmentVariable("rdn_Client_id", envTarget);
            var client_secret = Environment.GetEnvironmentVariable("rdn_Client_secret", envTarget);
            var audience = Environment.GetEnvironmentVariable("rdn_Audience", envTarget);
            var grant_type = Environment.GetEnvironmentVariable("rdn_Grant_type", envTarget);
            var UrlNoTrailingSlash = Environment.GetEnvironmentVariable("rdn_UrlNoTrailingSlash", envTarget);

            var client = new RestClient($"{UrlNoTrailingSlash}/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody($"{{ \"client_id\":\"{client_id}\",\"client_secret\":\"{ client_secret}\",\"audience\":\"{audience}\",\"grant_type\":\"{grant_type}\" }}");
            IRestResponse response = client.Execute(request);
            TokenData token = JsonConvert.DeserializeObject<TokenData>(response.Content);

            return await Task.Run(() =>
                token
            );
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
