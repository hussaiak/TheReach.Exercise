using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheReach.Exercise.DataModel;

namespace TheReach.Exercise.Repository.DBRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
