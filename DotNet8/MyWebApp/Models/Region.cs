using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models;

[Table("Region")]
public partial class Region
{
    [Key]
    public int RegionId { get; set; }

    [StringLength(50)]
    public string RegionName { get; set; } = null!;

    [InverseProperty("Region")]
    public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}
