using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model
{
    public class SeasonalTicket : EntityBase<Guid>
    {
        public string Name { get; set; }
        //unique
        public Guid StadiumId { get; set; }
        public Guid SeasonId { get; set; }
        public ICollection<Tournament> Tournaments { get; set; }
        public Stadium Stadium { get; set; }
        public Season Season { get; set; }
        public ICollection<SeasonalTicketSeating> SeasonalTicketSeatings { get; set; }
        public ICollection<SeasonalTicketPricingSchema> seasonalTicketPricings { get; set; }

    }
}
