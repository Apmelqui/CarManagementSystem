using AdrianoMelquiadesMidTermTest.Models;
using System;

namespace Adriano_Melquiades_MidTermTest_NEW {
    class Program {
        static void Main(string[] args) {
            //Creating some addresses
            var address1 = new Address(2350, "Bloor St. E");
            var address2 = new Address(500, "Younge St.");

            //creating a customer with more than one address
            var customer1 = new Customer("Adriano", address1);
            customer1.addresses.Add(address2);

            Console.WriteLine(customer1);


            var customer2 = new Customer("John", new Address(600, "Church St."));

            Console.WriteLine(customer2);

            //Creating some cars
            var car1 = new Car("BMW", "White", 150);
            var car2 = new Car("Mercedes", "Black", 200);
            var car3 = new Car("Civic", "White", 70);
            var car4 = new Car("Porsche", "Red", 300);

            //Console.WriteLine("-----------------Printing cars:");
            //Console.WriteLine(car1);
            //Console.WriteLine(car2);


            //Testing order class with a wrong input (-10 days):
            try {
                var order1 = new Order(customer1, car1, 10);
                Console.WriteLine(order1);

            } catch (Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
                return;
                
            }

            //Testing the create method:

            //try {
            //    car.create(car1);
            //    car.create(car2);
            //    car.create(car3);
            //    car.create(car4);
            //} catch (exception e) {
            //    console.foregroundcolor = consolecolor.red;
            //    console.writeline(e.message);
            //    console.foregroundcolor = consolecolor.white;
            //    return;
            //}


            //Testing Read method:
            try {
                Car.Read();
                Console.WriteLine(Car.GetCars());

            } catch (Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            //Testing Update method:
            //PS: In real world, it would be better to use the CarId (genereted with Guid) instead of the model. 
            //I used the model just to make it simple the example.
            Car.Update("99dd356e-2bb6-4bd7-8a96-82e84bbc30b5", "newID");
            Console.WriteLine(Car.GetCars());


            Console.WriteLine("Printing after deleting");
            //Testing the Delete method:
            Car.Delete("99dd356e-2bb6-4bd7-8a96-82e84bbc30b5");
            Console.WriteLine(Car.GetCars());

            Console.WriteLine("Getting all the white cars:");
            Console.WriteLine(Car.GetCars("wHiTe"));





        }
    }
}
