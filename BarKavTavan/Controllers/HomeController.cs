using BarKavTavan.Domain;
using BarKavTavan.Models;
using BarKavTavan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace BarKavTavan.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _db;
        private readonly IBlog _b;

        public HomeController(ILogger<HomeController> logger  , DataContext db , IBlog b)
        {
            _logger = logger;
            _db = db;
            _b = b;
        }
      
        public IActionResult Index()
        {
            return View();
        }

        
       public async Task<IActionResult> BlogPost( int p =1)
        {

           
            int pageSize = 6;
            ViewBag.pageNumber = p;
            ViewBag.PaegRange = pageSize;
      


            ViewBag.TotalPage = (int)Math.Ceiling((decimal)_db.Blog.Count() / pageSize);
            return View(await _db.Blog.OrderByDescending(p => p.blogid).Skip((p - 1) * pageSize)
                    .Take(pageSize).ToListAsync());
        }
        public IActionResult complatePost()
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult complatePost(int id)
        {
            var r = _b.getSingleBlog(id); 

            return View(r);
        }

        public IActionResult service()
        {

            return View();
        }
    }
}