// See https://aka.ms/new-console-template for more information
using Efcore_vs_Raw_join_performance;
using Efcore_vs_Raw_join_performance.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();

services.AddDbContext<EFDatabase>(options => options.UseNpgsql("Server=localhost:5432;User Id=postgres;Password=postgrespw;Database=products"));

var serviceProvider = services.BuildServiceProvider();

var _appDbContext = serviceProvider.GetService<EFDatabase>();

var x = _appDbContext.Matches.Include(e => e.Tournament)
                             .Include(e => e.Stadium)
                            .ThenInclude(e => e.Zones)
                            .ThenInclude(e => e.Rows)
                            .ThenInclude(e => e.Seats)
                            .ThenInclude(e => e.SeasonalTicketSeatings)
                            .ThenInclude(e => e.SeasonalTicket)
                            .ToList()
                            .Select(e =>
                            {
                                return new MatchStatsDto
                                {
                                    MatchId = e.Id,
                                    MatchName = e.Title,
                                    TotalNumberOfSeats = e.MatchZones.Select(e => e.Zone).Sum(e => e.Rows.Sum(e => e.Seats.Count)),
                                    NumberOfPushedSeats = e.MatchZones.Where(e => e.IsPushed == true).Select(e => e.Zone).Sum(e => e.Rows.Sum(e => e.Seats.Count)),
                                    TotalNumberOfZones = e.MatchZones.Count(),
                                    NumberOfPushedZones = e.MatchZones.Where(e => e.IsPushed == true).Count(),
                                    NumberOfSeasonalSeats = e.MatchZones.Select(s => s.Zone).Sum(s => s.Rows.Sum(s => s.Seats.Where(s => s.SeasonalTicketSeatings.Any(s => s.SeasonalTicket.SeasonId == e.Tournament.SeasonId)).Count()))
                                };

                            });

Console.WriteLine("match data");