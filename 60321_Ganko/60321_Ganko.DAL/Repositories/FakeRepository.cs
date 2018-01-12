using _60321_Ganko.DAL.Entities;
using _60321_Ganko.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _60321_Ganko.DAL.Repositories
{
    public class FakeRepository : IRepository<Car>
    {
        public IEnumerable<Car> GetAll()
        {
            return new List<Car>
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
        }

        public IEnumerable<Car> Find(Func<Car, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Car Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Car t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car t)
        {
            throw new NotImplementedException();
        }
    }
}
