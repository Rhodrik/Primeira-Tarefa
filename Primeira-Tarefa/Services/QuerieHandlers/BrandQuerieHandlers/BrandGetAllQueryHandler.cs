using MediatR;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Services.Queries.BrandQueries;
using Primeira_Tarefa.Types;

namespace Primeira_Tarefa.Services.QuerieHandlers.BrandQuerieHandlers
{
    public class BrandGetAllQueryHandler : IRequestHandler<BrandGetAllQueries, IEnumerable<Brand>>
    {
        private readonly IBrandRepository _ibrandRepository;

        public BrandGetAllQueryHandler(IBrandRepository ibrandRepository)
        {
            _ibrandRepository = ibrandRepository;
        }

        public async Task<IEnumerable<Brand>> Handle(BrandGetAllQueries request, CancellationToken cancellationToken)
        {
            IEnumerable<Brand> brands = await _ibrandRepository.GetAllasAsync();
            return brands;
        }
    }
}