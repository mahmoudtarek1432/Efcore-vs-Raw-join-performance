using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class Match : EntityBase<Guid>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? MatchPictureUrl { get; set; }
    public string? PublicId { get; set; }
    public DateTime MatchDate { get; set; }
    public DateTime MatchStart { get; set; }
    public DateTime MatchEnd { get; set; }
    public DateTime StartBookingDate { get; set; }
    public DateTime EndBookingDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    public Guid HomeTeamId { get; set; }
    public Team? HomeTeam { get; set; }
    public Guid AwayTeamId { get; set; }
    public Team? AwayTeam { get; set; }
    public Guid TournamentId { get; set; }
    public Tournament? Tournament { get; set; }
    public Guid MatchStatusId { get; set; }
    public MatchStatus? MatchStatus { get; set; }
    public Guid StadiumId { get; set; }
    public Stadium? Stadium { get; set; }
    public Guid MatchCategoryId { get; set; }
    public MatchCategory? MatchCategory { get; set; }
    public ICollection<SeatReservation>? SeatReservations { get; set; }
    public ICollection<MatchSeating>? MatchSeatings { get; set; }
    public ICollection<MatchStadiumZone>? MatchZones { get; set; }
}

public class MatchStatsDto
{
    public Guid MatchId { get; set; }
    public Guid StadiumId { get; set; }
    public string MatchName { get; set; }
    public string StadiumName { get; set; }
    public int TotalNumberOfSeats { get; set; }
    public int NumberOfPushedSeats { get; set; } // seats pushed to the search service
    public int TotalNumberOfZones { get; set; }
    public int NumberOfPushedZones { get; set; }
    public int NumberOfSeasonalSeats { get; set; }
}