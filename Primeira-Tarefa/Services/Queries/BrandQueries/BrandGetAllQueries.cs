using MediatR;
using Primeira_Tarefa.Types;

namespace Primeira_Tarefa.Services.Queries.BrandQueries
{
    public class BrandGetAllQueries : IRequest<IEnumerable<Brand>>
    {
    }
}
