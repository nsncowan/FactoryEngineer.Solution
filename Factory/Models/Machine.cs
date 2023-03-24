using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    [Required(ErrorMessage = "You must enter a name to add a machine.")]
    public string Name { get; set; }
    public List<License> JoinEntities { get; }
  }
}