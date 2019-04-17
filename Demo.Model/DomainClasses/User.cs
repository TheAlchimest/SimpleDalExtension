namespace Demo.Model.DomainClasses
{
    using System;

    public class User
    {

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleID { get; set; }
        public string UserEmail { get; set; }
        public string UserMobile { get; set; }
        public string UserPhone { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string PrefixCode { get; set; }
        public bool EmailConfirmed { get; set; }
        public int AccessFailedCount { get; set; }
        public bool UserMobileConfirmed { get; set; }
        public string AspNetUserId { get; set; }
        public Nullable<int> CityID { get; set; }
        public string Address { get; set; }


    }
}
