using System.Data;

namespace Primeira_Tarefa.Interfaces.Connections
{
    public interface IPostgresConnection
    {
        public IDbConnection Get();
    }
}
