using MediatR;
using Primeira_Tarefa.DTO;
using Primeira_Tarefa.DTO.GroupDTO;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Services.Queries.GroupQueries;

namespace Primeira_Tarefa.Services.QuerieHandlers.GroupQuerieHandlers
{
    public class GroupSearchQueryHandler : IRequestHandler<GroupSearchQueries, BasePagedSearchDTO<GroupSearchDTO>>
    {
        private readonly IGroupRepository _igroupRepository;
        public GroupSearchQueryHandler(IGroupRepository igroupRepository)
        {
            _igroupRepository = igroupRepository;
        }

        public async Task<IEnumerable<GroupSearchDTO>> Handle(GroupSearchQueries request, CancellationToken cancellationToken)
        {
            BasePagedSearchDTO<GroupSearchDTO> dTOs = await _igroupRepository.SeachasAsync
                (
                request.Payload.Status,
                request.Payload.Description,
                request.Payload.UseSubgroup,
                request.Payload.GetLimit(),
                request.Payload.GetOffset()
                );

            return (IEnumerable<GroupSearchDTO>) dTOs;
        }

        async Task<BasePagedSearchDTO<GroupSearchDTO>> IRequestHandler<GroupSearchQueries, BasePagedSearchDTO<GroupSearchDTO>>.Handle(GroupSearchQueries request, CancellationToken cancellationToken)
        {
            BasePagedSearchDTO<GroupSearchDTO> dTOs = await _igroupRepository.SeachasAsync
                (
                request.Payload.Status,
                request.Payload.Description,
                request.Payload.UseSubgroup,
                request.Payload.GetLimit(),
                request.Payload.GetOffset()
                );

            return (BasePagedSearchDTO<GroupSearchDTO>) dTOs;
        }
    }
}
