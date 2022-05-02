using System;
using System.ComponentModel.DataAnnotations;

namespace CarsRent.BL.Validation
{
    public class DateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (DateTime.TryParse(value.ToString(), out var dateTime))
                return true;
                
            ErrorMessage = "Введена не дата";
            return false;
        }
    }
}