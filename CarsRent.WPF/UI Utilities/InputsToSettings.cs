using CarsRent.BL.BDRequests;
using CarsRent.BL.Entities;
using CarsRent.BL.Settings;
using CarsRent.BL.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CarsRent.WPF.UI_Utilities
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

            if (landlord != null)
            {
                landlord.Passport.Name = name;
                landlord.Passport.Surname = surname;
                landlord.Passport.Patronymic = patronymic;
                landlord.Passport.Series = series;
                landlord.Passport.Number = number;
                landlord.Passport.IssueDate = issueDate;
                landlord.Passport.IssuingOrganization = issuingOrganization;
                landlord.Passport.RegistrationPlace = registrationPlace;

                var validator = new ValidationHelper<Passport>();

                if (validator.Validate(landlord.Passport) == true)
                    Query<LandLord>.Update(landlord);
                else
                    MessageBox.Show(validator.Error, "Ошибка валидации");
            }
            else
            {
                landlord = new LandLord(name, surname, patronymic, series, number, issueDate, issuingOrganization, registrationPlace);

                var validator = new ValidationHelper<Passport>();

                if (validator.Validate(landlord.Passport) == true)
                    Query<LandLord>.Insert(landlord);
                else
                    MessageBox.Show(validator.Error, "Ошибка валидации");
            }
        }

        private static void SaveGeneral(List<object> inputs)
        {
            var actPath = inputs[0].ToString();
            var contactPath = inputs[1].ToString();
            var notificationPath = inputs[2].ToString();
            var outputFolder = inputs[3].ToString();
            var replaceWords = inputs[4].ToString();

            var settings = new GlobalSettings(actPath, contactPath, notificationPath, outputFolder, replaceWords);

            SettingsManager<GlobalSettings>.Save(settings);
        }
    }
}