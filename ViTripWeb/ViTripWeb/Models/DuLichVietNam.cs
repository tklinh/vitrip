using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViTripWeb.Models
{
    public class DuLichVietNam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Ordinal { get; set; }
        public string BannerImage { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
