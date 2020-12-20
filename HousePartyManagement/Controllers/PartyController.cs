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

        public IActionResult Edit(int? id)
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

            context.UpdatePartyLocation(model);

            return RedirectToAction("Index");
        }

        //public IActionResult New()
        //{

        //    return View(context.GetAllParty());
        //}
    }
}
