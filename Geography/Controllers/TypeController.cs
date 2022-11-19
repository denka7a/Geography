using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Models.Type;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Geography.Controllers
{
    public class TypeController : Controller
    {
        private readonly GeographyDbContext context;
        public TypeController(GeographyDbContext context)
        {
            this.context = context;
        }

        public IActionResult All()
        {
            var types = this.context.NatureTypes.Select(x => new TypeViewModel
            {
                Type = x.Type,
            }).ToList();

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

            var isExistType = this.context.NatureTypes.FirstOrDefault(x => x.Type == typeModel.Type);

            if (isExistType != null)
            {
                return View(typeModel);
            }

            var name = this.User.Identity.Name;
            var user = this.context.Users.First(x => x.UserName == name);

            var type = new NatureType()
            {
                Type = typeModel.Type,
                UserId = user.Id,
            };

            this.context.Add(type);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Add));
        }
    }
}
