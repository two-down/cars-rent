using CarsRent.BL.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarsRent.BL.Validation
{
    public class ValidationHelper<T> where T : BaseEntity
    {
        public string Error { get; private set; }

        public bool Validate(T item)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(item);
            if (!Validator.TryValidateObject(item, validationContext, results, true))
            {
                Error = results.First().ErrorMessage;
                return false;
            }

            return true;
        }
    }
}