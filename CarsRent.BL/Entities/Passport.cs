using CarsRent.BL.Validators;
using System;

namespace CarsRent.BL.Entities
{
    public class Passport
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssuingOrganization { get; set; }
        public string RegistrationPlace { get; set; }

        public Passport(string name, string surname, string patronymic, string series, string number,
                        DateTime issueDate, string issuingOrganization, string registrationPlace)
        {
            var validationMessage = PassportValidator.Validate(name, surname, patronymic, series, number, 
                                                                issueDate, issuingOrganization, registrationPlace);

            if (string.IsNullOrWhiteSpace(validationMessage) == false)
                throw new Exception(validationMessage);

            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Series = series;
            Number = number;
            IssueDate = issueDate;
            IssuingOrganization = issuingOrganization;
            RegistrationPlace = registrationPlace;
        }

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic} паспорт: серия {Series} № {Number}, выданный" +
                $" {IssuingOrganization} {IssueDate}, проживающий(ая) по адресу: {RegistrationPlace}";
        }
    }
}