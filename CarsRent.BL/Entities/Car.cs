using CarsRent.BL.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarsRent.BL.Entities
{
    public class Car : BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Марка машины не введена")]
        public string Brand { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Модель машины не введена")]
        public string Model { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Цвет машины не введен")]
        public string Color { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Год выпуска машины не введен")]
        [RegularExpression(@"^(19|20)\d{2}$", ErrorMessage = "Не корректная год выпуска машины")]
        public string Year { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Серия паспорта машины не введена")]
        public string PassportSeries { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Номер паспорта машины не введен")]
        public string PassportNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "VIN машины не введен")]
        public string VIN { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Номер кузова машины не введен")]
        public string BodyNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Номер регистрации машины не введен")]
        public string RegistrationNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Номер двигателя машины не введен")]
        public string EngineNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Рабочий объем двигателя машины не введен")]
        public string EngineDisplacement { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Стоимость машины не введена")]
        [Money]
        public string Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Дата выдачи паспорта не введена")]
        [RegularExpression("^([0]?[1-9]|[1][0-2])[./-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0-9]{4}|[0-9]{2})$",
            ErrorMessage = "Не корректная дата выдачи паспорта")]
        public string PassportIssuingDate { get; set; }

        public Car() { }

        public Car(string brand, string model, string color, string year,
            string passportSeries, string passportNumber, string vin,
            string bodyNumber, string registrationNumber, string engineNumber,
            string engineDisplacement, string price, string passportIssuingDate)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Year = year;
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
            VIN = vin;
            BodyNumber = bodyNumber;
            RegistrationNumber = registrationNumber;
            EngineNumber = engineNumber;
            EngineDisplacement = engineDisplacement;
            Price = price;
            PassportIssuingDate = passportIssuingDate;
        }

        public override string ToString()
        {
            return $"{Brand} {Model} {Color} паспорт: серия {PassportSeries} № {PassportNumber}";
        }

        public override List<string> GetData()
        {
            var list = new List<string>();

            list.Add(Brand);
            list.Add(Model);
            list.Add(Color);
            list.Add(Year);
            list.Add(PassportSeries);
            list.Add(PassportNumber);
            list.Add(VIN);
            list.Add(BodyNumber);
            list.Add(RegistrationNumber);
            list.Add(EngineNumber);
            list.Add(EngineDisplacement);
            list.Add(Price.ToString());
            list.Add(PassportIssuingDate);

            return list;
        }
    }
}