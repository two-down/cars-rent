using System;
using System.IO;

namespace CarsRent.BL.Settings
{
    [Serializable]
    public class GlobalSettings
    {
        public string SampleActPath { get; set; }
        public string SampleContractPath { get; set; }
        public string SampleNotificationPath { get; set; }

        public GlobalSettings() { }

        public GlobalSettings(string sampleActPath, string sampleContractPath, string sampleNotificationPath)
        {
            if (File.Exists(sampleActPath) == false)
                throw new FileNotFoundException("Не удалось найти акт в указанном пути.");
            if (File.Exists(sampleContractPath) == false)
                throw new FileNotFoundException("Не удалось найти договор в указанном пути.");
            if (File.Exists(sampleNotificationPath) == false)
                throw new FileNotFoundException("Не удалось найти уведомление в указанном пути.");

            SampleActPath = sampleActPath;
            SampleContractPath = sampleContractPath;
            SampleNotificationPath = sampleNotificationPath;
        }

        public override string ToString()
        {
            return "global_settings";
        }
    }
}