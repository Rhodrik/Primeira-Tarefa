using MediatR;
using Primeira_Tarefa.DTO.GroupDTO;

namespace Primeira_Tarefa.Services.Queries.GroupQueries
{
    public class GroupGetActiveQueries : IRequest<IEnumerable<GroupActivesDTO>>
    {
    }
}
