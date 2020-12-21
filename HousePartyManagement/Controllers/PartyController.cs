using HousePartyManagement.Data;
using HousePartyManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousePartyManagement.Controllers
{
    [Authorize]
    public class PartyController : Controller
    {
        private HousePartyContext context;
        public PartyController(){
        }

        public IActionResult Index()
        {
            this.context = HttpContext.RequestServices.GetService(typeof(HousePartyContext)) as HousePartyContext;

            return View(this.context.GetAllParty());
        }

        public IActionResult More(int? id)
        {
            context = HttpContext.RequestServices.GetService(typeof(HousePartyContext)) as HousePartyContext;

            if (id.HasValue)
            {
                Party model = context.GetPartyById(id.Value);
                if(model != null)
                {
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Party model)
        {
            context = HttpContext.RequestServices.GetService(typeof(HousePartyContext)) as HousePartyContext;

            context.UpdatePartyOrganiser(model);
            context.UpdatePartyLocation(model);
            context.UpdatePartyCapacity(model);
            context.UpdatePartyTime(model);

            return RedirectToAction("Index");
        }

        public IActionResult ShowEdit(int? id)
        {
            context = HttpContext.RequestServices.GetService(typeof(HousePartyContext)) as HousePartyContext;

            if (id.HasValue)
            {
                Party model = context.GetPartyById(id.Value);
                if (model != null)
                {
                    return View("Edit", model);
                }
                else return RedirectToAction("Index");
            }
            else return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Party model)
        {
            context = HttpContext.RequestServices.GetService(typeof(HousePartyContext)) as HousePartyContext;

            context.CreateParty(model);

            return RedirectToAction("Index");
        }

        public ActionResult ShowCreate(Party model) {
            return View("Create", model);
        }

        [HttpPost]
        public void GetArraySnack(string data)
        {
            context = HttpContext.RequestServices.GetService(typeof(HousePartyContext)) as HousePartyContext;
            Snack snack = new Snack();

            System.Diagnostics.Debug.WriteLine(data);

            System.Diagnostics.Debug.WriteLine("adat:" + data);
            string[] tmp = data.Split(":");
            snack.Name = tmp[0];
            snack.Price = Convert.ToInt32(tmp[1]);
            snack.Count = Convert.ToInt32(tmp[2]);

            snack.Brand = "Brand";
            snack.Weight = "1";
            context.CreateSnack(snack);
            int id = context.GetSnackIdByName(snack.Name);
            context.AddSnackToParty(Convert.ToInt32(tmp[3]), id, snack.Count);
        }

        [HttpPost]
        public void GetArrayDrink(string data)
        {
            context = HttpContext.RequestServices.GetService(typeof(HousePartyContext)) as HousePartyContext;
            Drink drink = new Drink();

            System.Diagnostics.Debug.WriteLine(data);

            System.Diagnostics.Debug.WriteLine("adat:" + data);
            string[] tmp = data.Split(":");
            drink.Name = tmp[0];
            drink.Price = Convert.ToInt32(tmp[1]);
            drink.Bottle = Convert.ToInt32(tmp[2]);

            drink.Comment = "C";
            drink.AlcoholPercentage = "1";
            context.CreateDrink(drink);
            int id = context.GetDrinkIdByName(drink.Name);
            context.AddDrinkToParty(Convert.ToInt32(tmp[3]), id, drink.Bottle);
        } 
    }
}
