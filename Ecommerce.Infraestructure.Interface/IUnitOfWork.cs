namespace Ecommerce.Infraestructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository CustomersRepository { get; }
        IUsersRepository UsersRepository { get; }
        void Commit();
        void Rollback();
    }
}
