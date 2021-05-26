using System;
using System.Collections.Generic;
using CarRental.Repository;
using CarRental.Entities;
using CarRental.Verifications;

namespace CarRental.Service {
    class CarService : CarRepository {
        public static void AddNewCar(Dictionary<int, Car> repository) {
            bool verifiedAnswerds;
            string brand, model, color, licensePlate;
            int id = 1;

            do {
                foreach (KeyValuePair<int, Car> ids in repository) {
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

            repository.Add(id, car);
        }

        public static void ViewVehicles(Dictionary<int, Car> repository) {
            foreach (KeyValuePair<int, Car> cars in repository) {
                Console.WriteLine($"Id - {cars.Key} \nModel - {cars.Value.Model} \nBrand - {cars.Value.Brand} \nColor - {cars.Value.Color} \nLicnese plate - {cars.Value.LicensePlates}");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue!");
            Console.ReadLine();

            Console.Clear();
        }
    }
}
