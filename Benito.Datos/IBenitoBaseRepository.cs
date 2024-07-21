namespace Benito.Datos
{
    public interface IBenitoBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> Get(int id);
        Task<T> Get(Guid Guid);
        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(Guid id);
        Task CallSp(string spName, object[] parameters);
        Task<bool> CallSpNonQuery(string spName, object[] parameters);

    }
}