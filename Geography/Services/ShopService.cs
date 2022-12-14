using Geography.Contracts;
using Geography.Data.Data;
using Geography.Data.Models;
using Geography.Models.Shop;

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

        public void AddSouvenir(SouvenirViewModel souvenir)
        {
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var user = this.context.Users.First(x => x.UserName == userName);

            var currentSouvenir = new Souvenir()
            {
                Name = souvenir.Name,
                URL = souvenir.URL,
                Price = souvenir.Price,
                UserId = user.Id
            };

            this.context.Souvenirs.Add(currentSouvenir);
            this.context.SaveChanges();
        }

        public ICollection<SouvenirViewModel> AllSouvenirs()
        {
            var souvenirs = context.Souvenirs.Select(x => new SouvenirViewModel
            {
                Id = x.Id,
                Name = x.Name,
                URL = x.URL,
                Price = x.Price
            }).ToList();

            return souvenirs;
        }

        public bool BuySouvenir(int id)
        {
            var souvenir = context.Souvenirs.FirstOrDefault(x => x.Id == id);
            var souvenirPrice = souvenir.Price;

            if (souvenir == null)
            {
                return false;
            }

            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var user = this.context.Users.First(x => x.UserName == userName);

            if (souvenir.Price > user.Balance)
            {
                return false;
            }

            var userSouvenir = new UserSouvenir
            {
                UserId = user.Id,
                SouvenirId = souvenir.Id,
            };

            context.UserSouvenirs.Add(userSouvenir);
            user.Balance -= souvenirPrice;

            context.SaveChanges();
            return true;
        }
    }
}
