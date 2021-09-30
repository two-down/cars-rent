using CarsRent.BL.BDRequests;
using CarsRent.BL.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarsRent.BL.Entities
{
    public class Contract : BaseEntity
    {
        [Required(ErrorMessage = "Данные арендодателя не введены")]
        public virtual LandLord LandLord { get; set; }

        [Required(ErrorMessage = "Арендатор не прикреплен к договору")]
        public virtual Renter Renter { get; set; }

        [Required(ErrorMessage = "Машина не прикреплена к договору")]
        public virtual Car Car { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Дата заключения договора не введена")]
        [RegularExpression("^([0]?[1-9]|[1][0-2])[./-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0-9]{4}|[0-9]{2})$",
            ErrorMessage = "Не корректная дата заключения договора")]
        public string ConclusionDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Дата окончания действия договора не введена")]
        [RegularExpression("^([0]?[1-9]|[1][0-2])[./-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0-9]{4}|[0-9]{2})$",
            ErrorMessage = "Не корректная дата окончания договора")]
        public string EndDate { get; set; }

        [Required(ErrorMessage = "Не выбран тип поездки")]
        public RideType RideType { get; set; }

        [Required(ErrorMessage = "Не введена стоимость поездки")]
        [Money]
        public string RidePrice { get; set; }

        public Contract() { }

        public Contract(LandLord landLord, Renter renter, Car car, string conclusionDate, string endDate, RideType rideType, string ridePrice)
        {
            LandLord = landLord;
            Renter = renter;
            Car = car;
            ConclusionDate = conclusionDate;
            EndDate = endDate;
            RideType = rideType;
            RidePrice = ridePrice;
        }

        public override List<string> GetData()
        {
            var contract = Query<Contract>.SelectById(Id);

            var list = new List<string>();

            list.Add(contract.LandLord.Id.ToString());
            list.Add(contract.Renter.Id.ToString());
            list.Add(contract.Car.Id.ToString());
            list.Add(contract.ConclusionDate.ToString());
            list.Add(contract.EndDate.ToString());

            return list;
        }

        public override string ToString()
        {
            var contract = Query<Contract>.SelectById(Id);

            return $"{contract.Renter.Passport.Surname} - {contract.Car.Brand}";
        }
    }
}