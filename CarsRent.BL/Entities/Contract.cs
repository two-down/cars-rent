﻿using System;
using System.Collections.Generic;

namespace CarsRent.BL.Entities
{
    public class Contract : BaseEntity
    {
        public LandLord LandLord { get; set; }
        public Renter Renter { get; set; }
        public Car Car { get; set; }

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
            var list = new List<string>();

            list.Add(LandLord.Id.ToString());
            list.Add(Renter.Id.ToString());
            list.Add(Car.Id.ToString());
            list.Add(ConclusionDate.ToString());
            list.Add(EndDate.ToString());

            return list;
        }
    }
}