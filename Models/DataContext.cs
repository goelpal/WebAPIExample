using Microsoft.EntityFrameworkCore;

namespace WebAPIExample.Models
{
    public class DataContext:DbContext
    {
        //constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }   

        public DbSet<Car> Cars { get; set; }
    }
}
