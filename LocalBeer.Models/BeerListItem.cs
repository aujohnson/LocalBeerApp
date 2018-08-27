using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBeer.Models
{
    public class BeerListItem
    {
        
            public int BeerId { get; set; }
            public string BeerName { get; set; }
            public string BeerType { get; set; }

        [Display(Name = "Created")]
            public DateTimeOffset CreatedUtc { get; set; }

            public override string ToString() => BeerName;
            }
        }
    
