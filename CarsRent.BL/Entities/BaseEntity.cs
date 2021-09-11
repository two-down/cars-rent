using System.Collections.Generic;

namespace CarsRent.BL.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public abstract List<string> GetData();
    }
}