namespace Demo.Model.DTO
{
    public class MessageDto 
    {
        public int MessageID { get; set; }
        public int MessageTypeID { get; set; }
        public int ThreadID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int MessageStatusID { get; set; }
        public string UserFullName { get; set; }
    }
}
