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
    public class SnackController : Controller
    {
        private HousePartyContext context;
        public SnackController()
        {
        }

        public IActionResult Index()
        {
            HousePartyContext context = HttpContext.RequestServices.GetService(typeof(HousePartyContext)) as HousePartyContext;

            return View(context.GetSnacks());
        }

        [HttpPost]
        public ActionResult CreateSnack(Snack model)
        {

            context = HttpContext.RequestServices.GetService(typeof(HousePartyContext)) as HousePartyContext;

            context.CreateSnack(model);

            return RedirectToAction("Index");
        }
        public ActionResult ShowCreateSnack(Snack model)
        {
            return View("CreateSnack", model);
        }
    }
}