using Geography.Contracts;
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
        [Authorize]
        public async Task<IActionResult> All()
        {
            var types = await this.service.AllTypes();

            return View(types);
        }

        [Authorize]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(TypeViewModel typeModel)
        {
            if (!ModelState.IsValid)
            {
                return View(typeModel);
            }

            await service.AddType(typeModel);

            return RedirectToAction(nameof(Add));
        }
    }
}
