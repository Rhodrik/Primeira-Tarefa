namespace Primeira_Tarefa.Payloads.GroupPayloads
{
    public class GroupSearchPayload : BasePagedSearchPayload
    {
        /// <summary>
        /// Search field "Description"
        /// <para>
        /// Not required field
        /// </para>
        /// <code>
        /// Group Name
        /// </code>
        /// </summary>
        public string? Description { get; set; }

        /// <summary>Search field "Status"
        /// <para>
        /// information is not mandatory for the proper functioning of the research
        /// </para>
        /// <code>True</code>
        /// = Actives
        /// <para>
        /// <code>False</code>
        /// = Inactives
        /// </para>
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Search field "UseSubgroup"
        /// <para>
        /// Not required field
        /// </para>
        /// <code>
        /// true = active
        /// <para>
        /// false = inactive
        /// </para>
        /// </code>
        /// </summary>
        public bool UseSubgroup { get; set; }
    }
}
