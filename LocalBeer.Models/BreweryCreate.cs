using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBeer.Models
{
   public class BreweryCreate
    {

        [Required]
        public string BreweryName { get; set; }

        public string BreweryAddress { get; set; }

        public string BreweryDescription { get; set; }

        public override string ToString() => BreweryAddress;
    }
}
