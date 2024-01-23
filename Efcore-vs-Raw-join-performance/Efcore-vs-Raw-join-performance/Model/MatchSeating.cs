using Efcore_vs_Raw_join_performance.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Efcore_vs_Raw_join_performance.Model;

public class MatchSeating : EntityBase<Guid>
{
    public Guid MatchId { get; set; }
    public Match Match { get; set; }
    public Guid SeatId { get; set; }
    public Seat Seat { get; set; }
    public bool IsHome { get; set; }
}
