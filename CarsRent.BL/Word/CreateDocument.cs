using CarsRent.BL.Entities;
using System.IO;
using CarsRent.BL.Settings;
using System;

namespace CarsRent.BL.Word
{
    public static class CreateDocument
    {
        public static void Create(LandLord landLord, Renter renter, string path)
        {
            CopySample(path);

            //var doc = new Document(FileMode.Open, path);

            //var car = new Car("Toyota", "Kamri", "Белая", "2004", "FAAA", "8319321", "ОТСУТСТВУЕТ", "SDSDD", "12345",
            //    "sdadasdasd", "123 00 DT", 25000, DateTime.Today);

            //var rules = new ReplaceRules(landLord, renter, car);
            //doc.Replace(rules.ReplaceWords);
        }

        private static void CopySample (string path)
        {
            //using (var fs = new FileStream(GlobalSettings.SampleActPath, FileMode.Open))
            //{
            //    var fileStream = new FileStream(path, FileMode.Create);
            //    fs.CopyTo(fileStream);
            //    fileStream.Close();
            //}
        }
    }
}