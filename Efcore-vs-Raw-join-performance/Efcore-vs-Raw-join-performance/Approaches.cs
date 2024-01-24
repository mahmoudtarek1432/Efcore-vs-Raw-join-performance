using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Efcore_vs_Raw_join_performance.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efcore_vs_Raw_join_performance
{
    public class Approaches
    {
        [Benchmark]
        public void BenchmarkEfExpression()
        {
            var services = new ServiceCollection();

            services.AddDbContext<EFDatabase>(options => options.UseNpgsql("Server=product-db-instance-1.cwlzjnw8ir2r.eu-central-1.rds.amazonaws.com:5432;User Id=postgres;Password=0ZIo0htr1lRW23;Database=Products"));

            var serviceProvider = services.BuildServiceProvider();

            var _appDbContext = serviceProvider.GetService<EFDatabase>();
            
            var x = _appDbContext.Matches.Include(e => e.Tournament)
                                         .Include(e => e.Stadium)
                                        .ThenInclude(e => e.Zones)
                                        .ThenInclude(e => e.Rows)
                                        .ThenInclude(e => e.Seats)
                                        .ThenInclude(e => e.SeasonalTicketSeatings)
                                        .ThenInclude(e => e.SeasonalTicket)
                                        .Select(e => new MatchStatsDto
                                        {
                                            MatchId = e.Id,
                                            MatchName = e.Title,
                                            TotalNumberOfSeats = e.MatchZones.Select(e => e.Zone).Sum(e => e.Rows.Sum(e => e.Seats.Count)),
                                            NumberOfPushedSeats = e.MatchZones.Where(e => e.IsPushed == true).Select(e => e.Zone).Sum(e => e.Rows.Sum(e => e.Seats.Count)),
                                            TotalNumberOfZones = e.MatchZones.Count(),
                                            NumberOfPushedZones = e.MatchZones.Where(e => e.IsPushed == true).Count(),
                                            NumberOfSeasonalSeats = e.MatchZones.Select(s => s.Zone).Sum(s => s.Rows.Sum(s => s.Seats.Where(s => s.SeasonalTicketSeatings.Any(s => s.SeasonalTicket.SeasonId == e.Tournament.SeasonId)).Count()))
                                        })
                                        .ToList();
        }

        [Benchmark]
        public void BenchmarkNonSelected()
        {
            var services = new ServiceCollection();

            services.AddDbContext<EFDatabase>(options => options.UseNpgsql("Server=product-db-instance-1.cwlzjnw8ir2r.eu-central-1.rds.amazonaws.com:5432;User Id=postgres;Password=0ZIo0htr1lRW23;Database=Products"));

            var serviceProvider = services.BuildServiceProvider();

            var _appDbContext = serviceProvider.GetService<EFDatabase>();

            var x = _appDbContext.Matches.Include(e => e.Tournament)
                                         .Include(e => e.Stadium)
                                        .ThenInclude(e => e.Zones)
                                        .ThenInclude(e => e.Rows)
                                        .ThenInclude(e => e.Seats)
                                        .ThenInclude(e => e.SeasonalTicketSeatings)
                                        .ThenInclude(e => e.SeasonalTicket)
                                        .Select(e => new MatchStatsDto
                                        {
                                            MatchId = e.Id,
                                            MatchName = e.Title,
                                            TotalNumberOfSeats = e.MatchZones.Select(e => e.Zone).Sum(e => e.Rows.Sum(e => e.Seats.Count)),
                                            NumberOfPushedSeats = e.MatchZones.Where(e => e.IsPushed == true).Select(e => e.Zone).Sum(e => e.Rows.Sum(e => e.Seats.Count)),
                                            TotalNumberOfZones = e.MatchZones.Count(),
                                            NumberOfPushedZones = e.MatchZones.Where(e => e.IsPushed == true).Count(),
                                            NumberOfSeasonalSeats = e.MatchZones.Select(s => s.Zone).Sum(s => s.Rows.Sum(s => s.Seats.Where(s => s.SeasonalTicketSeatings.Any(s => s.SeasonalTicket.SeasonId == e.Tournament.SeasonId)).Count()))
                                        })
                                        .ToList();
        }
/*
        [Benchmark]
        public void BrokeDownEF()
        {
            var services = new ServiceCollection();

            services.AddDbContext<EFDatabase>(options => options.UseNpgsql("Server=product-db-instance-1.cwlzjnw8ir2r.eu-central-1.rds.amazonaws.com:5432;User Id=postgres;Password=0ZIo0htr1lRW23;Database=Products"));

            var serviceProvider = services.BuildServiceProvider();

            var _appDbContext = serviceProvider.GetService<EFDatabase>();

            var zones = _appDbContext.MatchStadiumZones.Include(e => e.Match)
                                                       .ThenInclude(e => e.Tournament)
                                                       .Include(e => e.Zone)
                                                       .GroupBy(e => e.MatchId, e => e).ToList();

            var pushed = zones.Select(z => {
                    var zoneIds = z.Select(e => e.ZoneId);
                    var seats = _appDbContext.Seats.Include(e => e.Row)/*.Include(e => e.SeasonalTicketSeatings).ThenInclude(e => e.SeasonalTicket).Where(s => zoneIds.Any(id => id == s.Row.ZoneId)).ToList();
                    return new MatchStatsDto
                    {
                        MatchId = z.Key,
                        TotalNumberOfZones = z.Count(),
                        TotalNumberOfSeats = seats.Count(),
                        NumberOfPushedZones = z.Where(e => e.IsPushed == true).Count(),
                      //  NumberOfSeasonalSeats = seats.Where(e => e.SeasonalTicketSeatings.Any(ss => z.Select(e => e.Match.Tournament.SeasonId).Any(e => e == ss.SeasonalTicket.SeasonId))).Count()
                    };
                }).ToList();

            var x = 10;

        }*/
    }
}
