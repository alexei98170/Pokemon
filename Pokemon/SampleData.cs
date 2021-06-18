using System.Linq;
using Pokemon.Data;
using Pokemon.Models;

namespace MobileStore
{
    public static class SampleData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Pokemons.Any())
            {
                context.Pokemons.AddRange(
                    new Pokemones
                    {
                        Name = "Bulbasaur",
                       
                    },
                    new Pokemones
                    {
                        Name = "Pikachu",
                       
                    },
                    new Pokemones
                    {
                        Name = "Squirtle",
                       
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
