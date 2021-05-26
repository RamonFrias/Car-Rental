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
            Dictionary<int, Car> repository = CarRepository.LocalCarRepository();
            do {
                menuOption = MenuControler.Menu();



                switch (menuOption) {
                    case 1:
                        CarService.AddNewCar(repository);
                        break;

                    case 2:
                        CarService.ViewVehicles(repository);
                        break;

                    case 3:
                        break;

                    case 4:
                        break;
                }
            } while (menuOption != 5);
        }
    }
}
