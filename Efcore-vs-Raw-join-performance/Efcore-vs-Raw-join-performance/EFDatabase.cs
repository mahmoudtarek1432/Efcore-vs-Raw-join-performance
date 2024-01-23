using Efcore_vs_Raw_join_performance.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Efcore_vs_Raw_join_performance
{
    public class EFDatabase : DbContext
    {
        public EFDatabase(DbContextOptions opt) : base(opt) { }
        public DbSet<Model.Match> Matches { get; set; }
        public DbSet<MatchStatus> MatchStatuses { get; set; }
        public DbSet<MatchCategory> MatchCategories { get; set; }
        public DbSet<MatchSeaterCategory> MatchSeaterCategories { get; set; }
        public DbSet<MatchSeaterPricingSchema> MatchSeaterPricingSchemas { get; set; }
        public DbSet<MatchSeating> MatchSeatings { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatReservation> SeatReservations { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentTeam> TournamentTeams { get; set; }
        public DbSet<TournamentType> TournamentTypes { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<ZoneCategory> ZoneCategories { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<MatchStadiumZone> MatchStadiumZones { get; set; }
        public DbSet<SeasonalTicket> SeasonalTickets { get; set; }
        public DbSet<SeasonalTicketSeating> SeasonalTicketSeatings { get; set; }
        public DbSet<SeasonalTicketPricingSchema> SeasonalTicketPricingSchemas { get; set; }
        public DbSet<Hospitality> Hospitalities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SeatReservation>()
            .HasIndex(s => new { s.SeatId, s.MatchId })
            .IsUnique();

            modelBuilder.Entity<TournamentTeam>()
           .HasIndex(s => new { s.TeamId, s.TournamentId })
           .IsUnique();

            modelBuilder.Entity<Team>()
            .HasMany(t => t.AwayMatches)
            .WithOne(t => t.AwayTeam)
            .HasForeignKey(t => t.AwayTeamId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
            .HasMany(t => t.HomeMatches)
            .WithOne(t => t.HomeTeam)
            .HasForeignKey(t => t.HomeTeamId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Model.Match>()
            .HasIndex(m => new { m.HomeTeamId, m.AwayTeamId, m.TournamentId })
            .IsUnique();

            modelBuilder.Entity<MatchSeaterPricingSchema>()
            .HasIndex(m => new { m.ZoneCategoryId, m.MatchCategoryId, m.MatchSeaterCategoryId })
            .IsUnique();

            modelBuilder.Entity<SeasonalTicketPricingSchema>()
              .HasIndex(m => new { m.ZoneCategoryId, m.SeasonalTicketId, m.MatchSeaterCategoryId })
              .IsUnique();

            modelBuilder.Entity<Hospitality>()
                .HasIndex(s => new { s.Name, s.StadiumId })
                .IsUnique();

            modelBuilder.Entity<Country>()
                .HasIndex(n => n.Name).IsUnique();

            modelBuilder.Entity<TournamentType>()
                .HasIndex(t => t.Name).IsUnique();

            modelBuilder.Entity<MatchStatus>()
                .HasIndex(m => m.Name).IsUnique();

            modelBuilder.Entity<Stadium>()
                .HasIndex(s => s.Name).IsUnique();

            modelBuilder.Entity<Model.Match>()
                .HasMany(e => e.MatchZones)
                .WithOne(e => e.Match)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Zone>()
                .HasMany(e => e.MatchZones)
                .WithOne(e => e.Zone)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Zone>()
                .HasOne(a => a.Hospitality)
                .WithOne(a => a.Zone)
                .HasForeignKey<Hospitality>(c => c.ZoneId);

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                            .SelectMany(t => t.GetForeignKeys())
                            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            modelBuilder.Entity<SeasonalTicketSeating>()
                 .HasIndex(s => new { s.SeatId, s.SeasonalTicketId }).IsUnique();

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }

    }
}
