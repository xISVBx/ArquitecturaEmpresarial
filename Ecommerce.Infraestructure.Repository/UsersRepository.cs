using Dapper;
using Ecommerce.Domain.Entity;
using Ecommerce.Infraestructure.Data;
using Ecommerce.Infraestructure.Interface;
using System.Data;

namespace Ecommerce.Infraestructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperContext _context;
        public UsersRepository(DapperContext context)
        {
            _context = context;
        }

        public Users Authenticate(string username, string password)
        {
            using (var connection = _context.sqlConnection)
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", username);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, transaction: _context.transaction, commandType: CommandType.StoredProcedure);
                return user;
            }
        }
    }
}
