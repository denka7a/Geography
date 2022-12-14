using Geography.Contracts;
using Geography.Data.Data;
using Geography.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Geography.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddBalance()
        {
            var userModel = service.UserBalance();

            return View(userModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddBalance(UserViewModel userModel)
        {
            if (!ModelState.IsValid || userModel.Balance < 0)
            {
                userModel.Balance = 0;
                return View(userModel);
            }

            if (!service.CorrectBalance(userModel.Balance))
            {
                return RedirectToAction(nameof(AddBalance));
            }
            service.AddBalnce(userModel);

            return RedirectToAction(nameof(AddBalance));
        }
    }
}
