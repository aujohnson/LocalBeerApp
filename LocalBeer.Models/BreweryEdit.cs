using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBeer.Models
{
    public class BreweryEdit
    {
        public int BreweryId { get; set; }

        public string BreweryName { get; set; }

        public string BreweryAddress { get; set; }

        public string BreweryDescription { get; set; }
    }
}
