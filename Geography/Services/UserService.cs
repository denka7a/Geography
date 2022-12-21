using Geography.Contracts;
using Geography.Data.Data;
using Geography.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> AddBalnce(UserViewModel userModel)
        {
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await this.context.Users.FirstAsync(x => x.UserName == userName);
            user.Balance = userModel.Balance;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CorrectBalance(decimal balance)
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

        public async Task<UserViewModel> UserBalance()
        {
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await this.context.Users.FirstAsync(x => x.UserName == userName);

            var userModel = new UserViewModel()
            {
                Balance = user.Balance,
                FullName = user.FullName,
            };

            return userModel;
        }
    }
}
