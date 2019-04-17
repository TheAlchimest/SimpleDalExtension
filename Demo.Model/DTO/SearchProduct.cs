using System;

namespace Demo.Model.DTO
{
    public class SearchProduct
    {

        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int CarID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal OfferPrice { get; set; }
        public int ProductTypeID { get; set; }
        public bool IsUsed { get; set; }
        public int StatusID { get; set; }
        private string _MainImage;

        public string MainImage
        {
            get
            {
                if (!string.IsNullOrEmpty(_MainImage))
                {
                    if (_MainImage.ToLower().StartsWith("/images/"))
                    {
                        _MainImage = $"http://admin.shaseh.com{_MainImage}";
                    }
                }
                    return _MainImage;
            }
            set { _MainImage = value; }
        }

        public bool IsFreeShipping { get; set; }
        public string SupplierName { get; set; }

        public Decimal RatingAvrage { get; set; }


        private int _StarsCount = -1;

        public int StarsCount
        {
            get
            {
                if (_StarsCount == -1)
                {
                    if ((RatingAvrage >= 4.5M)) { _StarsCount = 5; }
                    else if ((RatingAvrage >= 3.5M)) { _StarsCount = 4; }
                    else if ((RatingAvrage >= 2.5M)) { _StarsCount = 3; }
                    else if ((RatingAvrage >= 1.5M)) { _StarsCount = 2; }
                    else if ((RatingAvrage >= 0.5M)) { _StarsCount = 1; }
                    else { _StarsCount = 0; }

                }

                return _StarsCount;
            }
        }




    }
}
