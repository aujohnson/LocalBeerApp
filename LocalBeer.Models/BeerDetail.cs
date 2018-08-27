using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBeer.Models
{
    public class BeerDetail
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public string BeerType { get; set; }
        public int BeerRating { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{BeerId}] {BeerName}";
    }
}
