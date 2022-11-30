﻿using Geography.Data.Data;
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
        private readonly GeographyDbContext context;

        public NatureController(GeographyDbContext context)
        {
            this.context = context;
        }

        public IActionResult All()
        {
            var objects = this.context.NatureObjects.Select(x => new NatureViewModel
            {
                Id = x.Id,
                Name = x.Name,
                NatureType = x.NatureType.Type,
                URL = x.URL,
                Information = x.Information
            }).ToList();

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

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var natureObj = context.NatureObjects.FirstOrDefault(x => x.Id == id);
            
            if (natureObj == null)
            {
                return NotFound();
            }

            var natureType = context.NatureTypes.FirstOrDefault(x => x.Id == natureObj.NatureTypeId);

            return View( new NatureViewModel
            {
                Name = natureObj.Name,
                URL = natureObj.URL,
                Information = natureObj.Information,
                NatureType = natureObj.NatureType.Type
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
            var natureObject = context.NatureObjects.Find(natureModel.Id);
            var natureTypeExist = context.NatureTypes.FirstOrDefault(x => x.Type == natureModel.NatureType);

            if (natureTypeExist == null)
            {
                return RedirectToAction(nameof(Edit));
            }

            natureObject.Id = natureModel.Id;
            natureObject.Information = natureModel.Information;
            natureObject.URL = natureModel.URL;
            natureObject.NatureType = natureTypeExist;

            if (natureObject == null)
            {
                return RedirectToAction(nameof(Edit));
            }
             
            this.context.Update(natureObject);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Edit));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var natureObject = context.NatureObjects.Find(id);

            if (natureObject == null)
            {
                return NotFound();
            }

            context.NatureObjects.Remove(natureObject);
            context.SaveChanges();

            return RedirectToAction(nameof(All));
        }
    }
}
