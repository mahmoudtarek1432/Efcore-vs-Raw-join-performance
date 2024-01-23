using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class Season : EntityBase<Guid>
{
    public Season()
    {
        Tournaments = new HashSet<Tournament>();
    }

    public string Name { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public Guid? StadiumId { get; set; }
    public Stadium Stadium { get; set; }
    public virtual ICollection<Tournament> Tournaments { get; set; }
    public virtual ICollection<SeasonalTicket> SeasonalTickets { get; set; }
}
