using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Travel.Models;

namespace Travel.Models
{
  public class  TravelContext : DbContext
  {
    private TravelContext(DbContextOptions<TravelContext> options) : base(options)
    {

    }
    public DbSet<Destination> Destintations { get; set; }
  }
}