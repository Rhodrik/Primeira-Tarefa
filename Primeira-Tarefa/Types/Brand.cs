namespace Primeira_Tarefa.Types
{
    public class Brand
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string? MainProvider_Name { get; set; }
        public DateTime? Since { get; set; }
    }
}
