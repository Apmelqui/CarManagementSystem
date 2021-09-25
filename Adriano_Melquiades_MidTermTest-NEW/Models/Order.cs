using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdrianoMelquiadesMidTermTest.Models {
    public class Order {
        //Fields:
        private int duration;
        private double total;

        //Properties:
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public int Duration {
            get {
                return this.duration;
            }
            set {
                if (value > 0) {
                    this.duration = value;
                } else {
                    throw new Exception("Error. Duration must be greater that zero.");
                }
            }
        }

        public double Total {
            get {
                return this.total;
            }
            set {
                total = this.Car.Price * this.Duration;
            }
        }

        public Order(Customer customer, Car car, int duration) {
            this.Customer = customer;
            this.Car = car;
            this.Duration = duration;
            this.Car.IsRented = true;
            this.Total = total;
        }

        public override string ToString() {
            return $"Customer: {this.Customer.Name}\n" +
                   $"Car: {this.Car.Model}\n" +
                   $"Duration: {this.Duration}\n" +
                   $"Total: {this.Total}\n";
        }
    }
}
