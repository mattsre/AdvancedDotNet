using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvcLabs.Models
{
  public class Manufacturer
  {
    public int ID { get; set; }
    [Required]
    public string Make { get; set; }

    public virtual ICollection<Car> Cars { get; set; }
  }
}