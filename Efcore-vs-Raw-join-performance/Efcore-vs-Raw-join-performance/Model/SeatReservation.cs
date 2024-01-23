using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class SeatReservation : EntityBase<Guid>
{
    public Guid SeatId { get; set; }
    public Seat Seat { get; set; }
    public Guid MatchId { get; set; }
    public Match Match { get; set; }
    public string BuyerId { get; set; }
}
