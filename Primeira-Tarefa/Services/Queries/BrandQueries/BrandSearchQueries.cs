using MediatR;
using Primeira_Tarefa.DTO;
using Primeira_Tarefa.DTO.BrandDTO;
using Primeira_Tarefa.Payloads.BrandPayloads;

namespace Primeira_Tarefa.Services.Queries.BrandQueries
{
    public class BrandSearchQueries : IRequest<BasePagedSearchDTO<BrandSearchDTO>>
    {
        public BrandSearchQueries(BrandSearchPayload payload)
        {
            Payload = payload;
        }
        public BrandSearchPayload Payload { get; }

    }
}
