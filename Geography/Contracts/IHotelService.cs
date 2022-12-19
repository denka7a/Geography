using Geography.Models.Hotel;
using Geography.Models.Message;

namespace Geography.Contracts
{
    public interface IHotelService
    {
        Task<ICollection<HotelViewModel>> AllHotels();
        Task AddHotel(HotelViewModel hotel);
    }
}
