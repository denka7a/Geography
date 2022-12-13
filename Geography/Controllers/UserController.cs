using Geography.Data.Data;
using Geography.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Geography.Controllers
{
    public class UserController : Controller
    {
        private readonly GeographyDbContext context;

        public UserController(GeographyDbContext context)
        {
            this.context = context;
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddBalance()
        {
            var name = this.User.Identity.Name;
            var user = this.context.Users.First(x => x.UserName == name);

            var userModel = new UserViewModel()
            {
                Balance = user.Balance,
            };

            return View(userModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddBalance(UserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                userModel.Balance = 0;
                return View(userModel);
            }
            var name = this.User.Identity.Name;
            var user = this.context.Users.First(x => x.UserName == name);

            user.Balance = (decimal)userModel.Balance;
            context.SaveChanges();

            return RedirectToAction(nameof(AddBalance));
        }
    }
}
