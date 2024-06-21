﻿using Ecommerce.Domain.Entity;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interface
{
    public interface ICustomersDomain
    {
        #region Metodos Sincronos
        bool Insert(Customers customer);
        bool Update(Customers customer);
        bool Delete(string customerId);
        Customers Get(string customerId);
        IEnumerable<Customers> GetAll();
        IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize);
        int Count();
        #endregion
        #region Metodos Asyncronos
        Task<bool> InsertAsync(Customers customer);
        Task<bool> UpdateAsync(Customers customer);
        Task<bool> DeleteAsync(string customerId);
        Task<Customers> GetAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllAsync();
        Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();
        #endregion
    }
}
