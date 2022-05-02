using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarsRent.BL.Entities
{
    public class LandLord : BaseEntity
    {
        [Required]
        public virtual Passport Passport { get; set; }

        public LandLord() { }

        public LandLord(string name, string surname, string patronymic, string series, string number,
                        string issueDate, string issuingOrganization, string registrationPlace)
        {
            Passport = new Passport(name, surname, patronymic, series, number, issueDate, issuingOrganization, registrationPlace);
        }

        public override string ToString()
        {
            return $"{Passport.Surname} {Passport.Name} {Passport.Patronymic} паспорт: серия {Passport.Series} № {Passport.Number}, выданный" +
                $" {Passport.IssuingOrganization} {Passport.IssueDate:dd.MM.yyyy}, проживающий(ая) по адресу: {Passport.RegistrationPlace}";
        }

        public override List<string> GetData()
        {
            var list = new List<string>();

            list.Add(Passport.Name);
            list.Add(Passport.Surname);
            list.Add(Passport.Patronymic);
            list.Add(Passport.Series);
            list.Add(Passport.Number);
            list.Add(Passport.IssueDate);
            list.Add(Passport.IssuingOrganization);
            list.Add(Passport.RegistrationPlace);

            return list;
        }
    }
}