using System;
using System.IO;
using System.Xml.Serialization;

namespace CarsRent.BL.Settings
{
    public static class SettingsView<T>
    {
        public static T GetSettings(string fileName)
        {
            var serializer = new XmlSerializer(typeof(T));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"//{fileName}.xml";
            var file = File.Create(path);

            var settings = (T)serializer.Deserialize(file);
            file.Close();

            return settings;
        }

        public static void SaveSettings(T settings)
        {
            var serializer = new XmlSerializer(typeof(T));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"//{settings}.xml";
            var file = File.Create(path);

            serializer.Serialize(file, settings);

            file.Close();
        }
    }
}