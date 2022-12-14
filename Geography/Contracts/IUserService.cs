using Geography.Models.User;

namespace Geography.Contracts
{
    public interface IUserService
    {
        UserViewModel UserBalance();
        bool AddBalnce(UserViewModel userModel);
        bool CorrectBalance(decimal balance);
    }
}
