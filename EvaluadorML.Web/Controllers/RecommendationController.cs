using Microsoft.AspNetCore.Mvc;
using EvaluadorML.Core.Services;
using System.IO;

namespace EvaluadorML.Web.Controllers
{
    public class RecommendationController : Controller
    {
        private static RecommendationService _service;

        public RecommendationController()
        {
            if (_service == null)
            {
                var dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "ratings-data.csv");
                _service = new RecommendationService(dataPath);
            }
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(string userId)
        {
            var products = _service.Recommend(userId);
            ViewBag.Products = products;
            return View();
        }
    }
}
