using Microsoft.AspNetCore.Mvc;

namespace BarKavTavan.Controllers
{
    public class AboutController : Controller    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult aboutus()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }
    }
}
