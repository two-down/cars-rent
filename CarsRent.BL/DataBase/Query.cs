using CarsRent.BL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CarsRent.BL.BDRequests
{
    public static class Query<T> where T : BaseEntity
    {
        public static void Insert(T item)
        {
            using (var context = new Context())
            {
                context.Entry(item).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static void Update(T item)
        {
            using (var context = new Context())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(T item)
        {
            using (var context = new Context())
            {
                context.Entry(item).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static List<T> SelectAll()
        {
            using (var context = new Context())
                return context.DbSet<T>().ToList();
        }

        public static T SelectById(long id)
        {
            using (var context = new Context())
                return context.DbSet<T>().Where(item => item.Id == id).FirstOrDefault();
        }
    }
}