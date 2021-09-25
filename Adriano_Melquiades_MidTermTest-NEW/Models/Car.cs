
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AdrianoMelquiadesMidTermTest.Models {
    public class Car {
        //Fields:
        private double price;
        private static List<Car> allCarList = new List<Car>();

        //Properties:
        public string CarId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double Price {
            get {
                return this.price;
            }
            set {
                if (value > 0) {
                    this.price = value;
                } else {
                    throw new Exception("Price must be greater than zero.");
                }
            }
        }
        public bool IsRented { get; set; }

        public Car() {
            this.CarId = Guid.NewGuid().ToString();
        }

        public Car(string model, string color, double price)
            : this() {
            this.Model = model;
            this.Color = color;
            this.Price = price;
            this.IsRented = false;
        }

        public override string ToString() {
            return $"CarId: {this.CarId}\n" +
                   $"Model: {this.Model}\n" +
                   $"Color: {this.Color}\n" +
                   $"Price: {this.Price}\n" +
                   $"IsRented: {this.IsRented}\n";
        }

        public static void AddCar(Car car) {
            allCarList.Add(car);
        }

        //////////////////////////// CRUD ///////////////

        //Create Method:
        public static void Create(Car car) {
            //one file per car
            string path = @"C:\_test\CarRentManagementSystem\Adriano-MidTermTest\";
            var filename = $"{car.CarId}.xml";

            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }

            if (File.Exists(path + filename)) {
                File.Delete(path + filename);
            }

            var serializer = new XmlSerializer(typeof(Car));

            using (var stream = new FileStream(path + filename, FileMode.Create)) {
                serializer.Serialize(stream, car);
            }
        }

        //Read Method
        public static void Read() {
            string path = @"C:\_test\CarRentManagementSystem\Adriano-MidTermTest\";


            var allFiles = Directory.GetFiles(path, "*.xml");

            foreach (string file in allFiles) {
                using (var stream = new FileStream(file, FileMode.Open)) {
                    var serializer = new XmlSerializer(typeof(Car));

                    var car = (Car)serializer.Deserialize(stream);

                    AddCar(car);
                    //Console.WriteLine(car);
                }
            }
        }

        public static string GetCars() {
            var listToString = "";
            var found = false;
            for (int i = 0; i < allCarList.Count; i++) {
                listToString += allCarList[i];
                listToString += "\n";
                found = true;
            }

            if (found == true) {
                return listToString;
            } else {
                return $"There is no car added to the list. Please add some cars.";
            }
        }

        //Get car by its colour:
        public static string GetCars(string color) {
            var listToString = "";
            var found = false;
            for (int i = 0; i < allCarList.Count; i++) {
                if (allCarList[i].Color.ToLower() == color.ToLower()) {
                    listToString += allCarList[i];
                    listToString += "\n";
                    found = true;
                }
            }

            if (found == true) {
                return listToString;
            } else {
                return $"No {color} car found.";
            }
        }

        //Update Method
        //public static void Update(string model, string newModel) {
        //    var found = false;
        //    for (var i = 0; i < allCarList.Count; i++) {
        //        if (allCarList[i].Model.ToLower() == model.ToLower()) {
        //            allCarList[i].Model = newModel;
        //            found = true;    
        //        }
        //    }
        //    if (found == false) {
        //        Console.WriteLine($"There is no {model} car in the list");
        //    }
        //}


        public static void Update(string carId, string newId) {
            var found = false;
            for (var i = 0; i < allCarList.Count; i++) {
                if (allCarList[i].CarId.ToLower() == carId.ToLower()) {
                    allCarList[i].CarId = newId;

                    Car.Delete(carId);
                    Car.Create(allCarList[i]);

                    found = true;
                }
            }
            if (found == false) {
                Console.WriteLine($"There is no {carId} carId in the list");
            }
        }







        //Delete Method:
        public static void Delete(string carId) {
            var found = false;
            for (int i = 0; i < allCarList.Count; i++) {
                if (allCarList[i].CarId == carId) {
                    allCarList.RemoveAt(i);
                    string path = @"C:\_test\CarRentManagementSystem\Adriano-MidTermTest\";
                    var filename = $"{allCarList[i].CarId}.xml";
                    File.Delete(path + filename);
                    Console.WriteLine($"The car with the id: {carId} was removed sucessfully");
                    found = true;
                }
            }

            if (found == false) {
                Console.WriteLine($"No car was found with the id : {carId}");
            }
        }
        //Ps. Another aproach would be using just one file for all the cars.
        //In this test I used one file per car

    }
}
