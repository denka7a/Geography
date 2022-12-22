namespace Geography.Models.Hotel
{
    public class HotelAllViewModel
    {
        public ICollection<HotelViewModel> Hotels { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
    }
}
