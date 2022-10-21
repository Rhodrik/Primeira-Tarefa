namespace Primeira_Tarefa.Payloads.GroupPayloads
{
    public class GroupUpdatePayload
    {
        private int _Id;
        /// <summary>
        /// Group name to be updated
        /// <para>
        /// With a maximum limit of 30 characters
        /// </para>
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Group status to be updated
        /// <code>
        /// true = active
        /// <para>
        /// false = inactive
        /// </para>
        /// </code>
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Group "Use Subgroup" status to be updated
        /// <code>
        /// true = active
        /// <para>
        /// false = inactive
        /// </para>
        /// </code>
        /// </summary>
        public bool UseSubgroup { get; set; }
    
        public void SetId(int Id)
        {
            this._Id = Id;
        }
        public int GetId()
        {
            return _Id;
        }
    
    }
}
