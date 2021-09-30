using System.ComponentModel.DataAnnotations;

namespace CarsRent.BL.Validation
{
    public class MoneyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (double.TryParse(value.ToString(), out var price))
            {
                if (price > 0)
                    return true;
                else
                    ErrorMessage = "Введено число меньше нуля";
            }
            else
                ErrorMessage = "Введено не число";

            return false;
        }
    }
}