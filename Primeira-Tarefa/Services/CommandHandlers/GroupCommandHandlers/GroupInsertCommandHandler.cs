using AutoMapper;
using FluentValidation;
using MediatR;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Payloads.GroupPayloads;
using Primeira_Tarefa.Services.Commands.GroupCommands;

namespace Primeira_Tarefa.Services.CommandHandlers.GroupCommandHandlers
{
    public class GroupInsertCommandHandler : IRequestHandler<GroupInsertCommand>
    {
        private readonly IGroupRepository _igroupRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GroupInsertPayload> _validator;

        public GroupInsertCommandHandler
            (
            IGroupRepository igroupRepository,
            IMapper mapper,
            IValidator<GroupInsertPayload> validator
            )
        {
            _igroupRepository = igroupRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Unit> Handle(GroupInsertCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request.Payload);
            Group groupmap = _mapper.Map<Group>(request.Payload);
            groupmap.Id = await _igroupRepository.InsertasAsync(groupmap);

            return Unit.Value;
        }
    }
}