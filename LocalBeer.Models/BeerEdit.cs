using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBeer.Models
{
    public class BeerEdit
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public string BeerType { get; set; }
        public int BeerRating { get; set; }
    }
}
