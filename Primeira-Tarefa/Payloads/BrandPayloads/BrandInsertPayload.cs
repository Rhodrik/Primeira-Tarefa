namespace Primeira_Tarefa.Payloads.BrandPayloads
{
    public class BrandInsertPayload
    {
        /// <summary>
        /// Insert field "Description"<para>Required field</para></summary>
        public string? Description { get; set; }

        /// <summary>
        /// Insert field "Status"<para>Required field</para></summary>
        public bool Status { get; set; }

        /// <summary>
        /// Insert field "MainProvider_Name"<para>Required field</para></summary>
        public string? MainProvider_Name { get; set; }

        /// <summary>
        /// Insert field "Since"<para>Required field</para></summary>
        public DateTime? Since { get; set; }
    }
}
