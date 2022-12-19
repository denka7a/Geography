using Geography.Contracts;
using Geography.Data.Data;
using Geography.Models.Hotel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Geography.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService service;
        public HotelController(IHotelService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> All()
        {
            var hotels = await service.AllHotels();
            return View(hotels);
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
    }
}
