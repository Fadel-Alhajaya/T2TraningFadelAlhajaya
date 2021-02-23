using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vacation_System.Models;

namespace VactionApi.Data
{
    public  interface IRepositry <TEntity>
    {
        Task<TEntity> AddEntity(TEntity t );
        Task<bool> EntityExists(TEntity t);
    //    Task<bool> CheckEntity(TEntity t, int id);
        Task<TEntity> FindEntity(TEntity t);
        TEntity GetEntity(int id);
        Task<IList<TEntity>> GetAllEntity();
         Task  Update(TEntity T);
         Task<int> DeleteEntity(int myID);







    }
}
