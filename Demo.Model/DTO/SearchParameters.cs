using Demo.Model.Enums;

namespace Demo.Model.DTO
{
    public class SearchParameters
    {
        public int DepartmentID { get; set; }
        public int? SupplierID { get; set; }
        public string Brands { get; set; }
        public string Cars { get; set; }
        public string Categories { get; set; }
        public string Models { get; set; }
        public string ProductTypes { get; set; }
        public string Status { get; set; }
        public string EngineTypes { get; set; }
        public string ProductIndustries { get; set; }
        public string TireSizes { get; set; }
        public string TireWidths { get; set; }
        public string AspectRatios { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int LangId { get; set; }
        public SearchOrderType OrderType { get; set; }

    }
}
