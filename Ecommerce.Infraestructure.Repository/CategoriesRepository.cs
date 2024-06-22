using Dapper;
using Ecommerce.Domain.Entity;
using Ecommerce.Infraestructure.Data;
using Ecommerce.Infraestructure.Interface;

namespace Ecommerce.Infraestructure.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DapperContext _context;
        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Categories>> GetAll()
        {
            using var connection = _context.sqlConnection;
            var query = "Select * From Categories";
            var categories = await connection.QueryAsync<Categories>(query, transaction: _context.transaction, commandType: System.Data.CommandType.Text);
            return categories;
        }
    }
}
