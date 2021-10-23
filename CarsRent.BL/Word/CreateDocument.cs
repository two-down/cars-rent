using CarsRent.BL.Entities;
using System.IO;
using CarsRent.BL.Settings;

namespace CarsRent.BL.Word
{
    public static class CreateDocument
    {
        public static void Create(Contract contract, string path)
        {
            var renter = contract.Renter;
            var car = contract.Car;

            var signature = $"{renter.Passport.Surname} {renter.Passport.Name}.{renter.Passport.Patronymic}.";

            var actPath = $"{path}/АКТ {car.Brand} {car.Model} {signature}";
            var dogPath = $"{path}/ДОГОВОР {car.Brand} {car.Model} {signature}";
            var notifPath = $"{path}/УВЕДОМЛЕНИЕ";

            var globalSettings = new GlobalSettings();
            CopySample(actPath, globalSettings.SampleActPath);
            CopySample(dogPath, globalSettings.SampleContractPath);
            CopySample(notifPath, globalSettings.SampleNotificationPath);

            var doc = new Document(FileMode.Open, actPath);

            var rules = new ReplaceRules(contract);
            doc.Replace(rules.ReplaceWords);

            doc = new Document(FileMode.Open, dogPath);

            rules = new ReplaceRules(contract);
            doc.Replace(rules.ReplaceWords);

            doc = new Document(FileMode.Open, notifPath);

            rules = new ReplaceRules(contract);
            doc.Replace(rules.ReplaceWords);
        }

        private static void CopySample (string destPath, string samplePath)
        {
            using (var fs = new FileStream(samplePath, FileMode.Open))
            {
                var fileStream = new FileStream(destPath, FileMode.Create);
                fs.CopyTo(fileStream);
                fileStream.Close();
            }
        }
    }
}