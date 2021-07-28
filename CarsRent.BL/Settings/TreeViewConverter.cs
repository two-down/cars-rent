using System.Collections.Generic;

namespace CarsRent.BL.Settings
{
    public static class TreeViewConverter
    {
        public static Dictionary<string, SettingsTypes> SettingsTypesToString = new Dictionary<string, SettingsTypes>()
        {
            { "Основные настройки", SettingsTypes.GENERAL }
        };
    }

    public enum SettingsTypes
    {
        GENERAL,
    }
}