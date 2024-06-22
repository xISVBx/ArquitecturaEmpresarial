namespace Ecommerce.Infraestructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository CustomersRepository { get; }
        IUsersRepository UsersRepository { get; }
        ICategoriesRepository CategoriesRepository { get; }
        void Commit();
        void Rollback();
    }
}
