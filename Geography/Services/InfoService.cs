using Geography.Contracts;
using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Models.Message;

namespace Geography.Services
{
    public class InfoService : IInfoService
    {
        private readonly GeographyDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public InfoService(GeographyDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void AddMessage(MessageViewModel messageModel)
        {
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var user = this.context.Users.First(x => x.UserName == userName);

            var message = new Message()
            {
                Id = messageModel.Id,
                Writer = messageModel.Writer,
                Text = messageModel.Text,
                geographyUserId = user.Id
            };

            context.Message.Add(message);
            context.SaveChanges();
        }

        public ICollection<MessageViewModel> Messages()
        {
            var messages = context.Message.Select(x => new MessageViewModel
            {
                Id = x.Id,
                Writer = x.Writer,
                Text = x.Text
            }).ToList();

            return messages;
        }
    }
}
