using Ecommerce.Infraestructure.Data;
using Ecommerce.Infraestructure.Interface;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Ecommerce.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DapperContext _context;
        public ICustomersRepository CustomersRepository { get; }
        public IUsersRepository UsersRepository { get; }
        public ICategoriesRepository CategoriesRepository {  get; }

        public UnitOfWork(ICustomersRepository customersRepository, IUsersRepository usersRepository, DapperContext context, ICategoriesRepository categoriesRepository)
        {
            CustomersRepository = customersRepository;
            UsersRepository = usersRepository;
            _context = context;
            CategoriesRepository = categoriesRepository;
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {

            try
            {
                _context.transaction.Commit();
                _context.transaction.Connection!.BeginTransaction();
            }
            catch
            {
                _context.transaction.Rollback();
                throw;
            }
        }

        public void Rollback()
        {

            _context.transaction.Rollback();
        }
    }
}
