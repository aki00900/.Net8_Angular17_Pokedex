using System;
using MyWebApp.Models;

namespace MyWebApp.Interfaces
{
	public interface IPokemonRepository
	{
        Task<Pokemon> CreatePokemon(Pokemon pokemon);
        Task<bool> DeletePokemon(int id);
        Task<Pokemon> EditPokemon(Pokemon pokemon);
        Task<List<Pokemon>> GetPokemons();
    }
}

