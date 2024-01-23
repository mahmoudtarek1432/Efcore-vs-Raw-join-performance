using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model;

public class Voucher : EntityBase<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string VoucherLogoUrl { get; set; }

}
