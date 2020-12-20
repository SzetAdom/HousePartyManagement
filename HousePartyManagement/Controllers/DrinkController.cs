using HousePartyManagement.Data;
using HousePartyManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HousePartyManagement.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ILogger<DrinkController> _logger;
        //private HousePartyContext _context;

        public DrinkController(ILogger<DrinkController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            HousePartyContext context = HttpContext.RequestServices.GetService(typeof(HousePartyContext)) as HousePartyContext;

            return View(context.GetAllDrink());
        }

        private List<Drink> GetDrinks() {


            List<Drink> DrinkList = new List<Drink>();

            Drink drink = new Drink();

            Random rnd = new Random();
            
            drink.Name = "Vodka";
            drink.Brand = "Royal";
            drink.Bottle = 1.0;
            drink.Price = rnd.Next(100,30000);
            drink.AlcoholPercentage = 0.35;
            DrinkList.Add(drink);

            drink = new Drink();
            drink.Name = "Tequila";
            drink.Brand = "Sierra";
            drink.Bottle = 0.7;
            drink.Price = rnd.Next(100, 30000);
            drink.AlcoholPercentage = 0.37;
            DrinkList.Add(drink);

            drink = new Drink();
            drink.Name = "Jägermeister";
            drink.Brand = "";
            drink.Bottle = 0.5;
            drink.Price = rnd.Next(100, 30000);
            drink.AlcoholPercentage = 0.36;
            DrinkList.Add(drink);

            return DrinkList;
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