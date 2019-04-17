namespace Demo.Model.DomainClasses
{
    public class OrderAddress
    {
        public int OrderAddressID { get; set; }
        public int OrderID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int CityID { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string ShippingNote { get; set; }
    }
}
