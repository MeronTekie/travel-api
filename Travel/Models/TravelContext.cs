using Microsoft.EntityFrameworkCore;

namespace Travel.Models
{
  public class  TravelContext : DbContext
  {
    public TravelContext(DbContextOptions<TravelContext>  options) : base(options)
    {

    }
    public DbSet<Destination> Destintations { get; set; }
  }
}