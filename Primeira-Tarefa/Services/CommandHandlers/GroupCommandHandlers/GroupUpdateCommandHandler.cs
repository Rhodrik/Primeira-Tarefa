using AutoMapper;
using FluentValidation;
using MediatR;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Payloads.GroupPayloads;
using Primeira_Tarefa.Services.Commands.GroupCommands;

namespace Primeira_Tarefa.Services.CommandHandlers.GroupCommandHandlers
{
    public class GroupUpdateCommandHandler : IRequestHandler<GroupUpdateCommand>
    {
        private readonly IGroupRepository _igroupRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GroupUpdatePayload> _validator;

        public GroupUpdateCommandHandler
            (
            IGroupRepository igroupRepository,
            IMapper mapper,
            IValidator<GroupUpdatePayload> validator
            )
        {
            _igroupRepository = igroupRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<Unit> Handle(GroupUpdateCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request.Payload);
            Group group = _mapper.Map<Group>(request.Payload);
            group.Id = request.Payload.GetId();
            await _igroupRepository.UpdateasAsync(group);

            return Unit.Value;
        }
    }
}
