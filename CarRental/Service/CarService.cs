using System;
using System.Collections.Generic;
using CarRental.Repository;
using CarRental.Entities;
using CarRental.Verifications;

namespace CarRental.Service {
    class CarService : CarRepository {
        public static void AddNewCar(Dictionary<DateCarRegisters, Car> carRepository, Dictionary<DateCarRegisters, Car> availableCarRepository) {
            bool verifiedAnswerds;
            string brand, model, color, licensePlate;
            int id = 1;
            
            foreach (KeyValuePair<DateCarRegisters, Car> ids in carRepository) {
                id++;
            }

            do {
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

                    Console.Clear();
                }
            } while (verifiedAnswerds == false);

            Car car = new Car(id, brand, model, color, licensePlate);
            DateCarRegisters date = new DateCarRegisters(DateTime.Now);

            carRepository.Add(date, car);
            availableCarRepository.Add(date, car);


            Console.WriteLine("\nSuccess !! The car was rented \nPlease press any key to continue");
            Console.ReadLine();

            Console.Clear();
        }

        public static void ViewVehicles(Dictionary<DateCarRegisters, Car> repository) {
            foreach (KeyValuePair<DateCarRegisters, Car> cars in repository) {
                Console.WriteLine($"Id - {cars.Value.Id} \nModel - {cars.Value.Model} \nBrand - {cars.Value.Brand} \nColor - {cars.Value.Color} \nLicnese plate - {cars.Value.LicensePlates} \nStatus: {cars.Value.Status} \nRegister date: {cars.Key.DateCarRegister}");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue!");
            Console.ReadLine();
        }

        public static void RentedVehicle(Dictionary<DateCarRegisters, Car> carRepository, Dictionary<DateCarRegisters, Car> rentedCarRepository, Dictionary<DateCarRegisters, Car> availableCarRepository) {
            ViewVehicles(carRepository);

            Console.WriteLine("\nInform the Id of the car to be rented:");
            int id = int.Parse(Console.ReadLine());

            bool idVerification = false;

            foreach (KeyValuePair<DateCarRegisters, Car> cars in carRepository) {
                if (id == cars.Value.Id) {
                    rentedCarRepository.Add(cars.Key, cars.Value);
                    idVerification = true;
                    cars.Value.Status = "Unavailable";
                    RemoveUnavailableCarInAvailableRepository(availableCarRepository, id);
                }
            }

            if (idVerification == false) {
                Console.WriteLine("Car ID not found !! Please press any key to continue");
                Console.ReadLine();
            }
            else {
                Console.WriteLine("Success !! The car was rented \nPlease press any key to continue");
                Console.ReadLine();
            }

            Console.Clear();
        }

        public static void ViewRentedVehicles(Dictionary<DateCarRegisters, Car> rentedCarRepository) {
            foreach (KeyValuePair<DateCarRegisters, Car> cars in rentedCarRepository) {
                Console.WriteLine($"Id - {cars.Value.Id} \nModel - {cars.Value.Model} \nBrand - {cars.Value.Brand} \nColor - {cars.Value.Color} \nLicnese plate - {cars.Value.LicensePlates} \nRegister date: {cars.Key.DateCarRegister}");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue!");
            Console.ReadLine();
        }

        public static void ViewAvailableCars(Dictionary<DateCarRegisters, Car> availableCarRepository) {
            foreach (KeyValuePair<DateCarRegisters, Car> car in availableCarRepository) {
                Console.WriteLine($"Id - {car.Value.Id} \nModel - {car.Value.Model} \nBrand - {car.Value.Brand} \nColor - {car.Value.Color} \nLicnese plate - {car.Value.LicensePlates} \nRegister date: {car.Key.DateCarRegister}");
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to continue!");
            Console.ReadLine();
        }

        public static void RemoveUnavailableCarInAvailableRepository(Dictionary<DateCarRegisters, Car> availableCarRepository, int id) {

            foreach (KeyValuePair<DateCarRegisters, Car> cars in availableCarRepository) {
                if (id == cars.Value.Id) {
                    availableCarRepository.Remove(cars.Key);
                }
            }
        }
    }
}
