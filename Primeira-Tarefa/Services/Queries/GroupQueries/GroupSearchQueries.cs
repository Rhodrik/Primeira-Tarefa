using MediatR;
using Primeira_Tarefa.DTO;
using Primeira_Tarefa.DTO.GroupDTO;
using Primeira_Tarefa.Payloads.GroupPayloads;

namespace Primeira_Tarefa.Services.Queries.GroupQueries
{
    public class GroupSearchQueries : IRequest<BasePagedSearchDTO<GroupSearchDTO>>
    {
        public GroupSearchQueries(GroupSearchPayload payload)
        {
            Payload = payload;
        }
        public GroupSearchPayload Payload { get; }
    }
}
