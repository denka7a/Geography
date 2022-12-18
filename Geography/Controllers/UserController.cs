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
        public async Task<IActionResult> AddBalance()
        {
            var userModel = await service.UserBalance();

            return View(userModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddBalance(UserViewModel userModel)
        {
            if (!ModelState.IsValid || userModel.Balance < 0)
            {
                userModel.Balance = 0;
                return View(userModel);
            }

            var userBalance = await service.CorrectBalance(userModel.Balance);
            if (!userBalance)
            {
                return RedirectToAction(nameof(AddBalance));
            }
            await service.AddBalnce(userModel);

            return RedirectToAction(nameof(AddBalance));
        }
    }
}
