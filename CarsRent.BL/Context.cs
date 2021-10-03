using CarsRent.BL.Entities;
using System.Data.Entity;
using System.Linq;

namespace CarsRent.BL
{
    public class Context : DbContext
    {
        public static Context context;

        private Context() : base("carsRent") { }

        public static Context GetContext()
        {
            if (context == null)
                context = new Context();

            return context;
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Passport> Passports { get; set; }

        public IQueryable<T> GetDataSet<T>() where T : class
        {
            return Set<T>();
        }
    }
}