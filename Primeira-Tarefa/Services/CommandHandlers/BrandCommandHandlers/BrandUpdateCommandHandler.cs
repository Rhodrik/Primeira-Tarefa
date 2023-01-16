using AutoMapper;
using FluentValidation;
using MediatR;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Payloads.BrandPayloads;
using Primeira_Tarefa.Services.Commands.BrandCommands;
using Primeira_Tarefa.Types;

namespace Primeira_Tarefa.Services.CommandHandlers.BrandCommandHandlers
{
    public class BrandUpdateCommandHandler : IRequestHandler<BrandUpdateCommand>
    {
        private readonly IBrandRepository _ibrandRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<BrandUpdatePayload> _validator;

        public BrandUpdateCommandHandler
            (
            IBrandRepository ibrandRepository,
            IMapper mapper,
            IValidator<BrandUpdatePayload> validator
            )
        {
            _ibrandRepository = ibrandRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Unit> Handle(BrandUpdateCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request.Payload);
            Brand brands = _mapper.Map<Brand>(request.Payload);
            brands.Id = request.Payload.GetId();
            await _ibrandRepository.UpdateasAsync(brands);

            return Unit.Value;
        }
    }
}
