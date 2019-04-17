namespace Demo.Model.DTO
{
    public class SearchFilter
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsSelected { get; set; }
        public int FilterType { get; set; }
    }

}