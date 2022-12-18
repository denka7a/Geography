using Geography.Contracts;
using Geography.Data.Data;
using Geography.Data.Models;
using Geography.Models.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Geography.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService service;

        public ShopController(IShopService service)
        {
            this.service = service;
        }
        [Authorize]
        public IActionResult AllSouvenirs()
        {
            var souvenirs = this.service.AllSouvenirs();

            return View(souvenirs);
        }

        [Authorize]
        public IActionResult AddSouvenir()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddSouvenir(SouvenirViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.service.AddSouvenir(model);
            return RedirectToAction(nameof(AllSouvenirs));
        }

        [Authorize]
        public IActionResult Buy(int id)
        {
            bool isMoneyEnought = service.BuySouvenir(id);

            if (!isMoneyEnought)
            {
                return BadRequest("Not enought money");
            }
            
            return RedirectToAction(nameof(AllSouvenirs));
        }
    }
}
