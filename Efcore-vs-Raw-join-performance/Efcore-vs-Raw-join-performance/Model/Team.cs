using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;
public class Team : EntityBase<Guid>
{
    public string Name { get; set; }
    public string LogoUrl { get; set; }
    public string PublicId { get; set; }
    public Guid NationalityId { get; set; }
    public Country Nationality { get; set; }
    public ICollection<TournamentTeam> TournamentTeams { get; set; }
    public ICollection<Match> AwayMatches { get; set; }
    public ICollection<Match> HomeMatches { get; set; }
}
