using Demo.Model;
using Demo.Model.DomainClasses;
using System;
using SimpleDalExtension;

namespace Demo.Repasitory
{
    public class UserProfileRepo 
    {
        #region --------------AddProfile--------------
        //---------------------------------------------------------------------
        //AddProfile
        //---------------------------------------------------------------------
        public bool AddProfile(User user)
        {
            string sp = "[dbo].[Users_AddProfile]";
            var parameters = user.GetMemberParameters(
                                u => u.UserID,
                                u => u.AspNetUserId,
                                u => u.UserName,
                                u => u.FirstName,
                                u => u.LastName,
                                u => u.UserEmail,
                                u => u.UserMobile,
                                u => u.EmailConfirmed,
                                u => u.RoleID);

            int resultCount = SqlDataHelper.ExecuteStoredProcedure(sp, parameters);
            return (resultCount > 0) ? true : false;
        }
        //---------------------------------------------------------------------
        #endregion

        #region --------------UpdateProfile--------------
        //---------------------------------------------------------------------
        //UpdateProfile
        //---------------------------------------------------------------------
        public bool UpdateProfile(User user)
        {
            string sp = "[dbo].[Users_UpdateProfile]";
            var parameters = user.GetMemberParameters(
                u => u.UserID,
                u => u.FirstName,
                u => u.LastName,
                u => u.UserEmail,
                u => u.UserMobile,
                u => u.CityID,
                u => u.Address);

            int resultCount = SqlDataHelper.ExecuteStoredProcedure(sp, parameters);

            return (resultCount > 0) ? true : false;
        }
        //---------------------------------------------------------------------
        #endregion

        #region --------------GetUserByUserName--------------
        //---------------------------------------------------------------------
        //GetUserByUserName
        //---------------------------------------------------------------------
        public Model.DomainClasses.User GetUserByUserName(string userName)
        {
            string sp = "[dbo].[Users_GetUserByUserName]";
            CustomDbParameterList customParameters = new CustomDbParameterList();
            customParameters.Add("@UserName", userName);
            return SqlDataHelper.RetrieveEntitySingleOrDefault<Model.DomainClasses.User>(sp, customParameters);
           
        }
        //---------------------------------------------------------------------
        #endregion

        #region --------------Old Codes Of update Profile--------------
        //---------------------------------------------------------------------
        //Old Codes Of update Profile
        //---------------------------------------------------------------------

        #region --------------UpdateProfileVersion_1--------------
        /*
        public bool UpdateProfileVersion_1(User user)
        {
            bool result = false;
            using (SqlConnection myConnection = SqlDataHelper.GetSqlConnection())
            {
                try
                {
                    myConnection.Open();

                    using (SqlCommand myCommand = new SqlCommand("[dbo].[Users_UpdateProfile]", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = user.UserID;
                        myCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = user.FirstName;
                        myCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = user.LastName;
                        myCommand.Parameters.Add("@UserEmail", SqlDbType.NVarChar, 256).Value = user.UserEmail;
                        myCommand.Parameters.Add("@UserMobile", SqlDbType.NVarChar, 15).Value = user.UserMobile;
                        myCommand.Parameters.Add("@CityID", SqlDbType.Int, 4).Value = user.CityID.Value;
                        myCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 256).Value = user.Address;
                        int resultCount = myCommand.ExecuteNonQuery();
                        if (resultCount > 0)
                        {
                            result = true;
                        }
                    }
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    result = false;
                }
            }
            return result;
        }
        */
        #endregion

        #region --------------UpdateProfileVersion_2--------------
        /*
    public bool UpdateProfileVersion_2(User user)
    {
        bool result = false;
        try
        {
            //[dbo].[Users_UpdateProfile]
            CustomValuesAsSqlParameterList customParameters = new CustomValuesAsSqlParameterList();
            customParameters.Add("@UserID", user.UserID);
            customParameters.Add("@FirstName", user.FirstName);
            customParameters.Add("@LastName", user.LastName);
            customParameters.Add("@UserEmail", user.UserEmail);
            customParameters.Add("@UserMobile", user.UserMobile);
            customParameters.Add("@CityID", user.CityID.Value);
            customParameters.Add("@Address", user.Address);
            //----------------------------------------------------------------
            int resultCount = SqlDataHelper.ExecuteStoredProcedure("[dbo].[Users_UpdateProfile]", customParameters);
            //----------------------------------------------------------------
            if (resultCount > 0)
            {
                result = true;
            }
        }
        catch (Exception ex)
        {
            result = false;
        }
        return result;
    }
    */
        #endregion

        #region --------------UpdateProfileVersion_3--------------
        /*
    public bool UpdateProfileVersion_3(User user)
    {
        bool result = false;
        CustomDbParameterList customParameters = new CustomDbParameterList();
        customParameters.GenerateParametersFromEntity(user, "UserID,FirstName,LastName,UserEmail,UserMobile,CityID,Address");
        int resultCount = SqlDataHelper.ExecuteStoredProcedure("[dbo].[Users_UpdateProfile]", customParameters);
        return result;
    }*/
        #endregion
        //---------------------------------------------------------------------
        #endregion
    }
}
