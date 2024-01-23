using Efcore_vs_Raw_join_performance.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Efcore_vs_Raw_join_performance.Model;

public class RuleConfig : EntityBase<Guid>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Value { get; set; }
    public bool IsActive { get; set; }
}
