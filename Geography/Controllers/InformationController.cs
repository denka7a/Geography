using Geography.Contracts;
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

        public async Task<IActionResult> Info()
        {
            var messages = await service.Messages();
            ViewData["messages"] = messages;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Info(MessageViewModel messageModel)
        {
            if (!ModelState.IsValid)
            {
                var messages = service.Messages();
                ViewData["messages"] = messages;
                return View(messageModel);
            }

            await service.AddMessage(messageModel);

            return RedirectToAction(nameof(Info));
        }
    }
}
