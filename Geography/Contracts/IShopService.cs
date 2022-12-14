using Geography.Models.Shop;

namespace Geography.Contracts
{
    public interface IShopService
    {
        ICollection<SouvenirViewModel> AllSouvenirs();
        void AddSouvenir(SouvenirViewModel souvenir);
        bool BuySouvenir(int id);
    }
}
