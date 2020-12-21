using HousePartyManagement.Data;
using HousePartyManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HousePartyManagement.Controllers
{
    [Authorize]
    public class DrinkController : Controller
    {
        private HousePartyContext context;
        public DrinkController()
        {
            
        }

        public IActionResult Index()
        {
            HousePartyContext context = HttpContext.RequestServices.GetService(typeof(HousePartyContext)) as HousePartyContext;

            return View(context.GetAllDrink());
        }

        [HttpPost]
        public ActionResult CreateDrink(Drink model)
        {
            context = HttpContext.RequestServices.GetService(typeof(HousePartyContext)) as HousePartyContext;

            context.CreateDrink(model);

            return RedirectToAction("Index");
        }
        public ActionResult ShowCreateDrink(Drink model)
        {
            return View("CreateDrink", model);
        }
    }
}