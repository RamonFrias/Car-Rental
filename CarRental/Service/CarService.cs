using System;
using System.Collections.Generic;
using CarRental.Repository;
using CarRental.Entities;
using CarRental.Verifications;

namespace CarRental.Service {
    class CarService : CarRepository {
        public static void AddNewCar(Dictionary<DateCarRegisters, Car> repository) {
            bool verifiedAnswerds;
            string brand, model, color, licensePlate;
            int id = 1;

            do {
                foreach (KeyValuePair<DateCarRegisters, Car> ids in repository) {
                    id++;
                }

                Console.WriteLine("Inform the car brand:");
                brand = Console.ReadLine();

                Console.WriteLine("Inform the car model:");
                model = Console.ReadLine();

                Console.WriteLine("Inform the car color:");
                color = Console.ReadLine();

                Console.WriteLine("Inform the car license plates:");
                licensePlate = Console.ReadLine();

                verifiedAnswerds = CarVerification.VerifyAnswerds(brand, model, color, licensePlate);

                if (verifiedAnswerds == false) {
                    Console.WriteLine("Incorrect informations !! Please press any key to continue.");
                    Console.ReadLine();
                }
                Console.Clear();
            } while (verifiedAnswerds == false);

            Car car = new Car(id, brand, model, color, licensePlate);
            DateCarRegisters date = new DateCarRegisters(DateTime.Now);

            repository.Add(date, car);
        }

        public static void ViewVehicles(Dictionary<DateCarRegisters, Car> repository) {
            foreach (KeyValuePair<DateCarRegisters, Car> cars in repository) {
                Console.WriteLine($"Id - {cars.Value.Id} \nModel - {cars.Value.Model} \nBrand - {cars.Value.Brand} \nColor - {cars.Value.Color} \nLicnese plate - {cars.Value.LicensePlates} \nRegister date: {cars.Key.DateCarRegister}");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue!");
            Console.ReadLine();

            Console.Clear();
        }
    }
}
