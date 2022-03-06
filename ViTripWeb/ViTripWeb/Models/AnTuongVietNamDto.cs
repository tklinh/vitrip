using System.Collections.Generic;
using ViTripWeb.Models;

namespace ViTrip.Models
{
    public class AnTuongVietNamDto
    {
        public List<AnTuongVietNam> AnTuongVietNamList { get; set; }
        public List<TourDetail> Tours { get; set; }
    }
}
