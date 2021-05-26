using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Verifications {
    class MenuVerification {
        public static bool VerifyOption(Dictionary<int, string> menu, int option) {
            bool optionChecked = false;
            foreach (KeyValuePair<int, string> options in menu) {
                if (options.Key == option) {
                    optionChecked = true;
                }
            }
            return optionChecked;
        }
    }
}
