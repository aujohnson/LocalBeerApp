using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBeer.Data
{
    public class Brewery
    {
        [Required]
        public string BreweryName { get; set; }

        [Key]
        public int BreweryId { get; set; }

        [Required]
        public string BreweryAddress { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string BreweryDescription { get; set; }
    }
}
