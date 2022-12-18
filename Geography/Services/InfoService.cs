using Geography.Contracts;
using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Models.Message;
using Microsoft.EntityFrameworkCore;

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

        public async Task AddMessage(MessageViewModel messageModel)
        {
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await this.context.Users.FirstAsync(x => x.UserName == userName);

            var message = new Message()
            {
                Id = messageModel.Id,
                Writer = messageModel.Writer,
                Text = messageModel.Text,
                geographyUserId = user.Id
            };

            await context.Message.AddAsync(message);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<MessageViewModel>> Messages()
        {
            var messages = await context.Message.Select(x => new MessageViewModel
            {
                Id = x.Id,
                Writer = x.Writer,
                Text = x.Text
            }).ToListAsync();

            return messages;
        }
    }
}
