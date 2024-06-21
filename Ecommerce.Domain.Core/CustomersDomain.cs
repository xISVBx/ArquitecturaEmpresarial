using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Ecommerce.Infraestructure.Interface;

namespace Ecommerce.Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Metodos Sincronos
        public bool Insert(Customers customers)
        {
            var response = _unitOfWork.CustomersRepository.Insert(customers);
            _unitOfWork.Commit();
            return response;
        }
        public bool Update(Customers customers)
        {
            return _unitOfWork.CustomersRepository.Update(customers);
        }
        public bool Delete(string customersId)
        {
            return _unitOfWork.CustomersRepository.Delete(customersId);
        }
        public Customers Get(string customerId)
        {
            return _unitOfWork.CustomersRepository.Get(customerId);
        }
        public IEnumerable<Customers> GetAll()
        {
            return _unitOfWork.CustomersRepository.GetAll();
        }
        
        #endregion
        #region Metodos Asincronos
        public async Task<bool> InsertAsync(Customers customers)
        {
            return await _unitOfWork.CustomersRepository.InsertAsync(customers);
        }
        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _unitOfWork.CustomersRepository.DeleteAsync(customerId);
        }
        public async Task<bool> UpdateAsync(Customers customers)
        {
            return await _unitOfWork.CustomersRepository.UpdateAsync(customers);
        }
        public async Task<Customers> GetAsync(string customerId)
        {
            return await _unitOfWork.CustomersRepository.GetAsync(customerId);
        }
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _unitOfWork.CustomersRepository.GetAllAsync();
        }

        public IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize)
        {
            return _unitOfWork.CustomersRepository.GetAllWithPagination(pageNumber, pageSize);
        }

        public int Count()
        {
            return _unitOfWork.CustomersRepository.Count();
        }

        public async Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.CustomersRepository.GetAllWithPaginationAsync(pageNumber, pageSize);
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.CustomersRepository.CountAsync();
        }
        #endregion
    }
}
