namespace Primeira_Tarefa.Payloads.GroupPayloads
{
    public class GroupInsertPayload
    {
        /// <summary>
        /// Group name to be entered
        /// <para>
        /// With a maximum limit of 30 characters
        /// </para>
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Group status to be entered
        /// <code>
        /// true = active
        /// <para>
        /// false = inactive
        /// </para>
        /// </code>
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Group "Use Subgroup" status to be entered
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
