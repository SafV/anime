using AnimeContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EntityRepository<T> : IRepository<T>
        where T : class, IDomainObject
    {
        private AnimeDbContext<T> context;

        public EntityRepository()
        {
            context = new AnimeDbContext<T>();
        }

        public void Add(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            T item = context.Set<T>().Find(id);

            if (item != null)
            {
                context.Set<T>().Remove(item);
                context.SaveChanges();
            }
        }

        public List<T> ReadAll()
        {
            return context.Set<T>().AsNoTracking().ToList();
        }

        public T ReadById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
