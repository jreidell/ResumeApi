using Microsoft.EntityFrameworkCore;
using RdlNet2018.Common.Contracts;
using RdlNet2018.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RdlNet2018.Common.Repos
{
    /// <summary>
    /// Concreate implementation of the Repository Base Interface
    /// </summary>
    /// <typeparam name="T">Generic Type to allow management of any Entity</typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        protected RDL2018Context _repositoryContext { get; set; }

        public RepositoryBase(RDL2018Context repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public void Add(T entity)
        {
            this._repositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this._repositoryContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._repositoryContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhereExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await this._repositoryContext.Set<T>().Where(expression).ToListAsync();
        }

        public void Update(T entity)
        {
            this._repositoryContext.Set<T>().Update(entity);
        }

        public async Task SaveDataAsync()
        {
            await this._repositoryContext.SaveChangesAsync();
        }
    }
}
