using Geography.Models.User;

namespace Geography.Contracts
{
    public interface IUserService
    {
        Task<UserViewModel> UserBalance();
        Task<bool> AddBalnce(UserViewModel userModel);
        Task<bool> CorrectBalance(decimal balance);
    }
}
