using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class TournamentTeam : EntityBase<Guid>
{
    public Guid TeamId { get; set; }
    public Team Team { get; set; }
    public Guid TournamentId { get; set; }
    public Tournament Tournament { get; set; }
}
