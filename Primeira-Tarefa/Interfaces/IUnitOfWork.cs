using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;

namespace Primeira_Tarefa.Interfaces
{
    public interface IUnitOfWork
    {
        IBrandRepository Brand { get; }
        IGroupRepository Group { get; }
    }
}
