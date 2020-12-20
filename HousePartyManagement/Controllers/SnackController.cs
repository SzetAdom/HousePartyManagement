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
        private readonly ILogger<SnackController> _logger;

        public SnackController(ILogger<SnackController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(GetSnacks());
        }

        private List<Snack> GetSnacks()
        {


            List<Snack> SnackList = new List<Snack>();

            Snack snack = new Snack();

            Random rnd = new Random();

            snack.Name = "Csokis Keksz";
            snack.Brand = "Pilóta";
            snack.Price = rnd.Next(100, 30000);
            SnackList.Add(snack);

            return SnackList;
        }

        //[HttpPost]
        //public ActionResult Search(List<Drink> model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Index");
        //    }

        //    return View("Index", model.Where(drink => drink.Name == model[model.Count-1].Name));
        //}

    }
}