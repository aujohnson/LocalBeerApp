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

        private int _beerrating;


        public int BeerRating
        {
            get { return _beerrating; }
            set
            {
                if (value > 5M)
                {
                    _beerrating = 5;
                } else if (value < 1)
                {
                    _beerrating = 1;
                }
            }

        }
    }
}
