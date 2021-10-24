using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViTripWeb.Models
{
    public class TourDetailImage
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string Url { get; set; }
    }
}
