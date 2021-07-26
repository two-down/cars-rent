using System;

namespace CarsRent.BL.Entities
{
    public class LandLord : BaseEntity
    {
        public Passport Passport { get; set; }

        public LandLord(Passport passport)
        {
            if (passport is null)
                throw new Exception("Не удалось создать арендодателя. Проверьте паспортные данные.");

            Passport = passport;
        }

        public override string ToString()
        {
            return Passport.ToString();
        }
    }
}