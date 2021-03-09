using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VactionApi.Data
{
    public interface IRepositry<TEntity>
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> List();

        Task Update(TEntity T);
        Task<int> DeleteEntity(TEntity T);
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
