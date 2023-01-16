using MediatR;
using Primeira_Tarefa.Types;

namespace Primeira_Tarefa.Services.Queries.BrandQueries
{
    public class BrandGetByIdQueries : IRequest<Brand>
    {
        public BrandGetByIdQueries(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
