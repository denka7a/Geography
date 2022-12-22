using Geography.Contracts;
using Geography.Models.Shop;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> AllSouvenirs()
        {
            var souvenirs = await this.service.AllSouvenirs();

            return View(souvenirs);
        }

        [Authorize]
        public async Task<IActionResult> AddSouvenir()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddSouvenir(SouvenirViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.service.AddSouvenir(model);
            return RedirectToAction(nameof(AllSouvenirs));
        }

        [Authorize]
        public async Task<IActionResult> Buy(int id)
        {
            bool isMoneyEnought = await service.BuySouvenir(id);

            if (!isMoneyEnought)
            {
                return BadRequest();
            }
            
            return RedirectToAction(nameof(AllSouvenirs));
        }

        public async Task<IActionResult> MySouvenirs()
        {
            var souvenirs = await service.MySouvenirs();

            return View(souvenirs);
        }
    }
}
