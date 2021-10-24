using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViTripWeb.Models;

namespace ViTripWeb.Controllers
{
    public class TourController : Controller
    {
        private IConfiguration Configuration;
        private string connectionString = string.Empty;

        public TourController(IConfiguration _configuration)
        {
            Configuration = _configuration;
            connectionString = this.Configuration.GetConnectionString("VitripDb");
        }

        //[Route("du-lich-vietnam")]
        //[Route("du-lich-vietnam/{page}")]
        //public IActionResult Index(string page = "dong-tay-bac")
        //{
        //    DuLichVietNam tour = new DuLichVietNam();

        //    using (var connection = new MySqlConnection("Server=35.188.122.6;Database=vitripdb;Uid=vitrip;Pwd=vitrip;"))
        //    {
        //        tour = connection.Query<DuLichVietNam>($"SELECT * FROM tbl_du_lich_vietnam WHERE URL = '{page}'").FirstOrDefault();
        //    }

        //    return View(tour);
        //}

        [Route("an-tuong-vietnam")]
        [Route("an-tuong-vietnam/{tourUrl}")]
        public IActionResult Index(string tourUrl)
        {
            TourDetail tour = new TourDetail();
            List<TourDetail> relatedTours = new List<TourDetail>();
            List<TourDetailImage> images = new List<TourDetailImage>();
            List<TourDetailInclude> includes = new List<TourDetailInclude>();
            List<TourDetailExclude> excludes = new List<TourDetailExclude>();

            using (var connection = new MySqlConnection(connectionString))
            {
                tour = connection.Query<TourDetail>($"SELECT * FROM tbl_tour_detail WHERE URL = 'an-tuong-vietnam/{tourUrl}'").FirstOrDefault();
                relatedTours = connection.Query<TourDetail>($"SELECT * FROM tbl_tour_detail WHERE groupId = {tour.GroupId} and id != {tour.Id}").ToList();
                images = connection.Query<TourDetailImage>($"SELECT * FROM tbl_tour_detail_image WHERE tourId = {tour.Id}").ToList();
                includes = connection.Query<TourDetailInclude>($"SELECT * FROM tbl_tour_detail_include WHERE tourId = {tour.Id}").ToList();
                excludes = connection.Query<TourDetailExclude>($"SELECT * FROM tbl_tour_detail_exclude WHERE tourId = {tour.Id}").ToList();
            }

            TourDetailDto model = new TourDetailDto
            {
                TourInfo = tour,
                RelatedTours = relatedTours,
                Images = images,
                Includes = includes,
                Excludes = excludes
            };

            return View(model);
        }
    }
}
