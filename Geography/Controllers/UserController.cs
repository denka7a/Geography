using Geography.Data.Data;
using Geography.Models.User;
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
        [HttpPost]
        public IActionResult AddBalance(decimal balance)
        {
            var name = this.User.Identity.Name;
            var user = this.context.Users.First(x => x.UserName == name);

            if (balance <= 0)
            {
                return BadRequest("Balance must be greater than 0");
            }

            user.Balance = balance;
            context.SaveChanges();

            return RedirectToAction(nameof(AddBalance));
        }
    }
}
