using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class ZoneCategory : EntityBase<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Label { get; set; }
    public Guid StadiumId { get; set; }
    public Stadium Stadium { get; set; }
    public ICollection<Zone> Zones { get; set; }
    public ICollection<MatchSeaterPricingSchema> MatchSeaterPricingSchemas { get; set; }
}
