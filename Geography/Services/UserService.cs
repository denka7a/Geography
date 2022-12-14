using Geography.Contracts;
using Geography.Data.Data;
using Geography.Models.User;
using Microsoft.AspNetCore.Http;

namespace Geography.Services
{
    public class UserService : IUserService
    {
        private readonly GeographyDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(GeographyDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public bool AddBalnce(UserViewModel userModel)
        {
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var user = this.context.Users.First(x => x.UserName == userName);

            user.Balance = (decimal)userModel.Balance;
            context.SaveChanges();
            return true;
        }

        public bool CorrectBalance(decimal balance)
        {
            if (balance > decimal.MaxValue)
            {
                return false;
            }
            if (balance < 0)
            {
                return false;
            }
            return true;
        }

        public UserViewModel UserBalance()
        {
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var user = this.context.Users.First(x => x.UserName == userName);

            var userModel = new UserViewModel()
            {
                Balance = user.Balance,
            };

            return userModel;
        }
    }
}
