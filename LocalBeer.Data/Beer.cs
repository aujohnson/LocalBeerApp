using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBeer.Data
{
    public class Beer
    {
        [Key]
        public int BeerId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string BeerType { get; set; }

        [Required]
        public string BeerName { get; set; }

        [Required]
        public int BeerRating { get; set; }

        [Required]
        public DateTimeOffset OrderDateUtc { get; set; }

        public DateTimeOffset? ModifiedOrder { get; set; }
    }
}
