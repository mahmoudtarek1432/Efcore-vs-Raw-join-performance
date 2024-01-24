using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class Row : EntityBase<Guid>
{
    public string? Name { get; set; }
    public int Order { get; set; } = 0;
    public string? Label { get; set; }
    public string? Color { get; set; }
    public string? RowType { get; set; }
    public Guid ZoneId { get; set; }
    public Zone? Zone { get; set; }
    public ICollection<Seat> Seats { get; set; }
}
