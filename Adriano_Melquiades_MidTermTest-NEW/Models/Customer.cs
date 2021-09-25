using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdrianoMelquiadesMidTermTest.Models {
    public class Customer {
        //Fields:
        private static int counter = 1;
        public List<Address> addresses = new List<Address>();

        public int CustumerId { get; set; }
        public string Name { get; set; }


        public Customer(string name, Address address) {
            this.CustumerId = counter;
            this.Name = name;
            addresses.Add(address);
            counter++;
        }

        public Customer(string name, List<Address> addresses) {
            this.CustumerId = counter;
            this.Name = name;
            this.addresses.AddRange(addresses); //add a list at the end of another list
            counter++;
        }

        public Customer() {
            this.CustumerId = counter;
        }

        public override string ToString() {
            string addrerssReturn = "";
            foreach (var address in addresses) {
                addrerssReturn += "\t" + address.StreetNumber + " " + address.StreetName + "\n";
            }

            return $"CustomerId: {this.CustumerId}\n" +
                   $"Name: {this.Name}\n" +
                   $"Address: \n{addrerssReturn}\n";
        }
    }
}
