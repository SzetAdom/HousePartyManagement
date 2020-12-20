using HousePartyManagement.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousePartyManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private UserManager<User> _userManager;
        public HomeController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            string model = _userManager.GetUserName(this.User).ToString();
            return View();
        }
    }
}
