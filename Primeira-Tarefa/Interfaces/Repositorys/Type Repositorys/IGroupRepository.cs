using Primeira_Tarefa.DTO;
using Primeira_Tarefa.DTO.GroupDTO;

namespace Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        Task<int> InsertasAsync(Group group);

        Task<IEnumerable<GroupActivesDTO>> ActivesAsync();

        Task<BasePagedSearchDTO<GroupSearchDTO>> SeachasAsync
            (bool status, string? descripTion, bool useSubgroup, int limit, int offset);

        Task<int> UpdateasAsync(Group group);

        Task<bool> IdExist(int id);
    }
}
