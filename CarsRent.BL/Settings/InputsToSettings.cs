using CarsRent.BL.BDRequests;
using CarsRent.BL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CarsRent.BL.Settings
{
    public static class InputsToSettings
    {
        public static void ConvertAndSave(SettingsTypes settingsType, List<object> inputs)
        {
            switch (settingsType)
            {
                case SettingsTypes.GENERAL:
                    SaveGeneral(inputs);
                    break;

                case SettingsTypes.DEFAULT_DATA:
                    SaveDefaultData(inputs);
                    break;

                default:
                    break;
            }
        }

        private static void SaveDefaultData(List<object> inputs)
        {
            var name = inputs[0].ToString();
            var surname = inputs[1].ToString();
            var patronymic = inputs[2].ToString();
            var series = inputs[3].ToString();
            var number = inputs[4].ToString();
            var issueDate = inputs[5].ToString();
            var issuingOrganization = inputs[6].ToString();
            var registrationPlace = inputs[7].ToString();

            var landlord = Query<LandLord>.SelectAll().FirstOrDefault();


            // TODO: Переделать нормально.
            if (landlord != null)
                Query<LandLord>.Delete(landlord);

            landlord = new LandLord(name, surname, patronymic, series, number, issueDate, issuingOrganization, registrationPlace);
            Query<LandLord>.Insert(landlord);
        }

        private static void SaveGeneral(List<object> inputs)
        {
            var actPath = inputs[0].ToString();
            var contactPath = inputs[1].ToString();
            var notificationPath = inputs[2].ToString();

            var settings = new GlobalSettings(actPath, contactPath, notificationPath);

            SettingsManager<GlobalSettings>.Save(settings);
        }
    }
}