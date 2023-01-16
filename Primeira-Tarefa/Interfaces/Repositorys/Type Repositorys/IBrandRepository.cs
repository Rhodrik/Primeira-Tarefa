using Primeira_Tarefa.DTO;
using Primeira_Tarefa.DTO.BrandDTO;
using Primeira_Tarefa.Types;

namespace Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {
        Task<int> InsertasAsync(Brand brand);

        Task<IEnumerable<BrandActivesDTO>> GetActivesAsync();

        Task<IEnumerable<Brand>> GetAllasAsync();

        Task<BasePagedSearchDTO<BrandSearchDTO>> SeachAsync
            (bool status, string? descriptionS, string? mainprovidername, int limit, int offset);

        Task<Brand> GetByiDAsync(int id);

        Task<int> UpdateasAsync(Brand brand);

        Task<bool> IdExist(int id);
    }
}
