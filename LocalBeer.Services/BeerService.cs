using LocalBeer.Data;
using LocalBeer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBeer.Services
{
    public class BeerService
    {
        private readonly Guid _userId;

        public BeerService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateBeer(BeerCreate beer)
        {
            var entity =
                new Beer()
                {
                    OwnerId = _userId,
                    BeerName = beer.BeerName,
                    BeerRating = beer.BeerRating,
                    BeerType = beer.BeerType,
                    OrderDateUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Beers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BeerListItem> GetBeers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Beers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new BeerListItem
                                {
                                    BeerId = e.BeerId,
                                    BeerName = e.BeerName,
                                    BeerType = e.BeerType,
                                    CreatedUtc = e.OrderDateUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public BeerDetail GetBeerById(int beerId)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Beers
                        .Single(e => e.BeerId == beerId && e.OwnerId == _userId);
                return
                    new BeerDetail
                    {
                        BeerId = entity.BeerId,
                        BeerName = entity.BeerName,
                        BeerRating = entity.BeerRating,
                        BeerType = entity.BeerType,
                        CreatedUtc = entity.OrderDateUtc,
                    };
            }
        }

        public bool UpdateNote(BeerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Beers
                        .Single(e => e.BeerId == model.BeerId && e.OwnerId == _userId);

                entity.BeerName = model.BeerName;
                entity.BeerRating = model.BeerRating;
                entity.ModifiedOrder = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteNote(int beerId)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Beers
                        .Single(e => e.BeerId == beerId && e.OwnerId == _userId);
                ctx.Beers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

            public bool UpdateBeer(BeerEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Beers
                            .Single(e => e.BeerId == model.BeerId && e.OwnerId == _userId);

                entity.BeerName = model.BeerName;
                entity.BeerType = model.BeerType;
                entity.BeerId = model.BeerId;
                entity.ModifiedOrder = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }

            }
            public bool DeleteBeer(int beerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Beers
                        .Single(e => e.BeerId == beerId && e.OwnerId == _userId);

                ctx.Beers.Remove(entity);

                 return ctx.SaveChanges() == 1;
            }
        }

    }

        }
    
        
        
    




