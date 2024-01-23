namespace Efcore_vs_Raw_join_performance.Model.Extentions
{
    public interface ICategorizedPricing
    {
        public ICollection<PricingCategory> Pricings { get; set; }
    }

    public class PricingCategory
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
