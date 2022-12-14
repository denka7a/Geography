using Geography.Contracts;
using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace Geography.Controllers
{
    public class InformationController : Controller
    {
        private readonly IInfoService service;
        public InformationController(IInfoService service)
        {
            this.service = service;
        }

        public IActionResult Info()
        {
            var messages = service.Messages();
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

            service.AddMessage(messageModel);

            return RedirectToAction(nameof(Info));
        }
    }
}
