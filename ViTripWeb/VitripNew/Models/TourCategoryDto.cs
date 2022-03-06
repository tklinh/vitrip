namespace VitripNew.Models
{
    public class TourCategoryDto
    {
        public TourCategory TourCategory { get; set; }

        public List<TourDetail> Tours { get; set; }
    }
}
