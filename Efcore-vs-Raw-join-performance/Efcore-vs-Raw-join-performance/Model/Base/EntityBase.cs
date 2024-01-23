using Efcore_vs_Raw_join_performance.Model.Extentions;

namespace Efcore_vs_Raw_join_performance.Model.Base
{
    public class EntityBase<IDType> : IEntity, ICUTracking where IDType : struct
    {
        public IDType Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
    }
}
