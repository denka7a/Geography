using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Models.Nature;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Geography.Controllers
{
    public class NatureController : Controller
    {
        private readonly GeographyDbContext context;

        public NatureController(GeographyDbContext context)
        {
            this.context = context;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(NatureViewModel natureModel)
        {
            if (!ModelState.IsValid)
            {
                return View(natureModel); 
            }

            var natureType = this.context.NatureTypes.FirstOrDefault(x => x.Type.ToLower() == natureModel.NatureType.ToLower());

            if (natureType == null)
            {
                return View(natureModel);
            }

            var natureObject = new NatureObject()
            {
                Name = natureModel.Name,
                Information = natureModel.Information,
                URL = natureModel.URL,
                NatureType = natureType
            };

            this.context.Add(natureObject);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Add));
        }
    }
}
