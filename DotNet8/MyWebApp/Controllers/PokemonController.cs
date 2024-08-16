using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Interfaces;
using MyWebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        // GET: /<controller>/
        private readonly IPokemonRepository _pokemonRepository;
        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet("GetPokemons")]
        public async Task<IActionResult> GetPokemons()
        {
            var fetchedPokemons = await _pokemonRepository.GetPokemons();

            return Ok(fetchedPokemons);
        }

        [HttpPost("CreatePokemon")]
        public async Task<IActionResult> CreatePokemon([FromBody] Pokemon pokemon)
        {
            var pokemans = await _pokemonRepository.CreatePokemon(pokemon);
            return Ok(pokemans);
        }

        [HttpPost("EditPokemon")]
        public async Task<IActionResult> EditPokemon([FromBody] Pokemon pokemon)
        {
            var editedPokemon = await _pokemonRepository.EditPokemon(pokemon);
            return Ok(editedPokemon);
        }

        [HttpPost("DeletePokemon")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var pokemon = await _pokemonRepository.DeletePokemon(id);
            return Ok(pokemon);
        }
    }
}

