using Demo.Model.DomainClasses;
using Demo.Model.DTO;
using Demo.Model.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SimpleDalExtension;


namespace Demo.Repasitory
{
    public class OrderRepo 
    {
        #region --------------ConvertOrderRequestToFinalOrder--------------
        //---------------------------------------------------------------------
        //ConvertOrderRequestToFinalOrder
        //---------------------------------------------------------------------
        public bool ConvertOrderRequestToFinalOrder(OrderConfirmationFormDto request)
        {
            bool isValid = false;
            string sp = "[dbo].[Order_ConvertOrderRequestToFinalOrder]";
            //Prepare Parameters-----------------------------------------------
            CustomDbParameterList customParameters = request.GetMemberParameters(
            r => r.UserID,
            r => r.PaymentMethodID,
            r => r.ShippingMethodID,
            r => r.OrderRequestID,
            r => r.LangId,
            r => r.UserNote,
            r => r.FName,
            r => r.LName,
            r => r.CityID,
            r => r.Mobile,
            r => r.Address,
            //r => r.ShippingNote,
            r => r.ChangeUserAddressAlso);
            //customParameters.Add("@ShippingNote", request.UserNote);
            //IsValid
            SqlParameter IsValidOutputParameter = customParameters.AddOutputParameter_Boolean("@IsValid");

            //---------------------------------------------------------------------
            SqlDataHelper.ExecuteStoredProcedure(sp, customParameters);
            //----------------------------------------------------------------
            //IsValid
            isValid = (bool)IsValidOutputParameter.Value;
            return isValid;
        }
        //---------------------------------------------------------------------
        #endregion

        #region --------------GetFullOrderDataWithDetails--------------
        //---------------------------------------------------------------------
        //GetFullOrderDataWithDetails
        //---------------------------------------------------------------------
        public OrderDataWithDetails GetFullOrderDataWithDetails(int userId, int orderId, int langId)
        {
            OrderDataWithDetails order = new OrderDataWithDetails();
            CustomDbParameterList customParameters = new CustomDbParameterList();
            //
            string sp = "[dbo].[Order_GetFullOrderDataWithDetails]";
            //---------------------------------------------------------------------
            // Set the parameters
            //---------------------------------------------------------------------
            customParameters.Add("@UserID", userId);
            customParameters.Add("@OrderId", orderId);
            customParameters.Add("@langId", langId);
            //---------------------------------------------------------------------
            // Execute the command
            //---------------------------------------------------------------------
            Dictionary<string, object> multiRecodSet =
                SqlDataHelper.RetrieveMultiRecordSet(
                    sp,
                    customParameters,
                    typeof(Order),
                    typeof(List<OrderItem>),
                    typeof(OrderAddress)

                    );

            order.OrderData = (Order)multiRecodSet["Order"];
            order.ItemsList = (List<OrderItem>)multiRecodSet["OrderItem"];
            order.ShippingAddress = (OrderAddress)multiRecodSet["OrderAddress"];
            //----------------------------------------------------------------
            return order;
        }
        //---------------------------------------------------------------------
        #endregion

        #region --------------GetUserOrders--------------
        //---------------------------------------------------------------------
        //GetUserOrders
        //---------------------------------------------------------------------
        public List<OrderDataDto> GetUserOrders(int UserId, int LangId, int PageIndex, int PageSize, out int TotalRecords)
        {
            string sp = "[dbo].[Order_GetUserOrders]";
            CustomDbParameterList customParameters = new CustomDbParameterList();
            // Set the parameters
            //---------------------------------------------------------------------
            customParameters.Add("@UserId", UserId);
            customParameters.Add("@LangId", LangId);
            customParameters.Add("@PageIndex", PageIndex);
            customParameters.Add("@PageSize", PageSize);
            SqlParameter totalRecordsParameter = customParameters.AddOutputParameter_Integer("TotalRecords");
            //---------------------------------------------------------------------
            // Execute the command
            //---------------------------------------------------------------------
            List<OrderDataDto> list =
                SqlDataHelper.RetrieveEntityList<OrderDataDto>(sp, customParameters);
            //---------------------------------------------------------------------
            //Gets result rows count
            TotalRecords = (int)totalRecordsParameter.Value;
            //----------------------------------------------------------------
            return list;
        }
        //---------------------------------------------------------------------
        #endregion

        #region --------------ChangeOrderStatus--------------
        //---------------------------------------------------------------------
        //ChangeOrderStatus
        //---------------------------------------------------------------------
        public bool ChangeOrderStatus(int orderID, EnumOrderStatus orderStatusID, float totalPaied, string adminNote)
        {
            bool savestats = false;
            try
            {
                //[dbo].[Order_ChangeOrderStatus]
            string sp = "[dbo].[Order_ChangeOrderStatus]";
                CustomDbParameterList customParameters = new CustomDbParameterList();
                //----------------------------------------------------------------
                customParameters.Add("@OrderID", orderID);
                customParameters.Add("@OrderStatusID", orderStatusID);
                customParameters.Add("@TotalPaied", totalPaied);
                customParameters.Add("@AdminNote", adminNote);
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
