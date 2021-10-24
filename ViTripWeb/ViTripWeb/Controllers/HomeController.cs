using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ViTripWeb.Models;

namespace ViTripWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<AnTuongVietNam> catogories = new List<AnTuongVietNam>();
            List<TourDetail> tours = new List<TourDetail>();

            using (var connection = new MySqlConnection("Server=10.1.144.4;Database=vitripdb;Uid=vitrip;Pwd=vitrip;SslMode=none"))
            {
                catogories = connection.Query<AnTuongVietNam>($"SELECT * FROM tbl_an_tuong_vietnam").ToList();

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
