namespace Demo.Model.DomainClasses
{
    public class OrderRequestAddress
    {
        public int OrderRequestAddressID { get; set; }
        public int OrderRequestID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string ShippingNote { get; set; }
        public bool ChangeUserAddressAlso { get; set; }
        public string FullName { get { return FName ?? "" + " " + LName ?? ""; } }

    }
}
