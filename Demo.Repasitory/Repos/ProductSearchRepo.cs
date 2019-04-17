using Demo.Model;
using Demo.Model.DTO;
using SimpleDalExtension;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Demo.Repasitory
{
    public class ProductSearchRepo 
    {

        #region --------------GetFiltersWithProducts--------------
        //---------------------------------------------------------------------
        //GetFiltersWithProducts
        //---------------------------------------------------------------------
        public SearchResult GetFiltersWithProducts(SearchParameters parameters)
        {
            SearchResult result = new SearchResult();

            string sp = "[dbo].[Search_GetFiltersWithProducts]";
            //[dbo].[Search_GetFiltersWithProducts]
            //Prepare Parameters-----------------------------------------------
            CustomDbParameterList customParameters = new CustomDbParameterList();
            //---------------------------------------------------------------------
            //DepartmentID
            if (parameters.DepartmentID > 0)
            {
                customParameters.Add("@DepartmentID", parameters.DepartmentID);
            }
            //---------------------------------------------------------------------
            //SupplierID
            if (parameters.SupplierID.HasValue && parameters.SupplierID> 0)
            {
                customParameters.Add("@SupplierID", parameters.SupplierID);
            }
            //---------------------------------------------------------------------
            //Brands
            if (!string.IsNullOrEmpty(parameters.Brands))
            {
                customParameters.Add("@Brands", parameters.Brands);
            }
            //---------------------------------------------------------------------
            //Cars
            if (!string.IsNullOrEmpty(parameters.Cars))
            {
                customParameters.Add("@Cars", parameters.Cars);
            }
            //---------------------------------------------------------------------
            //Categories
            if (!string.IsNullOrEmpty(parameters.Categories))
            {
                customParameters.Add("@Categories", parameters.Categories);
            }
            //---------------------------------------------------------------------
            //Models
            if (!string.IsNullOrEmpty(parameters.Models))
            {
                customParameters.Add("@Models", parameters.Models);
            }
            //---------------------------------------------------------------------
            //ProductTypes
            if (!string.IsNullOrEmpty(parameters.ProductTypes))
            {
                customParameters.Add("@ProductTypes", parameters.ProductTypes);
            }
            //---------------------------------------------------------------------
            //Status
            if (!string.IsNullOrEmpty(parameters.Status))
            {
                customParameters.Add("@Status", parameters.Status);
            }
            //---------------------------------------------------------------------
            //EngineTypes
            if (!string.IsNullOrEmpty(parameters.EngineTypes))
            {
                customParameters.Add("@EngineTypes", parameters.EngineTypes);
            }
            //---------------------------------------------------------------------
            //ProductIndustries
            if (!string.IsNullOrEmpty(parameters.ProductIndustries))
            {
                customParameters.Add("@ProductIndustries", parameters.ProductIndustries);
            }
            //---------------------------------------------------------------------
            //TireSizes
            if (!string.IsNullOrEmpty(parameters.TireSizes))
            {
                customParameters.Add("@TireSizes", parameters.TireSizes);
            }
            //---------------------------------------------------------------------
            //TireWidths
            if (!string.IsNullOrEmpty(parameters.TireWidths))
            {
                customParameters.Add("@TireWidths", parameters.TireWidths);
            }
            //---------------------------------------------------------------------
            //AspectRatios
            if (!string.IsNullOrEmpty(parameters.AspectRatios))
            {
                customParameters.Add("@AspectRatios", parameters.AspectRatios);
            }
            //---------------------------------------------------------------------
            //PriceFrom
            if (parameters.PriceFrom.HasValue)
            {
                customParameters.Add("@PriceFrom", parameters.PriceFrom);
            }
            //---------------------------------------------------------------------
            //PriceTo
            if (parameters.PriceTo.HasValue)
            {
                customParameters.Add("@PriceTo", parameters.PriceTo);
            }
            //---------------------------------------------------------------------
            //PageIndex
            customParameters.Add("@PageIndex", parameters.PageIndex);
            //---------------------------------------------------------------------
            //PageSize
            customParameters.Add("@PageSize", parameters.PageSize);
            //---------------------------------------------------------------------
            //LangId
            if (parameters.LangId > 0)
            {
                customParameters.Add("@LangId", parameters.LangId);
            }
            //---------------------------------------------------------------------
            //SearchOrderType
            customParameters.Add("@SearchOrderType", parameters.OrderType);
            //---------------------------------------------------------------------
            //---------------------------------------------------------------------
            //TotalRecords
            SqlParameter totalRecordsParameter = customParameters.AddOutputParameter_Integer("TotalRecords");

            //---------------------------------------------------------------------
            // Execute the command
            //---------------------------------------------------------------------
            Dictionary<string, object> multiRecodSet =
                SqlDataHelper.RetrieveMultiRecordSet(
                    sp,
                    customParameters,
                    typeof(List<SearchFilter>),
                    typeof(List<SearchProduct>)
                    );

            result.FiltersList = (List<SearchFilter>)multiRecodSet["SearchFilter"];
            result.ProductList = (List<SearchProduct>)multiRecodSet["SearchProduct"];
            //----------------------------------------------------------------
            //Gets result rows count
            result.AvailableProductCount = (int)totalRecordsParameter.Value;
            //if we didn't get atrue value from database for any reson 
            //may be there is no data
            if (result.AvailableProductCount < 0)
            {
                result.AvailableProductCount = result.ProductList.Count;
            }
            //----------------------------------------------------------------
            return result;
        }
        //---------------------------------------------------------------------
        #endregion

        #region --------------GetProductsOnly--------------
        //---------------------------------------------------------------------
        //GetProductsOnly
        //---------------------------------------------------------------------
        public SearchResult GetProductsOnly(SearchParameters searchParameters)
        {
            SearchResult result = new SearchResult();

            string sp = "[dbo].[Search_GetProductsOnly]";
            //Prepare Parameters-----------------------------------------------
            CustomDbParameterList customParameters = new CustomDbParameterList();
            //---------------------------------------------------------------------
            if (searchParameters.DepartmentID > 0)
            {
                customParameters.Add("@DepartmentID", searchParameters.DepartmentID);
            }
            //---------------------------------------------------------------------
            //SupplierID
            if (searchParameters.SupplierID.HasValue && searchParameters.SupplierID > 0 )
            {
                customParameters.Add("@SupplierID", searchParameters.SupplierID);
            }
            //---------------------------------------------------------------------
            //Brands
            if (!string.IsNullOrEmpty(searchParameters.Brands))
            {
                customParameters.Add("@Brands", searchParameters.Brands);
            }
            //---------------------------------------------------------------------
            //Cars
            if (!string.IsNullOrEmpty(searchParameters.Cars))
            {
                customParameters.Add("@Cars", searchParameters.Cars);
            }
            //---------------------------------------------------------------------
            //Categories
            if (!string.IsNullOrEmpty(searchParameters.Categories))
            {
                customParameters.Add("@Categories", searchParameters.Categories);
            }
            //---------------------------------------------------------------------
            //Models
            if (!string.IsNullOrEmpty(searchParameters.Models))
            {
                customParameters.Add("@Models", searchParameters.Models);
            }
            //---------------------------------------------------------------------
            //ProductTypes
            if (!string.IsNullOrEmpty(searchParameters.ProductTypes))
            {
                customParameters.Add("@ProductTypes", searchParameters.ProductTypes);
            }
            //---------------------------------------------------------------------
            //Status
            if (!string.IsNullOrEmpty(searchParameters.Status))
            {
                customParameters.Add("@Status", searchParameters.Status);
            }
            //---------------------------------------------------------------------
            //EngineTypes
            if (!string.IsNullOrEmpty(searchParameters.EngineTypes))
            {
                customParameters.Add("@EngineTypes", searchParameters.EngineTypes);
            }
            //---------------------------------------------------------------------
            //ProductIndustries
            if (!string.IsNullOrEmpty(searchParameters.ProductIndustries))
            {
                customParameters.Add("@ProductIndustries", searchParameters.ProductIndustries);
            }
            //---------------------------------------------------------------------
            //TireSizes
            if (!string.IsNullOrEmpty(searchParameters.TireSizes))
            {
                customParameters.Add("@TireSizes", searchParameters.TireSizes);
            }
            //---------------------------------------------------------------------
            //TireWidths
            if (!string.IsNullOrEmpty(searchParameters.TireWidths))
            {
                customParameters.Add("@TireWidths", searchParameters.TireWidths);
            }
            //---------------------------------------------------------------------
            //AspectRatios
            if (!string.IsNullOrEmpty(searchParameters.AspectRatios))
            {
                customParameters.Add("@AspectRatios", searchParameters.AspectRatios);
            }
            //---------------------------------------------------------------------
            //PriceFrom
            if (searchParameters.PriceFrom.HasValue)
            {
                customParameters.Add("@PriceFrom", searchParameters.PriceFrom);
            }
            //---------------------------------------------------------------------
            //PriceTo
            if (searchParameters.PriceTo.HasValue)
            {
                customParameters.Add("@PriceTo", searchParameters.PriceTo);
            }
            //---------------------------------------------------------------------
            //PageIndex
            customParameters.Add("@PageIndex", searchParameters.PageIndex);
            //---------------------------------------------------------------------
            //PageSize
            customParameters.Add("@PageSize", searchParameters.PageSize);
            //---------------------------------------------------------------------
            //LangId
            if (searchParameters.LangId > 0)
            {
                customParameters.Add("@LangId", searchParameters.LangId);
            }
            //---------------------------------------------------------------------
            //SearchOrderType
            customParameters.Add("@SearchOrderType", searchParameters.OrderType);
            //---------------------------------------------------------------------
            //TotalRecords
            SqlParameter totalRecordsParameter = customParameters.AddOutputParameter_Integer("TotalRecords");

            //---------------------------------------------------------------------
            // Execute the command
            //---------------------------------------------------------------------
            result.ProductList = SqlDataHelper.RetrieveEntityList<SearchProduct>(sp, customParameters);
            //-----------------------------
            //Gets result rows count
            result.AvailableProductCount = (int)totalRecordsParameter.Value;
            //if we didn't get atrue value from database for any reson 
            //may be there is no data
            if (result.AvailableProductCount < 0)
            {
                result.AvailableProductCount = result.ProductList.Count;
            }
            //----------------------------------------------------------------
            return result;
        }
        //---------------------------------------------------------------------
        #endregion

        #region --------------GetSearrchBoxFilters--------------
        //---------------------------------------------------------------------
        //GetSearrchBoxFilters
        //---------------------------------------------------------------------
        public List<SearchFilter> GetSearrchBoxFilters(SearchParameters parameters)
        {
            string sp = "[dbo].[Search_GetFiltersWithProducts]";
            //[dbo].[Search_GetFiltersWithProducts]
            CustomDbParameterList customParameters = new CustomDbParameterList();
            // Set the searchParameters
            //---------------------------------------------------------------------
            //DepartmentID
            customParameters.Add("@DepartmentID", parameters.DepartmentID);
            //---------------------------------------------------------------------
            //SupplierID
            if (parameters.SupplierID.HasValue)
            {
                customParameters.Add("@SupplierID", parameters.SupplierID);
            }
            //---------------------------------------------------------------------
            //Brands
            if (!string.IsNullOrEmpty(parameters.Brands))
            {
                customParameters.Add("@Brands", parameters.Brands);
            }
            //---------------------------------------------------------------------
            //Cars
            if (!string.IsNullOrEmpty(parameters.Cars))
            {
                customParameters.Add("@Cars", parameters.Cars);
            }
            //---------------------------------------------------------------------
            //Categories
            if (!string.IsNullOrEmpty(parameters.Categories))
            {
                customParameters.Add("@Categories", parameters.Categories);
            }
            //---------------------------------------------------------------------
            //Models
            if (!string.IsNullOrEmpty(parameters.Models))
            {
                customParameters.Add("@Models", parameters.Models);
            }
            //---------------------------------------------------------------------
            //ProductTypes
            if (!string.IsNullOrEmpty(parameters.ProductTypes))
            {
                customParameters.Add("@ProductTypes", parameters.ProductTypes);
            }
            //---------------------------------------------------------------------
            //Status
            if (!string.IsNullOrEmpty(parameters.Status))
            {
                customParameters.Add("@Status", parameters.Status);
            }
            //---------------------------------------------------------------------
            //EngineTypes
            if (!string.IsNullOrEmpty(parameters.EngineTypes))
            {
                customParameters.Add("@EngineTypes", parameters.EngineTypes);
            }
            //---------------------------------------------------------------------
            //ProductIndustries
            if (!string.IsNullOrEmpty(parameters.ProductIndustries))
            {
                customParameters.Add("@ProductIndustries", parameters.ProductIndustries);
            }
            //---------------------------------------------------------------------
            //TireSizes
            if (!string.IsNullOrEmpty(parameters.TireSizes))
            {
                customParameters.Add("@TireSizes", parameters.TireSizes);
            }
            //---------------------------------------------------------------------
            //TireWidths
            if (!string.IsNullOrEmpty(parameters.TireWidths))
            {
                customParameters.Add("@TireWidths", parameters.TireWidths);
            }
            //---------------------------------------------------------------------
            //AspectRatios
            if (!string.IsNullOrEmpty(parameters.AspectRatios))
            {
                customParameters.Add("@AspectRatios", parameters.AspectRatios);
            }
            //---------------------------------------------------------------------
            //PriceFrom
            if (parameters.PriceFrom.HasValue)
            {
                customParameters.Add("@PriceFrom", parameters.PriceFrom);
            }
            //---------------------------------------------------------------------
            //PriceTo
            if (parameters.PriceTo.HasValue)
            {
                customParameters.Add("@PriceTo", parameters.PriceTo);
            }
            //---------------------------------------------------------------------
            //LangId
            customParameters.Add("@LangId", parameters.LangId);
            //---------------------------------------------------------------------
            // Execute the command
            //---------------------------------------------------------------------
            List<SearchFilter> result = SqlDataHelper.RetrieveEntityList<SearchFilter>(sp, customParameters);
            //---------------------------------------------------------------------
            //return the result
            return result;
        }
        //---------------------------------------------------------------------
        #endregion

    }
}
