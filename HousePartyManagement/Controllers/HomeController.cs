using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousePartyManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return Redirect("~/Party");
            }
            return View();
        }

        public IActionResult Login()
        {
            return Redirect("~/Identity/Account/Login");
        }

        public IActionResult Register()
        {
            return Redirect("~/Identity/Account/Register");
        }
    }
}
