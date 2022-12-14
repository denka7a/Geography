using Geography.Models.Message;

namespace Geography.Contracts
{
    public interface IInfoService
    {
        ICollection<MessageViewModel> Messages();
        void AddMessage(MessageViewModel message);
    }
}
