using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class MatchSeaterPricingSchema : EntityBase<Guid>
{
    public Guid MatchCategoryId { get; set; }
    public Guid ZoneCategoryId { get; set; }
    public Guid MatchSeaterCategoryId { get; set; }
    public decimal Price { get; set; }
    public MatchCategory MatchCategory { get; set; }
    public ZoneCategory ZoneCategory { get; set; }
    public MatchSeaterCategory MatchSeaterCategory { get; set; }

}