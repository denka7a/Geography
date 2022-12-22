using Geography.Contracts;
using Geography.Data.Data;
using Geography.Data.Models;
using Geography.Models.Shop;
using Microsoft.EntityFrameworkCore;

namespace Geography.Services
{
    public class ShopService : IShopService
    {
        private readonly GeographyDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ShopService(GeographyDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task AddSouvenir(SouvenirViewModel souvenir)
        {
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await this.context.Users.FirstAsync(x => x.UserName == userName);

            var currentSouvenir = new Souvenir()
            {
                Name = souvenir.Name,
                URL = souvenir.URL,
                Price = souvenir.Price,
                UserId = user.Id
            };

            await this.context.Souvenirs.AddAsync(currentSouvenir);
            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<SouvenirViewModel>> AllSouvenirs()
        {
            var souvenirs = await context.Souvenirs.Select(x => new SouvenirViewModel
            {
                Id = x.Id,
                Name = x.Name,
                URL = x.URL,
                Price = x.Price
            }).ToListAsync();

            return souvenirs;
        }

        public async Task<bool> BuySouvenir(int id)
        {
            var souvenir = await context.Souvenirs.FirstOrDefaultAsync(x => x.Id == id);

            if (souvenir == null)
            {
                return false;
            }

            var souvenirPrice = souvenir.Price;

            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await this.context.Users.FirstAsync(x => x.UserName == userName);

            if (souvenir.Price > user.Balance)
            {
                return false;
            }
            
            var userSouvenir = new UserSouvenir
            {
                UserId = user.Id,
                SouvenirId = souvenir.Id,
            };

            await context.UserSouvenirs.AddAsync(userSouvenir);
            user.Balance -= souvenirPrice;

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<SouvenirViewModel>> MySouvenirs()
        {
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await this.context.Users.FirstAsync(x => x.UserName == userName);

            var userSouvenirs = context.UserSouvenirs.Where(x => x.UserId == user.Id);
            var souvenirs = userSouvenirs.Select(x => new SouvenirViewModel
            {
                Name = x.Souvenir.Name,
                URL = x.Souvenir.URL,
                Price = x.Souvenir.Price
            }).ToList();

            return souvenirs;
        }
    }
}
