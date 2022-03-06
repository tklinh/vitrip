using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using VitripNew.Models;

namespace VitripNew.Controllers
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

        [Route("{tourCategory}/{tourUrl}.html")]
        public IActionResult Detail(string tourCategory, string tourUrl)
        {
            TourCategory category = new TourCategory();
            TourDetail tour = new TourDetail();
            List<TourDetail> relatedTours = new List<TourDetail>();
            List<TourDetailImage> images = new List<TourDetailImage>();
            List<TourDetailInclude> includes = new List<TourDetailInclude>();
            List<TourDetailExclude> excludes = new List<TourDetailExclude>();

            using (var connection = new MySqlConnection(connectionString))
            {
                tour = connection.Query<TourDetail>($"SELECT * FROM tbl_tour_detail WHERE URL = '{tourUrl}'").FirstOrDefault();
                //category = connection.Query<TourCategory>($"SELECT * FROM tbl_an_tuong_vietnam WHERE id = '{tour.GroupId}'").FirstOrDefault();
                relatedTours = connection.Query<TourDetail>($"SELECT * FROM tbl_tour_detail WHERE groupId = {tour.GroupId} and id != {tour.Id}").ToList();
                images = connection.Query<TourDetailImage>($"SELECT * FROM tbl_tour_detail_image WHERE tourId = {tour.Id}").ToList();
                includes = connection.Query<TourDetailInclude>($"SELECT * FROM tbl_tour_detail_include WHERE tourId = {tour.Id}").ToList();
                excludes = connection.Query<TourDetailExclude>($"SELECT * FROM tbl_tour_detail_exclude WHERE tourId = {tour.Id}").ToList();
            }

            TourDetailDto model = new TourDetailDto
            {
                TourCategory = category,
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
