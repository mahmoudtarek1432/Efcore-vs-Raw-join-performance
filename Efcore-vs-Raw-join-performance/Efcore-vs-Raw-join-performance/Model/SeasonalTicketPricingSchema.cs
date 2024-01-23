using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class SeasonalTicketPricingSchema : EntityBase<Guid>
{
    public Guid SeasonalTicketId { get; set; }
    public Guid ZoneCategoryId { get; set; }
    public Guid MatchSeaterCategoryId { get; set; }
    public decimal Price { get; set; }
    public SeasonalTicket SeasonalTicket { get; set; }
    public ZoneCategory ZoneCategory { get; set; }
    public MatchSeaterCategory MatchSeaterCategory { get; set; }

}