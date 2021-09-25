using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdrianoMelquiadesMidTermTest.Models {
    public class Address {
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }


        public Address(int streetNumber, string streetName) {
            this.StreetNumber = streetNumber;
            this.StreetName = streetName;
        }
    }
}
