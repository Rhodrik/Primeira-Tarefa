using Primeira_Tarefa.Interfaces;
using Primeira_Tarefa.Interfaces.Connections;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;

namespace Primeira_Tarefa.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPostgresConnection _conn;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(IPostgresConnection conn, IServiceProvider serviceProvider)
        {
            _conn = conn;
            _serviceProvider = serviceProvider;
        }

        public IBrandRepository Brand => _serviceProvider.GetRequiredService<IBrandRepository>();

        public IGroupRepository Group => _serviceProvider.GetRequiredService<IGroupRepository>();
    }
}
