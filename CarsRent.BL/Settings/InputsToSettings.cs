using System.Collections.Generic;

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

                default:
                    break;
            }
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