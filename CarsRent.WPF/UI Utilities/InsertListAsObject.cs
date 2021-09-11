using CarsRent.BL.BDRequests;
using CarsRent.BL.Entities;
using System;
using System.Collections.Generic;

namespace CarsRent.WPF.UI_Utilities
{
    public static class InsertListAsObject
    {
        public static void Insert(List<string> list, string objectType)
        {
            switch (objectType)
            {
                case "renters":
                    InsertRenters(list);
                    break;

                case "cars":
                    InsertCars(list);
                    break;
            }
        }

        private static void InsertCars(List<string> list)
        {
            var brand = list[0];
            var model = list[1];
            var color = list[2];
            var year = list[3];
            var passportSeries = list[4];
            var passportNumber = list[5];
            var vin = list[6];
            var bodyNumber = list[7];
            var registrationNumber = list[8];
            var engineNumber = list[9];
            var engineDisplacement = list[10];
            var price = list[11];
            var passportIssuingDate = list[12];

            var car = new Car(brand, model, color, year, passportSeries, passportNumber, vin, bodyNumber, registrationNumber, engineNumber, 
                engineDisplacement, price, passportIssuingDate);

            if (list.Count == 14)
            {
                car.Id = long.Parse(list[13]);
                Query<Car>.Update(car);
            }
            else
            {
                Query<Car>.Insert(car);
            }
        }

        private static void InsertRenters(List<string> list)
        {
            var name = list[0];
            var surname = list[1];
            var patronymic = list[2];
            var series = list[3];
            var number = list[4];
            var issueDate = list[5];
            var issuingOrganization = list[6];
            var registrationPlace = list[7];

            var renter = new Renter(name, surname, patronymic, series, number, issueDate, issuingOrganization, registrationPlace);

            if (list.Count == 9)
            {
                renter.Id = long.Parse(list[8]);
                Query<Renter>.Update(renter);
            }
            else
            {
                Query<Renter>.Insert(renter);
            }
        }
    }
}