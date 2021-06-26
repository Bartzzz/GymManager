using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.Data.Repositories
{
   public interface IBaseRepository<T> where T:new()
    {
        IEnumerable<T> GetEntities(string name);
        T Add(T entity);
        T GetById(int id);
        T Update(T updatedRestaurant);
        T Delete(int id);
    }
}
