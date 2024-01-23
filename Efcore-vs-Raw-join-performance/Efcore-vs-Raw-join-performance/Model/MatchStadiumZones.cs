using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model
{
    // keeps track of pushed zones
    public class MatchStadiumZone : EntityBase<Guid>
    {
        public Guid MatchId { get; set; }
        public Guid ZoneId { get; set; }
        public Match Match { get; set; }
        public Zone Zone { get; set; }
        public bool IsPushed { get; set; }

        public MatchStadiumZone MarkAsPushed()
        {
            IsPushed = true;
            return this;
        }
    }
}
