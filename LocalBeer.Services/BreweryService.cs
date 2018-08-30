using LocalBeer.Data;
using LocalBeer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBeer.Services
{
    public class BreweryService
    {
        private readonly Guid _userId;

        public BreweryService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateBrewery(BreweryCreate brewery)
        {
            var entity =
                new Brewery()
                {
                    OwnerId = _userId,
                    BreweryName = brewery.BreweryName,
                    BreweryAddress = brewery.BreweryAddress,
                    BreweryDescription = brewery.BreweryDescription
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Breweries.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BreweryListItem> GetBreweries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Breweries
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new BreweryListItem
                                {
                                    BreweryId = e.BreweryId,
                                    BreweryName = e.BreweryName,
                                    BreweryAddress = e.BreweryAddress
                                }
                        );

                return query.ToArray();
            }
        }
    }
}