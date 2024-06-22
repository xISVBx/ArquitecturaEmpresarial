using Ecommerce.Domain.Entity;

namespace Ecommerce.Infraestructure.Interface
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Categories>> GetAll();
    }
}
