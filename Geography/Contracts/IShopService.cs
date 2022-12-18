using Geography.Models.Shop;

namespace Geography.Contracts
{
    public interface IShopService
    {
        Task<ICollection<SouvenirViewModel>> AllSouvenirs();
        Task AddSouvenir(SouvenirViewModel souvenir);
        Task<bool> BuySouvenir(int id);
    }
}
