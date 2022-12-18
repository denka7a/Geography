using Geography.Models.Nature;
using Geography.Models.Type;

namespace Geography.Contracts
{
    public interface INatureService
    {
        Task<ICollection<NatureViewModel>> All();
        Task Add(NatureViewModel model);
        Task<bool> Edit(NatureViewModel model);
        Task<NatureViewModel> natureById(int id);
        Task<TypeViewModel> typeByNature(string type);
        Task Delete(int id);

    }
}
