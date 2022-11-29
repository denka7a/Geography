using Geography.Data.Data;
using Geography.Data.Models;
using Geography.Models.Shop;
using Microsoft.AspNetCore.Mvc;

namespace Geography.Controllers
{
    public class ShopController : Controller
    {
        private readonly GeographyDbContext context;

        public ShopController(GeographyDbContext context)
        {
            this.context = context;
        }

        public IActionResult AllSouvenirs()
        {
            var souvenirs = context.Souvenirs.Select(x => new SouvenirViewModel
            {
                Id = x.Id,
                Name = x.Name,
                URL = x.URL,
                Price = x.Price
            }).ToList();

            return View(souvenirs);
        }

        public IActionResult AddSouvenir()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSouvenir(SouvenirViewModel model)
        {
            var name = this.User.Identity.Name;
            var user = this.context.Users.First(x => x.UserName == name);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var souvenir = new Souvenir()
            {
                Name = model.Name,
                URL = model.URL,
                Price = model.Price,
                UserId = user.Id
            };

            this.context.Souvenirs.Add(souvenir);
            this.context.SaveChanges();

            return RedirectToAction(nameof(AllSouvenirs));
        }

        public IActionResult Buy(int id)
        {
            var souvenir = context.Souvenirs.Find(id);
            var souvenirPrice = souvenir.Price;

            if (souvenir == null)
            {
                return BadRequest("Not Found");
            }
            var name = this.User.Identity.Name;
            var user = this.context.Users.First(x => x.UserName == name);

            if (souvenir.Price > user.Balance)
            {
                return BadRequest("No enought money");
            }

            var userSouvenir = new UserSouvenir
            {
                UserId = user.Id,
                SouvenirId = souvenir.Id
            };

            user.UserSouvenirs.Add(userSouvenir);

            user.Balance -= souvenirPrice;
            context.SaveChanges();
            return RedirectToAction(nameof(AllSouvenirs));
        }
    }
}
