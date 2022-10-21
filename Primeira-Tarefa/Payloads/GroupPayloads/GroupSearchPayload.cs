namespace Primeira_Tarefa.Payloads.GroupPayloads
{
    public class GroupSearchPayload
    {

        /// <summary>
        /// Search field "Description"<para>Not required field</para></summary>
        /// <example>Group Name</example>
        public string? Description { get; set; }

        /// <summary>
        /// Search field "Status"<para>Not required field</para></summary>
        ///<example>True</example>
        public bool Status { get; set; }

        /// <summary>
        /// Search field "UseSubgroup"<para>Not required field</para></summary>
        ///<example>True</example>
        public bool UseSubgroup { get; set; }
    }
}
