namespace Primeira_Tarefa.DTO.GroupDTO
{
    public class GroupActivesDTO
    {
        /// <summary>
        /// Group identification field "Id" 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Group identification field "Description" 
        /// </summary>
        public string? Description { get; set; }

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
