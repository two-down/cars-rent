using CarsRent.BL.BDRequests;
using System;
using System.Collections.Generic;

namespace CarsRent.BL.Entities
{
    public class Contract : BaseEntity
    {
        public virtual LandLord LandLord { get; set; }
        public virtual Renter Renter { get; set; }
        public virtual Car Car { get; set; }

        public DateTime ConclusionDate { get; set; }
        public DateTime EndDate { get; set; }
        public RideType RideType { get; set; }

        public double RidePrice { get; set; }

        public Contract() { }

        public Contract(LandLord landLord, Renter renter, Car car, DateTime conclusionDate, DateTime endDate, RideType rideType, double ridePrice)
        {
            if (landLord == null)
                throw new ArgumentNullException(nameof(landLord));
            if (renter == null)
                throw new ArgumentNullException(nameof(renter));
            if (car == null)
                throw new ArgumentNullException(nameof(car));
            if (conclusionDate > endDate)
                throw new ArgumentException("Дата заключения договора позже даты его расторжения.");
            if (ridePrice <= 0)
                throw new ArgumentException("Цена поездки меньше нуля.");

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
            var contract = Query<Contract>.SelectContract(Id);

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
            var contract = Query<Contract>.SelectContract(Id);

            return $"{contract.Renter.Surname} - {contract.Car.Brand}";
        }
    }
}