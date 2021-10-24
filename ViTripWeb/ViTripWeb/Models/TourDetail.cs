using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViTripWeb.Models
{
    public class TourDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public short CategoryId { get; set; }
        public short GroupId { get; set; }
        public string Url { get; set; }
        public string From { get; set; }
        public string Schedule { get; set; }
        public string Duration { get; set; }
        public string Vehicle { get; set; }
        public string Locations { get; set; }
        public string Description { get; set; }
        public string ThumnailUrl { get; set; }
        public string Include { get; set; }
        public string Exclude { get; set; }
    }
}
