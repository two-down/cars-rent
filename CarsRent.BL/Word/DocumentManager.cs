using CarsRent.BL.Entities;
using CarsRent.BL.Settings;
using System.Collections.Generic;
using TemplateDocs.LIB;

namespace CarsRent.BL.Word
{
    public static class DocumentManager
    {
        public static void CreateDocuments(Contract contract)
        {
            var car = contract.Car;
            var renter = contract.Renter;
            var landLord = contract.LandLord;

            var replaceWords = CreateReplaceWords(car, renter, landLord, contract);
            var name = CreateDocumentName(car, renter);

            var settings = SettingsManager<GlobalSettings>.Load();

            ReplaceWordsInDocument(settings.SampleActPath, replaceWords, $"ACT {name}.docx", settings.OutputFolder);
            ReplaceWordsInDocument(settings.SampleContractPath, replaceWords, $"CONTRACT {name}.docx", settings.OutputFolder);
            ReplaceWordsInDocument(settings.SampleNotificationPath, replaceWords, $"NOTIFICATION {name}.docx", settings.OutputFolder);
        }

        private static ReplaceWords CreateReplaceWords(Car car, Renter renter, LandLord landlord, Contract contract)
        {
            var words = new Dictionary<string, string>();

            words.Add("<АРЕНДОДАТЕЛЬ>", landlord.ToString());
            words.Add("<ДАТА>", contract.ConclusionDate);
            words.Add("<АРЕНДАТОР>", renter.ToString());
            words.Add("<АВТОМОБИЛЬ>", car.ToString());
            words.Add("<ЦЕНА>", car.Price);
            words.Add("<ЦЕНА БУКВАМИ>", "ПОКА ПУСТО");
            words.Add("<НОМЕР ДОГОВОРА>", contract.Id.ToString());
            words.Add("<ВНЕШНИЕ ДЕФФЕКТЫ>", "ПОКА ПУСТО");
            words.Add("<ПОДПИСЬ АРЕНДАТОРА>", $"{renter.Passport.Surname} {renter.Passport.Name[0]}.{renter.Passport.Patronymic[0]}.");
            words.Add("<ПОДПИСЬ АРЕНДОДАТЕЛЯ>", $"{landlord.Passport.Surname} {landlord.Passport.Name[0]}.{landlord.Passport.Patronymic[0]}.");
            words.Add("<ЦЕНА ПОЕЗДКИ>", contract.RidePrice);
            words.Add("<ТИП ПОЕЗДКИ>", RideTypeClass.RideTypeToString(contract.RideType));
            words.Add("<ДАТА ЗАКЛЮЧЕНИЯ ДОГОВОРА>", contract.ConclusionDate);
            words.Add("<ДАТА ОКОНЧАНИЯ ДОГОВОРА>", contract.EndDate);
            words.Add("<ВРЕМЯ ОКОНЧАНИЯ ДОГОВОРА>", "ПОКА ПУСТО");

            var replaceWords = new ReplaceWords(words);
            return replaceWords;
        }

        public static string CreateDocumentName(Car car, Renter renter)
        {
            var passport = renter.Passport;
            var name = $"{car.Brand} {car.Color} {passport.Surname} {passport.Name} {passport.Patronymic}";
            return name;
        }

        public static void ReplaceWordsInDocument(string samplePath, ReplaceWords replaceWords, string documentName, string outputFolder)
        {
            var document = new Document(samplePath);
            document.CopyDocumentAndActivate(documentName, outputFolder);
            document.ReplaceWords(replaceWords);
        }
    }
}