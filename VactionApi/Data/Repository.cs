using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vacation_System.Models;

namespace VactionApi.Data
{
    public class Repository<TEntity> : IRepositry<TEntity>
        where TEntity : class
    {
        //private readonly DbSet<TEntity> entities;
        private readonly DataContext dbContext;

        public Repository(DataContext dbContext)
        {
            this.dbContext = dbContext;
            //this.entities = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var result = await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbContext.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }
        public async Task<List<TEntity>> List()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }

       

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbContext.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task Update(TEntity T)
        {
            dbContext.Set<TEntity>().Update(T);
            await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteEntity(TEntity T)
        {
            int result = 0;

            if (T != null)
            {
                dbContext.Remove(T);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
