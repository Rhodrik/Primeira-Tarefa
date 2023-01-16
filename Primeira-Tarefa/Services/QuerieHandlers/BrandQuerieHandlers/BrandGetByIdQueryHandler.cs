using MediatR;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Services.Queries.BrandQueries;
using Primeira_Tarefa.Types;

namespace Primeira_Tarefa.Services.QuerieHandlers.BrandQuerieHandlers
{
    public class BrandGetByIdQueryHandler : IRequestHandler<BrandGetByIdQueries, Brand>
    {
        private readonly IBrandRepository _ibrandRepository;

        public BrandGetByIdQueryHandler(IBrandRepository ibrandRepository)
        {
            _ibrandRepository = ibrandRepository;
        }

        public async Task<Brand> Handle(BrandGetByIdQueries request, CancellationToken cancellationToken)
        {
            Brand? brand = (Brand?)await _ibrandRepository.GetByiDAsync(request.Id);
            return brand;
        }
    }
}
