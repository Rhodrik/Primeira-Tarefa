using AutoMapper;
using FluentValidation;
using MediatR;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Payloads.BrandPayloads;
using Primeira_Tarefa.Services.Commands.BrandCommands;
using Primeira_Tarefa.Types;

namespace Primeira_Tarefa.Services.CommandHandlers.BrandCommandHandlers
{
    public class BrandInsertCommandHandler : IRequestHandler<BrandInsertCommand>
    {
        private readonly IBrandRepository _ibrandRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<BrandInsertPayload> _validator;

        public BrandInsertCommandHandler
            (
            IBrandRepository ibrandRepository,
            IMapper mapper,
            IValidator<BrandInsertPayload> validator
            )
        {
            _ibrandRepository = ibrandRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Unit> Handle(BrandInsertCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request.Payload);
            Brand brand = _mapper.Map<Brand>(request.Payload);
            brand.Id = await _ibrandRepository.InsertasAsync(brand);

            return Unit.Value;
        }
    }
}