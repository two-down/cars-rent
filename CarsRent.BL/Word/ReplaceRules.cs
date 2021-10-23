using CarsRent.BL.Entities;
using System;
using System.Collections.Generic;

namespace CarsRent.BL.Word
{
    public class ReplaceRules
    {
        public Dictionary<string, string> ReplaceWords { get; private set; }

        public ReplaceRules(Contract contract)
        {
            var renter = contract.Renter;
            var landLord = contract.LandLord;
            var car = contract.Car;

            var renterSignature = $"{renter.Passport.Surname} {renter.Passport.Name[0]}.{renter.Passport.Patronymic[0]}.";
            var landlordSignature = $"{landLord.Passport.Surname} {landLord.Passport.Name[0]}.{landLord.Passport.Patronymic[0]}.";

            ReplaceWords = new Dictionary<string, string>();

            ReplaceWords.Add("<ДАТА>", DateTime.Today.ToString("dd MMMM yyyy"));

            ReplaceWords.Add("<ПОДПИСЬ АРЕНДАТОРА>", renterSignature);
            ReplaceWords.Add("<ПОДПИСЬ АРЕНДОДАТЕЛЯ>", landlordSignature);
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
            ReplaceWords.Add("<ДАТА ВЫД ПАСП>", car.PassportIssuingDate);

            ReplaceWords.Add("<ДАТА ЗАКОЮЧЕНИЯ ДОГОВОРА>", contract.ConclusionDate);
            ReplaceWords.Add("<ДАТА ОКОНЧАНИЯ ДОГОВОРА>", contract.EndDate);
            ReplaceWords.Add("<НОМЕР ДОГОВОРА>", contract.Id.ToString());
            ReplaceWords.Add("<ЦЕНА ПОЕЗДКИ>", contract.RidePrice);

            var rideType = "";

            if (contract.RideType == RideType.InTheCity)
                rideType = "по городу";
            else
                rideType = "за городом";

            ReplaceWords.Add("<ТИП ПОЕЗДКИ>", rideType);
        }
    }
}