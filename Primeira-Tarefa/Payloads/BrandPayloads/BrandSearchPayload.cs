using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Security.Principal;

namespace Primeira_Tarefa.Payloads.BrandPayloads
{
    public class BrandSearchPayload : BasePagedSearchPayload
    {
        /// <summary>Search field "Description"
        /// <para>
        /// information is not mandatory for the proper functioning of the research
        /// </para>
        /// </summary>
        public string? Description { get; set; }

        /// <summary>Search field "Status"
        /// <para>
        /// information to fill in is not mandatory for the proper functioning of the research
        /// </para>
        /// <code>True</code>
        /// = Actives
        /// <para>
        /// <code>False</code>
        /// = Inactives
        /// </para>
        /// </summary>
        public bool Status { get; set; }

        /// <summary>Search field "Main Provider Name"
        /// <para>
        /// information to fill in is not mandatory for the proper functioning of the research
        /// </para>
        /// </summary>
        public string? MainProvider_Name { get; set; }
    }
}
