using MediatR;
using Primeira_Tarefa.DTO;
using Primeira_Tarefa.DTO.BrandDTO;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Services.Queries.BrandQueries;

namespace Primeira_Tarefa.Services.QuerieHandlers.BrandQuerieHandlers
{
    public class BrandSearchQueryHandler : IRequestHandler<BrandSearchQueries, BasePagedSearchDTO<BrandSearchDTO>>
    {
        private readonly IBrandRepository _ibrandRepository;
        public BrandSearchQueryHandler(IBrandRepository ibrandRepository)
        {
            _ibrandRepository = ibrandRepository;
        }

        public async Task<IEnumerable<BrandSearchDTO>> Handle(BrandSearchQueries request, CancellationToken cancellationToken)
        {
            BasePagedSearchDTO<BrandSearchDTO> dTOs = await _ibrandRepository.SeachAsync
                (
                request.Payload.Status,
                request.Payload.Description,
                request.Payload.MainProvider_Name,
                request.Payload.GetLimit(),
                request.Payload.GetOffset()
                );

            return (IEnumerable<BrandSearchDTO>) dTOs;
        }

        async Task<BasePagedSearchDTO<BrandSearchDTO>> IRequestHandler<BrandSearchQueries, BasePagedSearchDTO<BrandSearchDTO>>.Handle(BrandSearchQueries request, CancellationToken cancellationToken)
        {
            BasePagedSearchDTO<BrandSearchDTO> dTOs = await _ibrandRepository.SeachAsync
                (
                request.Payload.Status,
                request.Payload.Description,
                request.Payload.MainProvider_Name,
                request.Payload.GetLimit(),
                request.Payload.GetOffset()
                );

            return (BasePagedSearchDTO<BrandSearchDTO>)dTOs;
        }
    }
}