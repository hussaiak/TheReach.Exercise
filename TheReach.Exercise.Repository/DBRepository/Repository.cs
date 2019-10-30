using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheReach.Exercise.DataModel;

namespace TheReach.Exercise.Repository.DBRepository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationContext context)
        {
            this.context = context; 
            entities = context.Set<T>();
        }
        public Task<IEnumerable<T>> GetAll()
        {
            return Task.FromResult(entities.AsEnumerable());
        } 
        public Task<T> Get(long id)
        {
            return Task.FromResult(entities.SingleOrDefault(s => s.Id == id));
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                //Log Error
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                //Log Error
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                //Log Error
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                //Log Error
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
