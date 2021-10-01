using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CarsRent.BL.Validation
{
    public class DateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (double.TryParse(value.ToString(), out var dateTime))
            {
                var reg = new Regex(@"\d{2}.\d{2}.\d{4}");
                var match = reg.Match(value.ToString());

                if (match.Success == true)
                    return true;
                else
                    ErrorMessage = "Неверный формат даты";
            }
            else
                ErrorMessage = "Введена не дата";

            return false;
        }
    }
}