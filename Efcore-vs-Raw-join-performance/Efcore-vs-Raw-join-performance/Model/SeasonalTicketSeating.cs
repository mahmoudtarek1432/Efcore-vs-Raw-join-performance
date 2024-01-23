using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model
{
    public class SeasonalTicketSeating : EntityBase<Guid>
    {
        //unique
        public Guid SeatId { get; set; }
        public Guid SeasonalTicketId { get; set; }
        public SeasonalTicket SeasonalTicket { get; set; }
        public Seat Seat { get; set; }
    }
}
