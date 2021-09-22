using Microsoft.EntityFrameworkCore;
using Phusion2.Domain.Core.Models;
using Phusion2.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Phusion2.Infra.Extensions;

namespace Phusion2.Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext Context;
        private const int TakeMax = 100;

        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> GetQueryable(
            Expression<Func<TEntity, bool>> filter = null, 
            int? skip = null, 
            int? take = null, 
            string orderBy = null, 
            string includeProps = null, 
            bool asNoTracking = true)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                query = query.OrderBy(orderBy);
            }

            if (!string.IsNullOrWhiteSpace(includeProps))
            {
                query = includeProps.Split(',', StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (q, p) => q.Include(p));
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue && take.Value > 0)
            {
                query = query.Take(take.Value);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            int? skip = null, 
            int? take = null, 
            string orderBy = null, 
            string includeProps = null, 
            bool asNoTracking = true)
        {
            return await GetQueryable(filter, skip, take ?? TakeMax, orderBy, includeProps, asNoTracking).ToListAsync();
        }

        public virtual async Task<TEntity> GetOneAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProps = null,
            bool asNoTracking = true)
        {
            return await GetQueryable(filter, null, null, null, includeProps, asNoTracking).SingleOrDefaultAsync();
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await GetQueryable(filter).CountAsync();
        }

        public TEntity Create(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var entry = Context.Set<TEntity>().Update(entity);
            return entry.Entity;
        }

        public TEntity DeleteById(object id)
        {
            var entity = Context.Set<TEntity>().Find(id);
            if (entity == null)
                return null;
            else
            {
                var dbSet = Context.Set<TEntity>();
                if (Context.Entry(entity).State == EntityState.Detached)
                    dbSet.Attach(entity);
                return dbSet.Remove(entity).Entity;
            }
        }
    }
}
