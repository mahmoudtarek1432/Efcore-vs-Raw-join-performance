using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

// pricing per Seater Category e.g. Adult Child Student
public class MatchSeaterCategory : EntityBase<Guid>
{
    public string Name { get; set; } // Adult child , student
    public ICollection<MatchSeaterPricingSchema> MatchSeaterPricingSchemas { get; set; }
}

