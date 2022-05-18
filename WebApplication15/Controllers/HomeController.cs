using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;
using MySql.Data.MySqlClient;
using Dapper;

namespace WebApplication15.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<User> users = new List<User>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Dapper()
        {
            using (MySqlConnection connection = new MySqlConnection($@"Data Source=database-1.cqrandacnrdj.eu-west-2.rds.amazonaws.com,3306;User ID=admin;Password=12345qwert;Database=DB1"))
            {
                users = connection.Query<User>("SELECT * FROM USER").ToList();
                connection.Open();
                connection.Close();
            }

            return View(users);
        }

        public IActionResult Index()
        {
            return View();
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
