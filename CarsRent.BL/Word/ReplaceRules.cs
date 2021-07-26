using CarsRent.BL.Entities;
using System;
using System.Collections.Generic;

namespace CarsRent.BL.Word
{
    public class ReplaceRules
    {
        public Dictionary<string, string> ReplaceWords { get; private set; }

        public ReplaceRules(LandLord landLord, Renter renter)
        {
            ReplaceWords = new Dictionary<string, string>();

            ReplaceWords.Add("<DATA>", DateTime.Today.ToString());
            ReplaceWords.Add("<LANDLORD>", landLord.ToString());
            ReplaceWords.Add("<RENTER>", renter.ToString());
            var signature = $"{renter.Passport.Surname} {renter.Passport.Name[0]}.{renter.Passport.Patronymic[0]}.";
            ReplaceWords.Add("<SIGNATURE>", signature);
        }
    }
}