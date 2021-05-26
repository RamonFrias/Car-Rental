using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities {
    class DateCarRegisters {
        public DateTime DateCarRegister { get; set; }
        public DateCarRegisters(DateTime dateCarRegister) {
            DateCarRegister = dateCarRegister;
        }
    }
}
