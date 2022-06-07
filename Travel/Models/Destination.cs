using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
  public class Destination
  {
    public int DestinationId { get; set; }
    [Required]
    public string CityName { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    public int Distance { get; set; }
    [Required]
    [Range(1,5)]
    public int Rate    { get; set; }
  }
}