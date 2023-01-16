namespace Primeira_Tarefa.Payloads.BrandPayloads
{
    public class BrandInsertPayload
    {
        /// <summary>
        /// Brand name to be inserted
        /// <para>
        /// With a maximum limit of 30 characters
        /// </para>
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Brand status to be inserted
        /// <code>
        /// true = active
        /// <para>
        /// false = inactive
        /// </para>
        /// </code>
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Brand main provider name to be inserted
        /// <para>
        /// With a maximum limit of 150 characters
        /// </para>
        /// </summary>
        public string? MainProvider_Name { get; set; }

        /// <summary>
        /// Brand opening date to be inserted
        /// <para>
        /// The opening date cannot exceed the current date
        /// </para>
        /// </summary>
        public DateTime? Since { get; set; }
    }
}
