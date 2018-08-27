using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBeer.Models
{
    public class BeerCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string BeerName { get; set; }

        [MaxLength(8000)]
        public string BeerType { get; set; }


        public int BeerRating
        {
            get { return BeerRating; }
            set
            {
                if (value > 5M)
                {
                    BeerRating = 5;
                } else if (value < 1)
                {
                    BeerRating = 1;
                }
            }

        }
    }
}
