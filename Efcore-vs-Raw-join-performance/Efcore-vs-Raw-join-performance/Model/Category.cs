using Efcore_vs_Raw_join_performance.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace Efcore_vs_Raw_join_performance.Model
{
    public class Category : EntityBase<Guid>
    {
        [Key]
        public Guid MatchId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Zone> Zones { get; set; }
        public Match Match { get; set; }

    }
}
