using Efcore_vs_Raw_join_performance.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Efcore_vs_Raw_join_performance.Model;

public class TournamentType : EntityBase<Guid>
{
    public TournamentType()
    {
        Tournaments = new HashSet<Tournament>();
    }
    public string Name { get; set; }
    public ICollection<Tournament> Tournaments { get; set; }
}
