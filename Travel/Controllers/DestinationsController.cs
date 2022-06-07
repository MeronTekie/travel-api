using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Travel.Models;

namespace Travel.Controllers
{
  [Route("api/destinations")]
  [ApiController]
  public class DestinationsController:Controller
  {
    private readonly TravelContext _db;
    public DestinationsController(TravelContext db)
    {
      _db=db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> Get()
    {
      var list = await _db.Destintations.ToListAsync();
      return list; 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Destination>> GetDesination(int id)
    {
      var destination = await _db.Destintations.FindAsync(id);
      if(destination == null )
      {
        return NotFound();
      }
      return destination;
    }
    [HttpPost]
    public async Task<ActionResult<Destination>> Post(Destination destination)
    {
      _db.Destintations.Add(destination);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post",new{id= destination.DestinationId},destination);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Destination destination)
    {
      if(id!=destination.DestinationId)
      {
        return BadRequest();
      }

      _db.Entry(destination).State  = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch(DbUpdateConcurrencyException)
      {
        if(!DestinationExists(id))
        {
          return NotFound();
        }
        else
        {  
          throw;
        }
      }
        return NoContent();
    }
    private bool DestinationExists(int id)

    {
      return _db.Destintations.Any(e=>e.DestinationId==id);
    }

    [HttpDelete("{id}")]
    public  async Task<ActionResult> Delete(int id)
    {
        var destination = await _db.Destintations.FindAsync(id);
        if(destination ==null)
        {
          return NotFound();
        }
      _db.Destintations.Remove(destination);
      await _db.SaveChangesAsync();
      return NoContent();
    }
  }
}