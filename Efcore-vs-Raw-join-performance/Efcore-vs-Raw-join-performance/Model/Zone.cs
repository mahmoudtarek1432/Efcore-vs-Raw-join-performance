using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class Zone : EntityBase<Guid>
{
    public Zone()
    {
        Rows = new HashSet<Row>();
    }
    public string Name { get; set; }
    public string Label { get; set; }
    public string Color { get; set; }
    public int Order { get; set; } = 0;
    public string ZoneType { get; set; }
    public Guid? ZoneCategoryId { get; set; }
    public bool SeatsUpdated { get; set; }
    public ZoneCategory ZoneCategory { get; set; }
    public Guid StadiumId { get; set; }
    public Stadium Stadium { get; set; }
    public Hospitality? Hospitality { get; set; }
    public ICollection<Row>? Rows { get; set; }
    public ICollection<MatchStadiumZone> MatchZones { get; set; }
}
