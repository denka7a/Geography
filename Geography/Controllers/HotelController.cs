using Geography.Contracts;
using Geography.Data.Data;
using Geography.Models.Hotel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Geography.Controllers
{
    [Authorize]
    public class HotelController : Controller
    {
        private readonly IHotelService service;
        public HotelController(IHotelService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> All(int currentPage)
        {
            if (currentPage < 1)
            {
                currentPage = 1;
            }
            var hotels = (await service
                .AllHotels())
                .Skip((currentPage - 1)*3)
                .Take(3);

            var hotelsCount = await service.HotelsCount();
            var hotels2 = new HotelAllViewModel()
            {
                Hotels = hotels.ToList(),
                Pages =  (int)Math.Ceiling((double)hotelsCount / 3d),
                CurrentPage = currentPage
            };

            return View(hotels2);
        }

        public async Task<IActionResult> AddHotel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHotel(HotelViewModel hotelModel)
        {
            if (!ModelState.IsValid)
            {
                return View(hotelModel);
            }


            await service.AddHotel(hotelModel);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Remove(int id)
        {
            if (await service.HotelById(id) == null)
            {
                return NotFound();
            }

            await service.Remove(id);

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemovedHotels()
        {
            var hotels = await service.RemovedHotels();
            return View(hotels);
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> BackHotel(int id)
        {
            if (await service.HotelById(id) == null)
            {
                return NotFound();
            }

            await service.BackHotel(id);

            return RedirectToAction(nameof(All));
        }
    }
}
