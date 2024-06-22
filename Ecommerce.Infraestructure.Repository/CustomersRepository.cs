using Dapper;
using Ecommerce.Domain.Entity;
using Ecommerce.Infraestructure.Data;
using Ecommerce.Infraestructure.Interface;
using System.Data;

namespace Ecommerce.Infraestructure.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DapperContext _context;
        public CustomersRepository(DapperContext context)
        {
            _context = context;
        }

        #region Metodos Sincronos
        public bool Insert(Customers customer)
        {
            var connection = _context.sqlConnection;
            var query = "CustomersInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customer.CustomerId);
            parameters.Add("@CompanyName", customer.CompanyName);
            parameters.Add("@ContactName", customer.ContactName);
            parameters.Add("@ContactTitle", customer.ContactTitle);
            parameters.Add("@Address", customer.Address);
            parameters.Add("@City", customer.City);
            parameters.Add("@Region", customer.Region);
            parameters.Add("@PostalCode", customer.PostalCode);
            parameters.Add("@Country", customer.Country);
            parameters.Add("@Phone", customer.Phone);
            parameters.Add("@Fax", customer.Fax);
            var result = connection.Execute(query, param: parameters, transaction: _context.transaction, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
        public bool Delete(string customerId)
        {
            var connection = _context.sqlConnection;
            var query = "CustomersDelete";
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var result = connection.Execute(query, param: parameters, transaction: _context.transaction, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
        public bool Update(Customers customer)
        {
            var connection = _context.sqlConnection;
            var query = "CustomersUpdate";
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customer.CustomerId);
            parameters.Add("@CompanyName", customer.CompanyName);
            parameters.Add("@ContactName", customer.ContactName);
            parameters.Add("@ContactTitle", customer.ContactTitle);
            parameters.Add("@Address", customer.Address);
            parameters.Add("@City", customer.City);
            parameters.Add("@Region", customer.Region);
            parameters.Add("@PostalCode", customer.PostalCode);
            parameters.Add("@Country", customer.Country);
            parameters.Add("@Phone", customer.Phone);
            parameters.Add("@Fax", customer.Fax);
            var result = connection.Execute(query, param: parameters, transaction: _context.transaction, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
        public Customers Get(string customerId)
        {
            var connection = _context.sqlConnection;
            var query = "CustomersGetById";
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var result = connection.QuerySingle<Customers>(query, param: parameters, transaction: _context.transaction, commandType: CommandType.StoredProcedure);
            return result;
        }
        public IEnumerable<Customers> GetAll()
        {
            var connection = _context.sqlConnection;
            var query = "CustomersList";
            var result = connection.Query<Customers>(query, transaction: _context.transaction, commandType: CommandType.StoredProcedure);
            return result;
        }
        public IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var connection = _context.sqlConnection;
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", pageNumber);
            parameters.Add("@PageSize", pageSize);

            var result = connection.Query<Customers>(query, transaction: _context.transaction, param: parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public int Count()
        {
            var connection = _context.sqlConnection;
            var query = "SELECT COUNT(*) FROM Customers";
            var count = connection.ExecuteScalar<int>(query, transaction: _context.transaction, commandType: CommandType.Text);
            return count;
        }
        #endregion
        #region Metodos Asincronos
        public async Task<bool> InsertAsync(Customers customer)
        {
            var connection = _context.sqlConnection;
            var query = "CustomersInsert";
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customer.CustomerId);
            parameters.Add("@CompanyName", customer.CompanyName);
            parameters.Add("@ContactName", customer.ContactName);
            parameters.Add("@ContactTitle", customer.ContactTitle);
            parameters.Add("@Address", customer.Address);
            parameters.Add("@City", customer.City);
            parameters.Add("@Region", customer.Region);
            parameters.Add("@PostalCode", customer.PostalCode);
            parameters.Add("@Country", customer.Country);
            parameters.Add("@Phone", customer.Phone);
            parameters.Add("@Fax", customer.Fax);
            var result = await connection.ExecuteAsync(query, param: parameters, transaction: _context.transaction, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
        public async Task<bool> DeleteAsync(string customerId)
        {
            var connection = _context.sqlConnection;
            var query = "CustomersDelete";
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var result = await connection.ExecuteAsync(query, param: parameters, transaction: _context.transaction, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
        public async Task<bool> UpdateAsync(Customers customer)
        {
            var connection = _context.sqlConnection;
            var query = "CustomersUpdate";
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customer.CustomerId);
            parameters.Add("@CompanyName", customer.CompanyName);
            parameters.Add("@ContactName", customer.ContactName);
            parameters.Add("@ContactTitle", customer.ContactTitle);
            parameters.Add("@Address", customer.Address);
            parameters.Add("@City", customer.City);
            parameters.Add("@Region", customer.Region);
            parameters.Add("@PostalCode", customer.PostalCode);
            parameters.Add("@Country", customer.Country);
            parameters.Add("@Phone", customer.Phone);
            parameters.Add("@Fax", customer.Fax);
            var result = await connection.ExecuteAsync(query, param: parameters, transaction: _context.transaction, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
        public async Task<Customers> GetAsync(string customerId)
        {
            var connection = _context.sqlConnection;
            var query = "CustomersGetById";
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var result = await connection.QuerySingleAsync<Customers>(query, param: parameters, transaction: _context.transaction, commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            var connection = _context.sqlConnection;
            var query = "CustomersList";
            var result = await connection.QueryAsync<Customers>(query, transaction: _context.transaction, commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var connection = _context.sqlConnection;
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", pageNumber);
            parameters.Add("@PageSize", pageSize);

            var result = await connection.QueryAsync<Customers>(query, transaction: _context.transaction, param: parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<int> CountAsync()
        {
            var connection = _context.sqlConnection;
            var query = "SELECT COUNT(*) FROM Customers";
            var count = await connection.ExecuteScalarAsync<int>(query, transaction: _context.transaction, commandType: CommandType.Text);
            return count;
        }
        #endregion
    }
}
