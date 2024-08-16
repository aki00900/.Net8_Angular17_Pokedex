using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Constants;

namespace MyWebApp.Models;

[Table("Pokemon")]
public partial class Pokemon
{
    [Key]
    public int PokemonId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public int TypeId { get; set; }

    public int PokedexNumber { get; set; }

    public int RegionId { get; set; }

    public string RegionName { get; set; }

    [ForeignKey("RegionId")]
    [InverseProperty("Pokemons")]
    public virtual Region Region { get; set; } = null!;

    [ForeignKey("TypeId")]
    [InverseProperty("Pokemons")]
    public virtual Type Type { get; set; } = null!;

    public string PokemonType { get; set; }

    public void SetType()
    {
        this.PokemonType = TypeId switch
        {
            1 => TypeConstants.Fire.ToString(),
            2 => TypeConstants.Water.ToString(),
            3 => TypeConstants.Grass.ToString(),
            4 => TypeConstants.Electric.ToString(),
            5 => TypeConstants.Psychic.ToString(),
            6 => TypeConstants.Bug.ToString(),
            7 => TypeConstants.Normal.ToString(),
            8 => TypeConstants.Rock.ToString(),
            9 => TypeConstants.Ghost.ToString(),
            10 => TypeConstants.Dragon.ToString(),
            _ => "None" // Default to "None" for invalid TypeId
        };
    }

    public void SetRegion()
    {
        this.RegionName = RegionId switch
        {
            1 => RegionConstants.Kanto.ToString(),
            2 => RegionConstants.Johto.ToString(),
            3 => RegionConstants.Hoenn.ToString(),
            4 => RegionConstants.Sinnoh.ToString(),
            5 => RegionConstants.Unova.ToString(),
            6 => RegionConstants.Kalos.ToString(),
            7 => RegionConstants.Alola.ToString(),
            8 => RegionConstants.Galar.ToString(),
            _ => "None" // Default to "Unknown" for invalid RegionId
        };

    }
}
