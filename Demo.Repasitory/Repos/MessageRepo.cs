using Demo.Model.DTO;
using Demo.Model.Enums;
using SimpleDalExtension;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;


namespace Demo.Repasitory
{
    //public class MessageRepo : GenericShasehRepository<Models.Message, Ef.Message>, IMessageRepo
    public class MessageRepo 
    {

        #region --------------AddUserMessage--------------
        //---------------------------------------------------------------------
        //AddUserMessage
        //---------------------------------------------------------------------
        public EnumMessageInsertionResult AddUserMessage(MessageDto msg)
        {
            string sp = "[dbo].[Message_AddUserMessage]";
            var parameters = msg.GetMemberParameters(
                                u => u.MessageTypeID,
                                u => u.ThreadID,
                                u => u.Title,
                                u => u.Details,
                                u => u.OrderID,
                                u => u.UserID,
                                u => u.MessageStatusID);

            EnumMessageInsertionResult result = (EnumMessageInsertionResult)SqlDataHelper.ExecuteScalarStoredProcedure(sp, parameters);
            return result;
        }
        //---------------------------------------------------------------------
        #endregion


        //[dbo].[Message_AddUserMessage]

        #region --------------GetMessagesByOrderIdForUser--------------
        //---------------------------------------------------------------------
        //GetMessagesByOrderIdForUser
        //---------------------------------------------------------------------
        public List<MessageDto> GetMessagesByOrderIdForUser(int orderId)
        {
            string sp = "[dbo].[Message_GetMessagesByOrderIdForUser]";
            CustomDbParameterList customParameters = new CustomDbParameterList();
            // Set the parameters
            //---------------------------------------------------------------------
            customParameters.Add("@OrderId", orderId);
            List<MessageDto> list =
                SqlDataHelper.RetrieveEntityList<MessageDto>(sp, customParameters);
            //---------------------------------------------------------------------
            return list;
        }
        //---------------------------------------------------------------------
        #endregion
    }
}
