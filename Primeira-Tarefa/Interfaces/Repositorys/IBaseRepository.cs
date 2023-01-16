namespace Primeira_Tarefa.Interfaces.Repositorys
{
    public interface IBaseRepository<T>
    {
        public Task<int> InsertAsync(T entity);

        public Task<IEnumerable<T>> GetAllAsync();

        public Task UpdateAsync(T entity);
    }
}
