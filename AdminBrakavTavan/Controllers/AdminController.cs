using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BarKavTavan.Services;
using BarKavTavan.Domain.ViewModel;
using BarKavTavan.Domain.Entities;

namespace AdminBrakavTavan.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUser _u;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBlog _b;
       

        public AdminController(IUser u, IBlog b, IHttpContextAccessor httpContextAccessor)
        {
            _u = u;
            _b = b;
            
            _httpContextAccessor = httpContextAccessor;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LogInViewModel Vm)
        {
            if (ModelState.IsValid)
            {
                var res = _u.Login(Vm.Mobile, Vm.password);
           
                if (res != null)
                {

                    var claim = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier,res.Userid.ToString()),
                            new Claim(ClaimTypes.Name,res.UserName),
                            new Claim(ClaimTypes.Role , res.Roleid.ToString())
                        };

                    var Identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults
                                   .AuthenticationScheme);

                    var principal = new ClaimsPrincipal(new[] { Identity });
                    Thread.CurrentPrincipal = principal;
                    HttpContext.SignInAsync(principal);
                    HttpContext.User = principal;

                    var r = principal.FindFirstValue(ClaimTypes.Name);
                    var Rolename = principal.FindFirstValue(ClaimTypes.Role);
                    string key = "role";
                    HttpContext.Session.SetString(key, Rolename.ToString());

                    string b = "sa";
                    HttpContext.Session.SetString(b, r.ToString());

                    var e = _u.getRoleName(res.Roleid);
                    if ((_u.getRoleName(res.Roleid)) == "admin")
                    {

                        return RedirectToAction("PostBlog", "Admin");

                    }

                }
            }
            return View();
        }




        public IActionResult Postblog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PostBlog(blogs blog)
        {
            if (HttpContext.User.Identity.IsAuthenticated == true)
            {
                var getrolename = _httpContextAccessor.HttpContext.Session.GetString("sa");

                ////get name iamge

                var fi = HttpContext.Request.Form.Files;
                var imagename = Guid.NewGuid().ToString() + Path.GetExtension(fi[0].FileName);
                var SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images",
                     imagename);
                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    fi[0].CopyTo(stream);
                }




                /////add post
                blogs newblog = new blogs()
                {

                    description = blog.description,
                    titleb = blog.titleb,
                    litledes = blog.litledes,
                    image = imagename,
                    datetime = DateTime.UtcNow,
                    Username = getrolename,
                    Roleid = 1,
                };
                _b.addBlog(newblog);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }





        }


        
       
        



    }

}


