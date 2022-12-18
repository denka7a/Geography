using Geography.Models.Type;

namespace Geography.Contracts
{
    public interface ITypeService
    {
        Task<ICollection<TypeViewModel>> AllTypes();
        Task AddType(TypeViewModel typeViewModel);
    }
}
