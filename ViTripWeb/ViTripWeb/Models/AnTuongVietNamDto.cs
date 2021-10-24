using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViTripWeb.Models
{
    public class AnTuongVietNamDto
    {
        public List<AnTuongVietNam> AnTuongVietNamList { get; set; }
        public List<TourDetail> Tours { get; set; }
    }
}
