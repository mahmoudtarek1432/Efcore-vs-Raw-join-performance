using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;
public class Product : EntityBase<Guid>
{
    public int ProductPrice { get; set; } = 0;
    public string Source { get; set; }
}
