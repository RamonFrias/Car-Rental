
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Verifications {
    class CarVerification {
        public static bool VerifyAnswerds(string brand, string model, string color, string licensePlate) {
            if (brand != "" && model != "" && color != "" && licensePlate != "") {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
