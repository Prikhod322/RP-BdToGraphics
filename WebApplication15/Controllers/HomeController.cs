using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;


namespace WebApplication15.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Dapper()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Categories.Add(new Category {Name = "epfke" });
                db.Products.Add(new Product { Name = "a", Description = "b", Price = "c", CategoryID = db.Categories.ToList()[0]});
                db.SaveChanges();

                ViewBag.Category = db.Categories.ToList();
                ViewBag.Product = db.Products.ToList();
                return View();
            }

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
