using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Ecommerce.Infraestructure.Interface;

namespace Ecommerce.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Users Authenticate(string username, string password)
        {
            return _unitOfWork.UsersRepository.Authenticate(username, password);
        }
    }
}
