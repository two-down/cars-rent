using CarsRent.BL.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarsRent.BL.Entities
{
    public class Passport : BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя пользователя не введено")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия пользователя не введена")]
        public string Surname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Отчество пользователя не введено")]
        public string Patronymic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Серия паспорта не введена")]
        public string Series { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Номер паспорта не введен")]
        public string Number { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Дата выдачи паспорта не введена")]
        [Date]
        //[RegularExpression("^([0]?[1-9]|[1][0-2])[./-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0-9]{4}|[0-9]{2})$",
        //    ErrorMessage = "Не корректная дата выдачи паспорта")]
        public string IssueDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Организация, выдавшая паспорт не введена")]
        public string IssuingOrganization { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Место регистрации пользователя не введено")]
        public string RegistrationPlace { get; set; }

        public Passport (string name, string surname, string patronymic, string series, string number,
                        string issueDate, string issuingOrganization, string registrationPlace)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Series = series;
            Number = number;
            IssueDate = issueDate;
            IssuingOrganization = issuingOrganization;
            RegistrationPlace = registrationPlace;
        }

        public override List<string> GetData()
        {
            return new List<string>();
        }
    }
}