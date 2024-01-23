using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class MatchCategory : EntityBase<Guid>
{
    public string Name { get; set; }
    public ICollection<Match> Matches { get; set; }
    public ICollection<MatchSeaterPricingSchema> MatchSeaterPricingSchemas { get; set; }
}