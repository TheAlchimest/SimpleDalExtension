using Demo.Model.DomainClasses;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Model.DTO
{
    public class OrderConfirmationFormDto
    {
        public int UserID { get; set; }
        public int OrderRequestID { get; set; }
        public int OrderRequestNo { get; set; }
        public int ShippingMethodID { get; set; }
        public int PaymentMethodID { get; set; }
        public string UserNote { get; set; }
        public int LangId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public bool ChangeUserAddressAlso { get; set; }
        public string FullName { get { return FName ?? "" + " " + LName ?? ""; } }
        public List<City> CitiesList { get; set; }
        public OrderConfirmationFormDto()
        { }

        public OrderConfirmationFormDto(OrderRequestFullData request)
        {
            if (request.IsValid)
            {
                this.UserID = request.RequsetData.UserID;
                this.OrderRequestID = request.RequsetData.OrderRequestID;
                this.OrderRequestNo = request.RequsetData.OrderRequestNo;
                this.ShippingMethodID = request.RequsetData.ShippingMethodID;
                this.PaymentMethodID = request.RequsetData.PaymentMethodID;
                this.UserNote = request.RequsetData.UserNote;
                this.LangId = request.RequsetData.LangId;

                this.FName = request.ShippingAddress.FName;
                this.LName = request.ShippingAddress.LName;
                this.CityID = request.ShippingAddress.CityID;
                this.CityName = request.ShippingAddress.CityName;
                this.Mobile = request.ShippingAddress.Mobile;
                this.Address = request.ShippingAddress.Address;
                this.ChangeUserAddressAlso = request.ShippingAddress.ChangeUserAddressAlso;
            }
        }
}
}
