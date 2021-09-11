using CarsRent.BL.Validators;
using System;
using System.Collections.Generic;

namespace CarsRent.BL.Entities
{
    public class LandLord : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssuingOrganization { get; set; }
        public string RegistrationPlace { get; set; }

        public LandLord() { }

        public LandLord(string name, string surname, string patronymic, string series, string number,
                        string issueDate, string issuingOrganization, string registrationPlace)
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
            IssueDate = DateTime.Parse(issueDate);
            IssuingOrganization = issuingOrganization;
            RegistrationPlace = registrationPlace;
        }

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic} паспорт: серия {Series} № {Number}, выданный" +
                $" {IssuingOrganization} {IssueDate:dd.MM.yyyy}, проживающий(ая) по адресу: {RegistrationPlace}";
        }

        public override List<string> GetData()
        {
            var list = new List<string>();

            list.Add(Name);
            list.Add(Surname);
            list.Add(Patronymic);
            list.Add(Series);
            list.Add(Number);
            list.Add(IssueDate.ToString());
            list.Add(IssuingOrganization);
            list.Add(RegistrationPlace);

            return list;
        }
    }
}