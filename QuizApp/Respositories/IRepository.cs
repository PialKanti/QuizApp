namespace QuizApp.Respositories
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        Task<T> Insert(T entity);
        Task Update(T entityToUpdate);
        Task<T> Delete(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
