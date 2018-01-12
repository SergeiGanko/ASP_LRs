using _60321_Ganko.DAL.Entities;
using _60321_Ganko.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace _60321_Ganko.DAL.Repositories
{
    public class EFCarRepository : IRepository<Car>
    {
        private VehicleContext context;

        public EFCarRepository(string name)
        {
            context = new VehicleContext(name);
        }

        public void Create(Car t)
        {
            context.Cars.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = context.Cars.Find(id);
            if (item!=null)
            {
                context.Cars.Remove(item);
            }
            context.SaveChanges();
        }

        public IEnumerable<Car> Find(Func<Car, bool> predicate)
        {
            return context.Cars.Where(predicate).ToList();
        }

        public Car Get(int id)
        {
            return context.Cars.Find(id);
        }

        public IEnumerable<Car> GetAll()
        {
            return context.Cars;
        }

        public Task<Car> GetAsync(int id)
        {
            return context.Cars.FindAsync(id);
        }

        public void Update(Car t)
        {
            context.Entry<Car>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
