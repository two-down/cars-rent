using System;

namespace CarsRent.BL.Settings
{
    [Serializable]
    public class GlobalSettings
    {
        public string SampleActPath { get; set; }
        public string SampleContractPath { get; set; }
        public string SampleNotificationPath { get; set; }

        public GlobalSettings() { }

        public override string ToString()
        {
            return "global_settings";
        }
    }
}