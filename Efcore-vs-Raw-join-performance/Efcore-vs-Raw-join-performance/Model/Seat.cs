using Efcore_vs_Raw_join_performance.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Efcore_vs_Raw_join_performance.Model;

public class Seat : EntityBase<Guid>
{
    public Guid RowId { get; set; }
    [NotMapped]
    //public Guid StadiumId { get; set; }
    public string? Name { get; set; }
    public int Order { get; set; } = 0;
    public string? Label { get; set; }
    public string? CreatedBy { get; set; }
    public Row? Row { get; set; }
    public ICollection<SeatReservation> SeatReservations { get; set; }
    public ICollection<SeasonalTicketSeating> SeasonalTicketSeatings { get; set; }

    
}
