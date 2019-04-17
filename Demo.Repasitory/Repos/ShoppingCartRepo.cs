using Demo.Model;
using Demo.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SimpleDalExtension;

namespace Demo.Repasitory
{
    public class ShoppingCartRepo 
    {


        #region --------------AddItemAndReturnList--------------
        //---------------------------------------------------------------------
        //AddItemAndReturnList
        //---------------------------------------------------------------------
        public List<ShoppingCartItem> AddItemAndReturnList(int langId, int userId, int productID, int quantity)
        {
            string sp = "[dbo].[ShoppingCart_AddItemAndReturnList]";
            CustomDbParameterList customParameters = new CustomDbParameterList();
            // Set the parameters
            customParameters.Add("@langId", langId);
            customParameters.Add("@UserID", userId);
            customParameters.Add("@ProductID", productID);
            customParameters.Add("@Quantity", quantity);
            List<ShoppingCartItem> shoppingCartItems =
            SqlDataHelper.RetrieveEntityList<ShoppingCartItem>(sp, customParameters);
            return shoppingCartItems;
        }
        //---------------------------------------------------------------------
        #endregion

        #region --------------GetShortShoppingCart--------------
        //---------------------------------------------------------------------
        //GetShortShoppingCart
        //---------------------------------------------------------------------
        public List<ShoppingCartItem> GetShortShoppingCart(int langId, int userId)
        {

            string sp = "[dbo].[ShoppingCart_GetShortShoppingCart]";
            CustomDbParameterList customParameters = new CustomDbParameterList();
            customParameters.Add("@langId", langId);
            customParameters.Add("@UserID", userId);
            List<ShoppingCartItem> shoppingCartItems = SqlDataHelper.RetrieveEntityList<ShoppingCartItem>(sp, customParameters);
            return shoppingCartItems;

        }
        //---------------------------------------------------------------------
        #endregion

        #region --------------GetFullShoppingCart--------------
        //---------------------------------------------------------------------
        //GetFullShoppingCart
        //---------------------------------------------------------------------
        public List<ShoppingCartItem> GetFullShoppingCart(int langId, int userId)
        {
            string sp = "[dbo].[ShoppingCart_GetFullShoppingCart]";
            CustomDbParameterList customParameters = new CustomDbParameterList();
            customParameters.Add("@langId", langId);
            customParameters.Add("@UserID", userId);
            List<ShoppingCartItem> shoppingCartItems =
            SqlDataHelper.RetrieveEntityList<ShoppingCartItem>(sp, customParameters);
            //---------------------------------------------------------------------
            return shoppingCartItems;
        }
        //---------------------------------------------------------------------
        #endregion

        #region --------------UpdateCart--------------
        //---------------------------------------------------------------------
        //UpdateCart
        //---------------------------------------------------------------------
        public bool UpdateCart(int userId, List<ShoppingCartItem> items)
        {
            bool savestats = false;
            string sp1_RemoveAllItems = "[dbo].[ShoppingCart_RemoveAllItems]";
            string sp2_AddItemWithOutReturnCount = "[dbo].[ShoppingCart_AddItemWithOutReturnCount]";

            using (SqlConnection myConnection = SqlDataHelper.GetSqlConnection())
            {
                SqlTransaction transaction = null;
                try
                {
                    myConnection.Open();
                    transaction = myConnection.BeginTransaction();

                    using (SqlCommand myCommand = new SqlCommand(sp1_RemoveAllItems, myConnection, transaction))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userId;
                        myCommand.ExecuteNonQuery();
                    }
                    using (SqlCommand myCommand = new SqlCommand(sp2_AddItemWithOutReturnCount, myConnection, transaction))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userId;
                        myCommand.Parameters.Add("@ProductID", SqlDbType.Int, 4);
                        myCommand.Parameters.Add("@Quantity", SqlDbType.Int, 4);
                        foreach (var item in items)
                        {
                            myCommand.Parameters["@ProductID"].Value = item.ProductID;
                            myCommand.Parameters["@Quantity"].Value = item.Quantity;
                            myCommand.ExecuteNonQuery();
                        }

                    }
                    transaction.Commit();
                    myConnection.Close();
                    savestats = true;
                }
                catch (Exception ex)
                {
                    // Attempt to roll back the transaction.
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                    }
                }
            }
            return savestats;
        }
        //---------------------------------------------------------------------
        #endregion

    }
}
