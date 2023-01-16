namespace Primeira_Tarefa.DTO
{
    public class BasePagedSearchDTO<T>
    {
        public IEnumerable<T>? Data { get; set; }

        public int RecordCount { get; set; }
    }
}
