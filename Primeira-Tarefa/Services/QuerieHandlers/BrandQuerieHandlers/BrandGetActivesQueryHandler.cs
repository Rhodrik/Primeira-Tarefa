using MediatR;
using Primeira_Tarefa.DTO.BrandDTO;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Services.Queries.BrandQueries;

namespace Primeira_Tarefa.Services.QuerieHandlers.BrandQuerieHandlers
{
    public class BrandActivesQueryHandler : IRequestHandler<BrandGetActivesQueries, IEnumerable<BrandActivesDTO>>
    {
        private readonly IBrandRepository _ibrandRepository;

        public BrandActivesQueryHandler(IBrandRepository ibrandRepository)
        {
            _ibrandRepository = ibrandRepository;
        }

        public async Task<IEnumerable<BrandActivesDTO>> Handle(BrandGetActivesQueries request, CancellationToken cancellationToken)
        {
            IEnumerable<BrandActivesDTO> actives = await _ibrandRepository.GetActivesAsync();
            return actives;
        }
    }
}
