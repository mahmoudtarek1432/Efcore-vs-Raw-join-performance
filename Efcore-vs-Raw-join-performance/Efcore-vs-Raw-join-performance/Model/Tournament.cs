using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class Tournament : EntityBase<Guid>
{
    public Tournament()
    {
        Matches = new HashSet<Match>();
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
    public string PublicId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    public ICollection<Match> Matches { get; set; }
    public Guid TournamentTypeId { get; set; }
    public TournamentType TournamentType { get; set; }
    public Guid SeasonId { get; set; }
    public Season Season { get; set; }
    public Guid? SeasonalTicketId { get; set; }
    public SeasonalTicket SeasonalTicket { get; set; }
    public ICollection<TournamentTeam> TournamentTeams { get; set; }
}
