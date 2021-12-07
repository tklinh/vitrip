using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ViTripWeb.Models;

namespace ViTripWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration Configuration;
        private string connectionString = string.Empty;

        public HomeController(ILogger<HomeController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            Configuration = _configuration;
            connectionString = this.Configuration.GetConnectionString("VitripDb");
        }

        public IActionResult Index()
        {
            List<AnTuongVietNam> catogories = new List<AnTuongVietNam>();
            List<TourDetail> tours = new List<TourDetail>();

            using (var connection = new MySqlConnection(connectionString))
            {
                catogories = connection.Query<AnTuongVietNam>($"SELECT * FROM tbl_an_tuong_vietnam WHERE active=1 AND location=2").ToList();

                tours = connection.Query<TourDetail>($"SELECT * FROM tbl_tour_detail WHERE categoryId = 1").ToList();
            }

            AnTuongVietNamDto model = new AnTuongVietNamDto
            {
                AnTuongVietNamList = catogories,
                Tours = tours
            };

            return View(model);
        }

        [Route("mice-tour.html")]
        public IActionResult MiceTour()
        {
            return View();
        }

        [Route("team-building.html")]
        public IActionResult TeamBuilding()
        {
            return View();
        }

        [Route("tell-your-stories.html")]
        public IActionResult TellYourStories()
        {
            return View();
        }

        [Route("gui-yeu-cau-tu-van.html")]
        public IActionResult ConsultantRequest()
        {
            return View(true);
        }

        [Route("gui-yeu-cau-tu-van.html")]
        [HttpPost]
        public IActionResult ConsultantRequest(YeuCauTuVan request)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string sqlQuery = "Insert Into tbl_yeu_cau_tu_van(typeId, `from`, `to`, adult, child, baby, date, duration, budget, name, email, phone, birthday, hotelLevel, note, receiveConsultByEmail, receiveNewsByEmail) Values(@TypeId, @From, @To, @Adult, @Child, @Baby, @Date, @Duration, @Budget, @Name, @Email, @Phone, @Birthday, @HotelLevel, @Note, @ReceiveConsultByEmail, @ReceiveNewsByEmail)";

                    int rowsAffected = connection.Execute(sqlQuery, request);
                }
                catch (Exception ex)
                {

                }
            }

            return View(false);
        }

        [Route("huong-dan-thanh-toan.html")]
        public IActionResult PaymentGuide()
        {
            return View();
        }

        [Route("ban-quyen-hinh-anh.html")]
        public IActionResult LicenseGuide()
        {
            return View();
        }

        [Route("chuan-bi-truoc-chuyen-di.html")]
        public IActionResult PreparationGuide()
        {
            return View();
        }

        [Route("chinh-sach-dieu-khoan.html")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("about-us.html")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
