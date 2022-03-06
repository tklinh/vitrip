namespace VitripNew.Models
{
    public class TourCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string URLPrefix { get; set; }
        public string BannerImage { get; set; }
        public string Breadcrumb { get; set; }
    }
}
