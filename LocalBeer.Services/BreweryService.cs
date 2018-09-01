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
                                    BreweryName = e.BreweryName,
                                    BreweryAddress = e.BreweryAddress,
                                    BreweryDescription = e.BreweryDescription,
                                }
                        );

                return query.ToArray();
            }
        }
        public BreweryDetail GetBreweryById(int breweryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Breweries
                        .Single(e => e.BreweryId == breweryId && e.OwnerId == _userId);
                return
                    new BreweryDetail
                    {
                        BreweryId = entity.BreweryId,
                        BreweryName = entity.BreweryName,
                        BreweryAddress = entity.BreweryAddress,
                        BreweryDescription = entity.BreweryDescription,
                    };
            }
        }

        public bool UpdateBrewery(BreweryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Breweries
                        .Single(e => e.BreweryId == model.BreweryId && e.OwnerId == _userId);


                entity.BreweryId = model.BreweryId;
                entity.BreweryAddress = model.BreweryAddress;
                entity.BreweryDescription = model.BreweryDescription;

                return ctx.SaveChanges() == 1;

            }
        }
            public bool DeleteBrewery(int breweryId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Breweries
                            .Single(e => e.BreweryId == breweryId && e.OwnerId == _userId);

                ctx.Breweries.Remove(entity);

                return ctx.SaveChanges() == 1;
                }
            }
        }
    }
