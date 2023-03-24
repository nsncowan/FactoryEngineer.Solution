using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required(ErrorMessage = "You must enter a name to add an engineer.")]
    public string Name { get; set; }
    public List<License> JoinEntities { get; }
  }
}