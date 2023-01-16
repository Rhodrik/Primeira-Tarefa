using Dommel;
using Primeira_Tarefa.Interfaces.Connections;
using Primeira_Tarefa.Interfaces.Repositorys;

namespace Primeira_Tarefa.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IPostgresConnection _conn;

        public BaseRepository(IPostgresConnection conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _conn.Get().GetAllAsync<TEntity>();
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            int id = (int)await _conn.Get().InsertAsync<TEntity>(entity);
            return id;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _conn.Get().UpdateAsync<TEntity>(entity);
        }

        
    }
}
