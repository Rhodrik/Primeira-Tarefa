using Dapper.FluentMap.Dommel.Mapping;
using Primeira_Tarefa.Types;

namespace Primeira_Tarefa.Database_Maps
{
    public class GroupDbMap : DommelEntityMap<Group>
    {
        public GroupDbMap()
        { 
            ToTable("new_group_table");
            Map(x => x.Id)
                    .IsKey()
                    .IsIdentity()
                    .ToColumn("id", false);
            Map(x => x.Description)
                   .ToColumn("description", false);
            Map(x => x.Status)
                    .ToColumn("status", false);
            Map(x => x.UseSubgroup)
                    .ToColumn("use_subgroup", false);
        }
    }
}
