using CarsRent.BL.Entities;
using System.IO;
using CarsRent.BL.Settings;

namespace CarsRent.BL.Word
{
    public static class CreateDocument
    {
        public static void Create(LandLord landLord, Renter renter, string path)
        {
            CopySample(path);

            var doc = new Document(FileMode.Open, path);

            var rules = new ReplaceRules(landLord, renter);
            doc.Replace(rules.ReplaceWords);
        }

        private static void CopySample (string path)
        {
            using (var fs = new FileStream(GlobalSettings.SamplePath, FileMode.Open))
            {
                var fileStream = new FileStream(path, FileMode.Create);
                fs.CopyTo(fileStream);
                fileStream.Close();
            }
        }
    }
}