using Geography.Models.Nature;
using Geography.Models.Type;

namespace Geography.Contracts
{
    public interface INatureService
    {
        ICollection<NatureViewModel> All();
        void Add(NatureViewModel model);
        bool Edit(NatureViewModel model);
        NatureViewModel natureById(int id);
        TypeViewModel typeByNature(string type);
        void Delete(int id);

    }
}
