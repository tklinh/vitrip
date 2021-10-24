using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViTripWeb.Models
{
    public class TourDetailInclude
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string Content { get; set; }
    }
}
