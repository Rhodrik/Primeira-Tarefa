using Dommel;
using Dapper;
using Primeira_Tarefa.DTO;
using Primeira_Tarefa.Types;
using static Dapper.SqlMapper;
using Primeira_Tarefa.Extension;
using Primeira_Tarefa.DTO.BrandDTO;
using Primeira_Tarefa.Interfaces.Connections;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using System.Collections.Generic;

namespace Primeira_Tarefa.Repository
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        private readonly IPostgresConnection _conn;

        public BrandRepository(IPostgresConnection conn) : base(conn)
        {
            _conn = conn;
        }

        public async Task<int> InsertasAsync(Brand brand)
        {
            int id = (int)await _conn.Get().InsertAsync<Brand>(brand);
            return id;
        }

        public async Task<IEnumerable<BrandActivesDTO>> GetActivesAsync()
        {
            string sql = @"Select id as Id, description as Description from new_brand_table where status = true";
            IEnumerable<BrandActivesDTO> dTOs = await _conn.Get().QueryAsync<BrandActivesDTO>(sql);
            return dTOs;
        }

        public async Task<IEnumerable<Brand>> GetAllasAsync()
        {
            return await _conn.Get().GetAllAsync<Brand>();
        }

        public async Task<Brand?> GetByiDAsync(int id)
        {
            Brand? datas = await _conn.Get().GetAsync<Brand>(id);
            return datas;
        }

        public async Task<BasePagedSearchDTO<BrandSearchDTO>> SeachAsync
            (bool statuS,
            string? descripTion,
            string? mainprovidernamE,
            int limiT,
            int offseT)
        {
            string searchInSqlColuns = @"SELECT id AS Id,
                                         description AS Description,
                                         mainprovidername AS MainProvider_Name 
                                         FROM new_brand_table";
            string whereForSqlSearch = "WHERE new_brand_table.Status = @statuS";

            DynamicParameters parameters = new();
            parameters.Add("statuS", statuS, System.Data.DbType.Boolean);

            if (descripTion.IsFill())
            {
                whereForSqlSearch += " AND description  ILIKE CONCAT('%', @descripTion, '%')";
                parameters.Add("description", descripTion);
            }
            if (mainprovidernamE.IsFill())
            {
                whereForSqlSearch += " AND mainprovidername  ILIKE CONCAT('%', @mainprovidername, '%')";
                parameters.Add("mainprovidername", mainprovidernamE);
            }

            string pagedSearch = $"{searchInSqlColuns} {whereForSqlSearch} limit {limiT} offset {offseT}";
            string searchInSql = $"SELECT COUNT(id) FROM new_brand_table {whereForSqlSearch}";

            GridReader reader = await _conn.Get().QueryMultipleAsync(
                sql: $"{pagedSearch}; {searchInSql}",
                parameters
                );
            IEnumerable<BrandSearchDTO> data = await reader.ReadAsync<BrandSearchDTO>();
            int recordCount = await reader.ReadSingleAsync<int>();

            BasePagedSearchDTO<BrandSearchDTO>? dTO = new();
            dTO.Data = data;
            dTO.RecordCount = recordCount;

            return dTO;
        }

        public async Task<int> UpdateasAsync(Brand brand)
        {
            await _conn.Get().UpdateAsync(brand);

            return (brand.Id);
        }



        public async Task<bool> IdExist(int id)
        {
            return await _conn.Get().AnyAsync<Brand>(x => x.Id == id);
        }
    }
}