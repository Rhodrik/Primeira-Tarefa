namespace Primeira_Tarefa.Payloads
{
    public class BasePagedSearchPayload
    {
        private int? _pageNumber;
        private int? _pageSize;

        /// <summary>
        /// Defaut value is 1 
        /// </summary>
        public int? PageNumber
        {
            get => _pageNumber > 0 ? _pageNumber : 1;
            set => _pageNumber = value;
        }

        /// <summary>
        /// Defaut value is 10 
        /// </summary>
        public int? PageSize
        {
            get => _pageSize > 0 ? _pageSize : 10;
            set => _pageSize = value;
        }

        public int GetLimit() => PageSize.GetValueOrDefault();

        public int GetOffset()
        {
            return (PageNumber.GetValueOrDefault() - 1) * PageSize.GetValueOrDefault();
        }
    }
}
