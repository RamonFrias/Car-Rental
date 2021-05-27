using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities {
    class Car {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string LicensePlates { get; set; }
        public String Status { get; set; }

        public Car(int id, string brand, string model, string color, string licensePlates) {
            Id = id;
            Brand = brand;
            Model = model;
            Color = color;
            LicensePlates = licensePlates;
            Status = "Availabel";
        }
    }
}
