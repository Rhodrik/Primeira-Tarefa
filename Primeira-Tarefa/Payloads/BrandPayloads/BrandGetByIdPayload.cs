namespace Primeira_Tarefa.Payloads.BrandPayloads
{
    public class BrandGetByIdPayload
    {
        /// <summary>
        /// Id search field 
        /// <para> 
        /// Non-optional field for the proper functioning of the route
        /// </para>
        /// </summary>
        private int _id;

        /// <summary>
        /// Id search field 
        /// <para>
        /// Non-optional field for the proper functioning of the route
        /// </para>
        /// </summary>
        public void SetId(int id)
        {
            this._id = id;
        }

        /// <summary>
        /// Id search field 
        /// <para>
        /// Non-optional field for the proper functioning of the route
        /// </para>
        /// </summary>
        public int GetId()
        {
            return _id;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
