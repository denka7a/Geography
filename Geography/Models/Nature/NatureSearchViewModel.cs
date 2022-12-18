using System.ComponentModel.DataAnnotations;

namespace Geography.Models.Nature
{
    public class NatureSearchViewModel
    {
        public ICollection<NatureViewModel> NatureObjects { get; set; }
        [Display(Name = "Search by type")]
        public string SearchTerm { get; set; }
    }
}
