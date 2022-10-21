using System.Security.Cryptography;

namespace Primeira_Tarefa.Payloads.BrandPayloads
{
    public class BrandUpdatePayload
    {
        private int _Id;


        public string? Description { get; set; }


        public bool Status { get; set; }


        public string? MainProvider_Name { get; set; }


        public DateTime? Since { get; set; }


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
