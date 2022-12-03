using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace Geography.Controllers
{
    public class InformationController : Controller
    {
        private readonly GeographyDbContext context;

        public InformationController(GeographyDbContext context)
        {
            this.context = context;
        }

        public IActionResult Info()
        {
            var messages = context.Message.ToList();
            ViewData["messages"] = messages;

            return View();
        }
        [HttpPost]
        public IActionResult Info(MessageViewModel messageModel)
        {
            if (!ModelState.IsValid)
            {
                return View(messageModel);
            }

            var name = this.User.Identity.Name;
            var user = this.context.Users.First(x => x.UserName == name);

            var message = new Message()
            {
                Id = messageModel.Id,
                Writer = messageModel.Writer,
                Text = messageModel.Text,
                geographyUserId = user.Id
            };

            context.Message.Add(message);
            context.SaveChanges();

            return RedirectToAction(nameof(Info));
        }
    }
}
