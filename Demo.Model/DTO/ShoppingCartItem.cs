using System;

namespace Demo.Model.DTO
{
    public class ShoppingCartItem
    {
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string MainImage { get; set; }
        public Decimal Price { get; set; }
        public Decimal FullPrice { get; set; }
        public string SupplierName { get; set; }

    }
}
