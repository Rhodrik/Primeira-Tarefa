using Dapper.FluentMap.Dommel.Mapping;
using Primeira_Tarefa.Types;

namespace Primeira_Tarefa.Database_Maps
{
    public class BrandDbMap : DommelEntityMap<Brand>
    {
        public BrandDbMap()
        {

            ToTable("new_brand_table");
            Map(x => x.Id)
                    .IsKey()
                    .IsIdentity()
                    .ToColumn("id", false);
            Map(x => x.Description)
                   .ToColumn("description", false);
            Map(x => x.Status)
                    .ToColumn("status", false); 
            Map(x => x.MainProvider_Name)
                    .ToColumn("mainprovidername", false);
            Map(x => x.Since)
                .ToColumn("since", false);
        }
    }
}
