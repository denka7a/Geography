using Geography.Models.Type;

namespace Geography.Contracts
{
    public interface ITypeService
    {
        ICollection<TypeViewModel> AllTypes();
        void AddType(TypeViewModel typeViewModel);
    }
}
