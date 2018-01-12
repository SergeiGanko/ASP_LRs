using System.Data.Entity;

namespace _60321_Ganko.DAL.Entities
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(string name) : base(name)
        {
            Database.SetInitializer(new VehicleContextInitializer());
        }
    
        public DbSet<Car> Cars { get; set; }
    }
}
