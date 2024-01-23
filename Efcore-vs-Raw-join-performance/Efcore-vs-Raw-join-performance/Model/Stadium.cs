using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class Stadium : EntityBase<Guid>
{
    public Stadium()
    {
        Zones = new HashSet<Zone>();
    }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public bool Home { get; set; }
    public ICollection<Zone> Zones { get; set; }
    public ICollection<SeasonalTicket> SeasonalTickets { get; set; }
    public ICollection<Season> Seasons { get; set; }
    public ICollection<Hospitality> Hospitalities { get; set; }
}
