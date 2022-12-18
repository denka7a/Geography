using Geography.Contracts;
using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Models.Nature;
using Geography.Models.Type;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml.Linq;

namespace Geography.Controllers
{
    public class NatureController : Controller
    {
        private readonly INatureService service;
        public NatureController(INatureService service)
        {
            this.service = service;
        }
        [Authorize]
        public IActionResult All()
        {
            var objects = this.service.All();

            return View(objects);
        }
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add(NatureViewModel natureModel)
        {
            if (!ModelState.IsValid)
            {
                return View(natureModel); 
            }

            service.Add(natureModel);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var natureObj = service.natureById(id);
            
            if (natureObj == null)
            {
                return NotFound();
            }

            var natureType = service.typeByNature(natureObj.NatureType);

            return View( new NatureViewModel
            {
                Name = natureObj.Name,
                URL = natureObj.URL,
                Information = natureObj.Information,
                NatureType = natureType.Type
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(NatureViewModel natureModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit));
            }

            var natureObject = service.natureById(natureModel.Id);
            var natureTypeExist = service.typeByNature(natureModel.NatureType);

            if (natureTypeExist == null)
            {
                return RedirectToAction(nameof(Edit));
            }

            if (natureObject == null)
            {
                return RedirectToAction(nameof(Edit));
            }
             
            var editedNature = service.Edit(natureModel);
            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            if (service.natureById(id) == null)
            {
                return NotFound();
            }

            service.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
