using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class Country : EntityBase<Guid>
{
    public string Name { get; set; }
    public string FlagUrl { get; set; }
    public ICollection<Team> Teams { get; set; }
}
