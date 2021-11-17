using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViTripWeb.Models
{
    public class TourCategoryDto
    {
        public TourCategory TourCategory { get; set; }

        public List<TourDetail> Tours { get; set; }
    }
}
