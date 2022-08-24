using Microsoft.EntityFrameworkCore;

namespace API.Data
{
   public class DataContext : DbContext
   {
      public DataContext(DbContextOptions<DataContext> options) : base(options) { }
      
      public DbSet<Customer> Customers { get; set; }
      public DbSet<Car> Cars { get; set; }
      public DbSet<Appointment> Appointments { get; set; }  
   }
}
