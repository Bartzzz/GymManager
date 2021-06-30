using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.Data.Repositories
{
   public interface IBaseRepository<T> where T:new()
    {
        IEnumerable<T> GetEntities(int id = 0);
        T Add(T entity);
        T GetById(int id);
        T Update(T updatedEntity);
        T Delete(int id);
    }
}
