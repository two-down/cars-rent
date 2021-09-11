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
            throw new NotImplementedException();
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

            Query<Renter>.Insert(renter);
        }
    }
}