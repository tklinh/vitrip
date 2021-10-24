using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using ViTripWeb.Models;

namespace ViTripWeb.Controllers
{    
    public class DuLichVietNamController : Controller
    {
        private IConfiguration Configuration;
        private string connectionString = string.Empty;

        public DuLichVietNamController(IConfiguration _configuration)
        {
            Configuration = _configuration;
            connectionString = this.Configuration.GetConnectionString("VitripDb");
        }

        [Route("du-lich-vietnam")]
        [Route("du-lich-vietnam/{page}")]
        public IActionResult Index(string page = "dong-tay-bac")
        {
            DuLichVietNam tour = new DuLichVietNam();

            using (var connection = new MySqlConnection(connectionString))
            {
                tour = connection.Query<DuLichVietNam>($"SELECT * FROM tbl_du_lich_vietnam WHERE URL = '{page}'").FirstOrDefault();
            }

            return View(tour);
        }
    }
}
