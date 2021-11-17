using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViTripWeb.Models
{
    public class TourDetailDto
    {
        public TourCategory TourCategory { get; set; }
        public TourDetail TourInfo { get; set; }
        public List<TourDetail> RelatedTours { get; set; }
        public List<TourDetailImage> Images { get; set; }
        public List<TourDetailInclude> Includes { get; set; }
        public List<TourDetailExclude> Excludes { get; set; }
    }
}
