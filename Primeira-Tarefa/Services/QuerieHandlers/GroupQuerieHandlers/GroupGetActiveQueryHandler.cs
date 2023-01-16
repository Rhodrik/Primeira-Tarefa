using MediatR;
using Primeira_Tarefa.DTO.GroupDTO;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Services.Queries.GroupQueries;

namespace Primeira_Tarefa.Services.QuerieHandlers.GroupQuerieHandlers
{
    public class GroupGetActiveQueryHandler : IRequestHandler<GroupGetActiveQueries, IEnumerable<GroupActivesDTO>>
    {
        private readonly IGroupRepository _igroupRepository;
        public GroupGetActiveQueryHandler(IGroupRepository igroupRepository)
        {
            _igroupRepository = igroupRepository;
        }

        public async Task<IEnumerable<GroupActivesDTO>> Handle(GroupGetActiveQueries request, CancellationToken cancellationToken)
        {
            IEnumerable<GroupActivesDTO> actives = await _igroupRepository.ActivesAsync();
            return actives;
        }
    }
}
