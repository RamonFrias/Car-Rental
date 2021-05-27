using CarRental.Entities;
using CarRental.Controler;
using System;
using CarRental.Repository;
using System.Collections.Generic;
using CarRental.Service;

namespace CarRental {
    class Program {
        public static object Menu { get; private set; }

        static void Main(string[] args) {
            int menuOption;
            Dictionary<DateCarRegisters, Car> carRepository = CarRepository.LocalCarRepository();

            Dictionary<DateCarRegisters, Car> rentedCarRepository = RentedCarsRepository.LocalRentedCarsRepository();
            do {
                Console.Clear();

                menuOption = MenuControler.Menu();

                switch (menuOption) {
                    case 1:
                        CarService.AddNewCar(carRepository);
                        break;

                    case 2:
                        CarService.ViewVehicles(carRepository);
                        break;

                    case 3: CarService.RentedVehicle(carRepository, rentedCarRepository);
                        break;

                    case 4:
                        break;
                }
            } while (menuOption != 5);
        }
    }
}
