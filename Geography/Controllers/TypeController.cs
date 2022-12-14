using Geography.Contracts;
using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Models.Type;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Geography.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeService service;
        public TypeController(ITypeService service)
        {
            this.service = service;
        }

        public IActionResult All()
        {
            var types = this.service.AllTypes();

            return View(types);
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(TypeViewModel typeModel)
        {
            if (!ModelState.IsValid)
            {
                return View(typeModel);
            }

            service.AddType(typeModel);

            return RedirectToAction(nameof(Add));
        }
    }
}
