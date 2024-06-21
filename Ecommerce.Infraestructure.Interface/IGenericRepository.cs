namespace Ecommerce.Infraestructure.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        #region Metodos Sincronos
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(string Id);
        T Get(string Id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWithPagination(int pageNumber, int pageSize);
        int Count();
        #endregion
        #region Metodos Asyncronos
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string Id);
        Task<T> GetAsync(string Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();
        #endregion
    }
}
