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
        public async Task<IActionResult> All()
        {
            var objects = await this.service.All();

            return View(objects);
        }
        [Authorize]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(NatureViewModel natureModel)
        {
            if (!ModelState.IsValid)
            {
                return View(natureModel); 
            }

            await service.Add(natureModel);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var natureObj = await service.natureById(id);
            
            if (natureObj == null)
            {
                return NotFound();
            }

            var natureType = await service.typeByNature(natureObj.NatureType);

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
        public async Task<IActionResult> Edit(NatureViewModel natureModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit));
            }

            var natureObject = await service.natureById(natureModel.Id);
            var natureTypeExist = await service.typeByNature(natureModel.NatureType);

            if (natureTypeExist == null)
            {
                return RedirectToAction(nameof(Edit));
            }

            if (natureObject == null)
            {
                return RedirectToAction(nameof(Edit));
            }
             
            var editedNature = await service.Edit(natureModel);
            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (await service.natureById(id) == null)
            {
                return NotFound();
            }

            await service.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
