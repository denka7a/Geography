using Geography.Contracts;
using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Models.Hotel;
using Microsoft.EntityFrameworkCore;

namespace Geography.Services
{
    public class HotelService : IHotelService
    {
        private readonly GeographyDbContext context;
        public HotelService(GeographyDbContext context)
        {
            this.context = context;
        }

        public async Task AddHotel(HotelViewModel model)
        {
            var isNatureExist = await context.NatureObjects.FirstOrDefaultAsync(x => x.Name == model.NatureName);

            if (isNatureExist == null)
            {
                return;
            }

            var nature = await context.NatureObjects.FirstAsync(x => x.Name == model.NatureName);

            var hotel = new Hotel()
            {
                Name = model.Name,
                Stars = model.Stars,
                URL = model.URL,
                NatureName = model.NatureName,
                IsRemove = false,
                Nature = nature
            };

            await context.Hotels.AddAsync(hotel);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<HotelViewModel>> AllHotels()
        {
            var hotels = await this.context.Hotels
            .Where(x => x.IsRemove == false)
                .Select(x => new HotelViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    URL = x.URL,
                    Stars = x.Stars,
                    NatureName = x.NatureName,
                })
                .OrderByDescending(x => x.Stars)
                .ToListAsync();

            return hotels;
        }

        public async Task Remove(int id)
        {
            var hotel = await context.Hotels.FindAsync(id);
            hotel.IsRemove = true;
            await context.SaveChangesAsync();
        }

        public async Task<HotelViewModel> HotelById(int id) =>
            await context.Hotels
            .Where(i => i.Id == id)
            .Select(h => new HotelViewModel
            {
                Id = h.Id,
                Name = h.Name,
                Stars = h.Stars,
                URL = h.URL,
                IsRemove = h.IsRemove,
                NatureName = h.NatureName,
            }).FirstOrDefaultAsync();

        public async Task<ICollection<HotelViewModel>> RemovedHotels()
        {
            var hotels = await this.context.Hotels
            .Where(x => x.IsRemove == true)
                .Select(x => new HotelViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    URL = x.URL,
                    Stars = x.Stars,
                    NatureName = x.NatureName,
                }).ToListAsync();

            return hotels;
        }

        public async Task BackHotel(int id)
        {
            var hotel = await context.Hotels.FindAsync(id);
            hotel.IsRemove = false;
            await context.SaveChangesAsync();
        }

        public async Task<int> HotelsCount()
        {
            var hotelsCount = await context.Hotels.CountAsync();

            return hotelsCount;
        }
    }
}
