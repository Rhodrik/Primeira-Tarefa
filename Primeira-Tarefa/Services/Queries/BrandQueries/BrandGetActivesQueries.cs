using MediatR;
using Primeira_Tarefa.DTO.BrandDTO;

namespace Primeira_Tarefa.Services.Queries.BrandQueries
{
    public class BrandGetActivesQueries : IRequest<IEnumerable<BrandActivesDTO>>
    {
    }
}
