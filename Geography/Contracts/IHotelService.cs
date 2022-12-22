using Geography.Models.Hotel;

namespace Geography.Contracts
{
    public interface IHotelService
    {
        Task<ICollection<HotelViewModel>> AllHotels();
        Task AddHotel(HotelViewModel hotel);
        Task<HotelViewModel> HotelById(int id);
        Task Remove(int id);
        Task BackHotel(int id);
        Task<int> HotelsCount();
        Task<ICollection<HotelViewModel>> RemovedHotels();
    }
}
