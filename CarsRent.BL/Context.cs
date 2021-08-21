using CarsRent.BL.Entities;
using System.Data.Entity;

namespace CarsRent.BL
{
    public class Context : DbContext
    {
        public Context() : base("carsRent") { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }
    }
}