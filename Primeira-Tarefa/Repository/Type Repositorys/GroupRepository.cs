using Dommel;
using Dapper;
using Primeira_Tarefa.DTO;
using Primeira_Tarefa.Types;
using static Dapper.SqlMapper;
using Primeira_Tarefa.Extension;
using Primeira_Tarefa.DTO.GroupDTO;
using Primeira_Tarefa.Interfaces.Connections;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;

namespace Primeira_Tarefa.Repository
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        private readonly IPostgresConnection _connection;
        public GroupRepository(IPostgresConnection conn) : base(conn)
        {
            _connection = conn;
        }

        public async Task<int> InsertasAsync(Group group)
        {
            int id = (int)await _connection.Get().InsertAsync<Group>(group);
            return id;
        }

        public async Task<IEnumerable<GroupActivesDTO>> ActivesAsync()
        {
            string sql = @"Select id as Id, description as Description from new_group_table where status = true";
            IEnumerable<GroupActivesDTO> dTOs = await _connection.Get().QueryAsync<GroupActivesDTO>(sql);
            return dTOs;
        }

        public async Task<IEnumerable<Group>> AllasAsync()
        {
            return await _connection.Get().GetAllAsync<Group>();
        }

        public async Task<Group> ByIdasAsync(int id)
        {
            Group data = await _connection.Get().GetAsync<Group>(id);
            return data;
        }

        public async Task<BasePagedSearchDTO<GroupSearchDTO>> SeachasAsync
            (bool statuS,
            string? descripTion,
            bool useSubgroup,
            int limit,
            int offset)
        {
            string searchInSqlColuns = @"SELECT id AS Id,
                                         description AS Description,
                                         use_subgroup AS UseSubgroup 
                                         FROM new_group_table";
            string whereForSqlSearch = "WHERE new_group_table.status = @statuS AND use_subgroup = @useSubgroup";

            DynamicParameters parameters = new();
            parameters.Add("statuS", statuS, System.Data.DbType.Boolean);
            parameters.Add("useSubgroup", useSubgroup, System.Data.DbType.Boolean);

            if (descripTion.IsFill())
            {
                whereForSqlSearch += "AND description  ILIKE CONCAT('%', @descripTion, '%')";
                parameters.Add("description", descripTion);
            }

            string pagedSearch = $"{searchInSqlColuns} {whereForSqlSearch} limit {limit} offset {offset}";
            string searchInSql = $"SELECT COUNT(id) FROM new_group_table {whereForSqlSearch}";

            GridReader reader = await _connection.Get().QueryMultipleAsync(
                sql: $"{pagedSearch}; {searchInSql}",
                parameters
                );
            IEnumerable<GroupSearchDTO> data = await reader.ReadAsync<GroupSearchDTO>();
            int recordCount = await reader.ReadSingleAsync<int>();

            BasePagedSearchDTO<GroupSearchDTO>? dTOs = new();
            dTOs.Data = data;
            dTOs.RecordCount = recordCount;

            return dTOs;

        }

        public async Task<int> UpdateasAsync(Group group)
        {
           await _connection.Get().UpdateAsync(group);

            return (group.Id);
        }

        public async Task<bool> IdExist(int id)
        {
            return await _connection.Get().AnyAsync<Group>(x => x.Id == id);
        }
    } 
} 
