using CarsRent.BL.Entities;
using System;
using System.Collections.Generic;

namespace CarsRent.BL.Word
{
    public class ReplaceRules
    {
        public Dictionary<string, string> ReplaceWords { get; private set; }

        public ReplaceRules(LandLord landLord, Renter renter, Car car)
        {
            var signature = $"{renter.Surname} {renter.Name[0]}.{renter.Patronymic[0]}.";

            ReplaceWords = new Dictionary<string, string>();

            ReplaceWords.Add("<ДАТА>", DateTime.Today.ToString("dd MMMM yyyy"));

            ReplaceWords.Add("<ПОДПИСЬ>", signature);
            ReplaceWords.Add("<АРЕНДОДАТЕЛЬ>", landLord.ToString());
            ReplaceWords.Add("<АРЕНДАТОР>", renter.ToString());

            ReplaceWords.Add("<МАРКА>", car.Brand);
            ReplaceWords.Add("<МОДЕЛЬ>", car.Model);
            ReplaceWords.Add("<РЕГ НОМЕР>", car.RegistrationNumber);
            ReplaceWords.Add("<VIN>", car.VIN);
            ReplaceWords.Add("<КУЗ НОМЕР>", car.BodyNumber);
            ReplaceWords.Add("<ДВИГ НОМЕР>", car.EngineNumber);
            ReplaceWords.Add("<ГОД ВЫПУСКА>", car.Year);
            ReplaceWords.Add("<ЦВЕТ>", car.Color);
            ReplaceWords.Add("<РАБ ОБЪЕМ ДВИГ>", car.EngineDisplacement);
            ReplaceWords.Add("<ЦЕНА>", car.Price.ToString());
            ReplaceWords.Add("<ДАТА ВЫД ПАСП>", car.PassportIssuingDate.ToString("dd.MMMM.yyyy"));
        }
    }
}