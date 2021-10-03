using CarsRent.BL.Entities;
using CarsRent.BL.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarsRentTests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void RenterValidationTest()
        {
            var name = "Максим";
            var surname = "Бабаков";
            var patronymic = "Максимович";
            string series = "5017";
            string number = "876654";
            string issueDate = "11.09.2012";
            string issuingOrganization = "УВД ЛЕНИНСКОГО РАЙОНА ГОРОДА НОВОСИБИРСКА";
            string registrationPlace = "г. Новосибирск ул. Большая 336";

            var renter = new Renter(name, surname, patronymic, series, number, issueDate, issuingOrganization, registrationPlace);

            var validator = new ValidationHelper<Passport>();

            Assert.IsTrue(validator.Validate(renter.Passport));

            renter.Passport.IssueDate = "1.2.2021";

            Assert.IsFalse(validator.Validate(renter.Passport));

            renter.Passport.Name = "";

            Assert.IsFalse(validator.Validate(renter.Passport));
        }
    }
}