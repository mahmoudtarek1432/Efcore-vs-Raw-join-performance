using Efcore_vs_Raw_join_performance.Model.Base;

namespace Efcore_vs_Raw_join_performance.Model
{
    public sealed class Hospitality : EntityBase<Guid>
    {
        //stadium and name shall be unique
        public string Name { get; set; }
        public Guid StadiumId { get; set; }
        public Guid? ZoneId { get; set; } //if the hospitality had a zoneId, then the hospitality shall not get displayed in regular seat hospitality selection
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string PublicId { get; set; }
        public Stadium Stadium { get; set; }
        public Zone Zone { get; set; }
    }
}
