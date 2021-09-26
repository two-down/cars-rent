using System;
using System.IO;
using System.Xml.Serialization;

namespace CarsRent.BL.Settings
{
    public static class SettingsManager<T>
    {
        public static void Save(T settings)
        {
            var serializer = new XmlSerializer(typeof(T));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"//{settings.ToString()}.xml";
            var file = File.Create(path);
            serializer.Serialize(file, settings);
            file.Close();
        }

        public static T Load()
        {
            var serializer = new XmlSerializer(typeof(T));

            string fileName;

            if (typeof(T) == typeof(GlobalSettings))
                fileName = "global_settings";
            else if (typeof(T) == typeof(DefaultData))
                fileName = "default_data";
            else
                fileName = "unknown";

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"//{fileName}.xml";

            try
            {
                using (var streamReader = new StreamReader(path))
                    return (T)serializer.Deserialize(streamReader);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}