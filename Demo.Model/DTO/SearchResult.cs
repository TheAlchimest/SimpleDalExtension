using Demo.Model.DTO;
using System.Collections.Generic;

namespace Demo.Model.DTO
{
    public class SearchResult
    {
        public List<SearchFilter> FiltersList { get; set; }
        public List<SearchProduct> ProductList { get; set; }
        public int AvailableProductCount { get; set; }
        public ElsPaging Pagination { get; set; }

        public SearchResult()
        {

            FiltersList = new List<SearchFilter>();
            ProductList = new List<SearchProduct>();
        }
    }

}