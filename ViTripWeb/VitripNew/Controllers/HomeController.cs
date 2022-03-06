using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using VitripNew.Models;

namespace VitripNew.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("about-us.html")]
        public IActionResult About()
        {
            return View();
        }

        [Route("gui-yeu-cau-tu-van.html")]
        public IActionResult ConsultantRequest()
        {
            return View(true);
        }

        [Route("mice-tour.html")]
        public IActionResult MiceTour()
        {
            return View();
        }

        [Route("lien-he.html")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("tell-your-stories.html")]
        public IActionResult TellYourStories()
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