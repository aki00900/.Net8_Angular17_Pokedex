using System;
using MyWebApp.Models;
using MyWebApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Repositories
{
	public class PokemonRepository : IPokemonRepository
	{
		public readonly SampleDatabaseContext _databaseContext;
		public PokemonRepository(SampleDatabaseContext dbContext)
		{
			_databaseContext = dbContext;
		}

		public async Task<Pokemon> CreatePokemon(Pokemon pokemon)
		{
			_databaseContext.Pokemons.Add(pokemon);
			await _databaseContext.SaveChangesAsync();
			return pokemon;
		}

		public async Task<bool> DeletePokemon(int pokemonId)
		{
			var rows = await _databaseContext.Pokemons.Where(x => x.PokemonId == pokemonId).ExecuteDeleteAsync();
			return true;
		}

		public async Task<Pokemon> EditPokemon(Pokemon pokemon)
		{
			var rows = await _databaseContext.Pokemons.Where(x => x.PokemonId == pokemon.PokemonId)
				.ExecuteUpdateAsync(x => x.SetProperty(x => x.Name, pokemon.Name));
			return pokemon;
		}

		public async Task<List<Pokemon>> GetPokemons()
		{
			var result = await _databaseContext.Pokemons.Include(x => x.Region).Include(x => x.Type)
				.Select(fetchedpokemon =>
					new Pokemon
                    {
						PokemonId = fetchedpokemon.PokemonId,
						Name = fetchedpokemon.Name,
						PokedexNumber = fetchedpokemon.PokedexNumber,
						RegionId = fetchedpokemon.RegionId,
						TypeId = fetchedpokemon.TypeId
                    }).ToListAsync();

			foreach (var pokemon in result)
			{
				pokemon.SetType();
				pokemon.SetRegion();
			}

			return result;

        }

    }
}

