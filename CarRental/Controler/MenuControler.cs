
using System;
using System.Collections.Generic;
using CarRental.Entities;
using CarRental.Verifications;

namespace CarRental.Controler {
    class MenuControler {
        public static int Menu() {
            bool verifyOption;
            int option;
            do {
                Dictionary<int, string> menu = new Dictionary<int, string>() {
                { 1, "Register new car" },
                { 2, "View cars" },
                { 3, "Rent a car" },
                { 4, "View rented cars" },
                { 5, "View available cars"},
                { 6, "Exit" }
              };

                Console.WriteLine("---------- Menu --------------");
                foreach (KeyValuePair<int, string> options in menu) {
                    Console.WriteLine($"{options.Key} - {options.Value}");
                }
                Console.WriteLine("------------------------------");

                Console.WriteLine("Select the desired option:");
                option = int.Parse(Console.ReadLine());

                verifyOption = MenuVerification.VerifyOption(menu, option);

                if (verifyOption == false) {
                    Console.WriteLine("Option not available !! Please press any key to continue.");
                    Console.ReadLine();
                }

                Console.Clear();

            } while (verifyOption == false);

            return option;
        }
    }
}