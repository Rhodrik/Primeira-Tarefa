namespace Primeira_Tarefa.Payloads.BrandPayloads
{
    public class BrandGetByIdPayload
    {
        private int _id;

        public void SetId(int id)
        {
            this._id = id;
        }

        public int GetId()
        {
            return _id;
        }
    }
}
