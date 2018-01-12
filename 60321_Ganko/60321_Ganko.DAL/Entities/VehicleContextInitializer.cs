using System.Collections.Generic;
using System.Data.Entity;

namespace _60321_Ganko.DAL.Entities
{
    internal class VehicleContextInitializer : DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            List<Car> cars = new List<Car>
            {
                new Car { CarId = 1, Manufacturer = "Audi", Model = "A4", ClassType = "Sedan", Price = 31000 },
                new Car { CarId = 2, Manufacturer = "Geely", Model = "Atlas", ClassType = "SUV", Price = 18000 },
                new Car { CarId = 3, Manufacturer = "Lada", Model = "Vesta", ClassType = "Sedan", Price = 11000 },
                new Car { CarId = 4, Manufacturer = "VW", Model = "Golf", ClassType = "Hatchback", Price = 23000 },
                new Car { CarId = 5, Manufacturer = "Alfa Romeo", Model = "Gulia", ClassType = "Coupe", Price = 29000 },
                new Car { CarId = 6, Manufacturer = "Volvo", Model = "XC90", ClassType = "SUV", Price = 50000 },
                new Car { CarId = 7, Manufacturer = "BMW", Model = "M4", ClassType = "Coupe", Price = 99000 },
                new Car { CarId = 8, Manufacturer = "Jeep", Model = "Grand Cherokee", ClassType = "SUV", Price = 54000 },
                new Car { CarId = 9, Manufacturer = "Ford", Model = "Explorer", ClassType = "SUV", Price = 45000 },
                new Car { CarId = 10, Manufacturer = "Honda", Model = "Civic", ClassType = "Hatchback", Price = 25000 },
                new Car { CarId = 11, Manufacturer = "Dodge", Model = "Challenger", ClassType = "Coupe", Price = 44000 }
            };
            context.Cars.AddRange(cars);
            context.SaveChanges();
        }
    }
}
