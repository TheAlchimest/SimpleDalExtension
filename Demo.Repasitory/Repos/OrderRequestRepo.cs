using Demo.Model;
using Demo.Model.DomainClasses;
using Demo.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SimpleDalExtension;

namespace Demo.Repasitory
{
    public class OrderRequestRepo 
    {


        #region --------------CreateFullRequestDataFromUserShoppingCart--------------
        //---------------------------------------------------------------------
        //CreateFullRequestDataFromUserShoppingCart
        //---------------------------------------------------------------------
        public OrderRequestFullData CreateFullRequestDataFromUserShoppingCart(int userID, int langId)
        {
            string sp = "[dbo].[OrderRequest_ConvertShoppingCartToOrderRequest]";
            OrderRequestFullData request = new OrderRequestFullData();
            CustomDbParameterList customParameters = new CustomDbParameterList();
            //---------------------------------------------------------------------
            // Set the parameters
            //---------------------------------------------------------------------
            customParameters.Add("@UserID", userID);
            customParameters.Add("@langId", langId);
            SqlParameter isValidParameter = customParameters.AddOutputParameter_Boolean("IsValid");
            //---------------------------------------------------------------------
            // Execute the command
            //---------------------------------------------------------------------
            Dictionary<string, object> multiRecodSet =
                SqlDataHelper.RetrieveMultiRecordSet(
                    sp,
                    customParameters,
                    typeof(OrderRequest),
                    typeof(List<OrderRequsetItem>),
                    typeof(OrderRequestAddress)
                    );

            request.RequsetData = (OrderRequest)multiRecodSet["OrderRequest"];
            request.ItemsList = (List<OrderRequsetItem>)multiRecodSet["OrderRequsetItem"];
            request.ShippingAddress = (OrderRequestAddress)multiRecodSet["OrderRequestAddress"];

            //----------------------------------------------------------------
            //IsValid
            request.IsValid = (bool)isValidParameter.Value;
            return request;
            //----------------------------------------------------------------
        }
        //---------------------------------------------------------------------
        #endregion

        #region --------------ChangeAddress--------------
        //---------------------------------------------------------------------
        //ChangeAddress
        //---------------------------------------------------------------------
        public bool ChangeAddress(OrderRequestAddress ShippingAddress, int userId)
        {
            bool savestats = false;
            try
            {
                string sp = "[dbo].[OrderRequestAddress_ChangeUserAddress]";
                //----------------------------------------------------------------
                CustomDbParameterList customParameters = ShippingAddress.GetMemberParameters(
                e => e.OrderRequestAddressID,
                e => e.FName,
                e => e.LName,
                e => e.CityID,
                e => e.Mobile,
                e => e.Address,
                e => e.ShippingNote,
                e => e.ChangeUserAddressAlso);
                //UserID
                customParameters.Add("@UserID", userId);
                //----------------------------------------------------------------
                SqlDataHelper.ExecuteStoredProcedure(sp, customParameters);
                //----------------------------------------------------------------
                savestats = true;
            }
            catch (Exception ex)
            {
                savestats = false;
            }
            return savestats;
        }
        //---------------------------------------------------------------------
        #endregion

    }
}
