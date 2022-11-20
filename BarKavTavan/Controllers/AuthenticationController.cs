using BarKavTavan.Domain.Entities;
using BarKavTavan.Domain.ViewModel;
using BarKavTavan.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System.Security.Claims;
using System.Security.Principal;

namespace BarKavTavan.Controllers
{

    public class AuthenticationController : Controller
    {
        private readonly IUser _u;

        public AuthenticationController(IUser u )
        {
            _u = u;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(LogInViewModel Vm)
        {
           if(ModelState.IsValid)
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

                    var Identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

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


                        //    return RedirectToAction("Index", "Admin");
                        //}
                        //else
                        //{
                        return RedirectToAction("Index", "Home");
                    }


                }

            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel Vm)
        {
            if (ModelState.IsValid)
            {
                if (!_u.MobileNumberExist(Vm.Mobile))
                {
                    RedirectToAction("logIn");
                }
                User uu = new User()
                {
                    Roleid = 2,
                    Code = Utility.ActiveCode(),
                    isActive = false,
                    UserName = Vm.UserName,
                    password = Utility.HashPssword(Vm.password),
                    Email = Vm.email,
                    Mobile = Vm.Mobile,
                    
                };
                _u.AddUser(uu);

            }
            return RedirectToAction("Index","Home");
        }

        public IActionResult Active()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Active(ActiveViewModel Vm)
        {
            if (_u.Actived(Vm.Codeactive) == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Register");
        }
    }
}
