using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Models
{
    public class Pokemones
    {
        [Key]
        public int PokemonId { get; set; }
        public string Name { get; set; }
       
    }
}
