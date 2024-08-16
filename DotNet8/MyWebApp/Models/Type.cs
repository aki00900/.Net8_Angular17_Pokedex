using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models;

[Table("Type")]
public partial class Type
{
    [Key]
    public int TypeId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("Type")]
    public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

    public static implicit operator Type(string v)
    {
        throw new NotImplementedException();
    }
}
