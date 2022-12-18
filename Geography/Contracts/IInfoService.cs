using Geography.Models.Message;

namespace Geography.Contracts
{
    public interface IInfoService
    {
        Task<ICollection<MessageViewModel>> Messages();
        Task AddMessage(MessageViewModel message);
    }
}
