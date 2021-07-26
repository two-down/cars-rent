using System;

namespace CarsRent.BL.Entities
{
    public class Renter : BaseEntity
    {
        public Passport Passport { get; set; }

        public Renter(Passport passport)
        {
            if (passport is null)
                throw new Exception("Не удалось создать арендатора. Проверьте паспортные данные.");

            Passport = passport;
        }

        public override string ToString()
        {
            return Passport.ToString();
        }
    }
}