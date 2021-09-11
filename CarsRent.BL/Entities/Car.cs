﻿using System;
using System.Collections.Generic;

namespace CarsRent.BL.Entities
{
    public class Car : BaseEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Year { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string VIN { get; set; }
        public string BodyNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string EngineNumber { get; set; }
        public string EngineDisplacement { get; set; }
        public double Price { get; set; }
        public DateTime PassportIssuingDate { get; set; }

        public Car() { }

        public Car(string brand, string model, string color, string year,
            string passportSeries, string passportNumber, string vin,
            string bodyNumber, string registrationNumber, string engineNumber,
            string engineDisplacement, double price, DateTime passportIssuingDate)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Year = year;
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
            VIN = vin;
            BodyNumber = bodyNumber;
            RegistrationNumber = registrationNumber;
            EngineNumber = engineNumber;
            EngineDisplacement = engineDisplacement;
            Price = price;
            PassportIssuingDate = passportIssuingDate;
        }

        public override List<string> GetData()
        {
            var list = new List<string>();

            list.Add(Brand);
            list.Add(Model);
            list.Add(Color);
            list.Add(Year);
            list.Add(PassportSeries);
            list.Add(PassportNumber);
            list.Add(VIN);
            list.Add(BodyNumber);
            list.Add(RegistrationNumber);
            list.Add(EngineNumber);
            list.Add(EngineDisplacement);
            list.Add(Price.ToString());
            list.Add(PassportIssuingDate.ToString());

            return list;
        }
    }
}