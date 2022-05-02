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
        public string OutputFolder { get; set; }
        public string ReplaceWordsPath { get; set; }

        public GlobalSettings() { }

        public GlobalSettings(string sampleActPath, string sampleContractPath, string sampleNotificationPath, string outputFolder,
                                string replaceWordsPath)
        {
            if (File.Exists(sampleActPath) == false)
                throw new FileNotFoundException("Не удалось найти акт в указанном пути.");
            if (File.Exists(sampleContractPath) == false)
                throw new FileNotFoundException("Не удалось найти договор в указанном пути.");
            if (File.Exists(sampleNotificationPath) == false)
                throw new FileNotFoundException("Не удалось найти уведомление в указанном пути.");
            if (Directory.Exists(outputFolder) == false)
                throw new FileNotFoundException("Не удалось найти папку для результатов работы программы в указанном пути.");
            if (File.Exists(replaceWordsPath) == false)
                throw new FileNotFoundException("Не удалось найти список слов для замены по шаблону.");

            SampleActPath = sampleActPath;
            SampleContractPath = sampleContractPath;
            SampleNotificationPath = sampleNotificationPath;
            OutputFolder = outputFolder;
            ReplaceWordsPath = replaceWordsPath;
        }

        public override string ToString()
        {
            return "global_settings";
        }
    }
}