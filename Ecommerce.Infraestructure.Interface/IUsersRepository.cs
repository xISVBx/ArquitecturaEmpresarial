using Ecommerce.Domain.Entity;

namespace Ecommerce.Infraestructure.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string username, string password);
    }
}
