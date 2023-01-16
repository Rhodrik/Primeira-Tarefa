using AutoMapper;
using Primeira_Tarefa.Types;
using Primeira_Tarefa.Payloads.BrandPayloads;

namespace Primeira_Tarefa.Map
{
    public class BrandMapProfile : Profile
    {
        public BrandMapProfile()
        {
            CreateMap<BrandInsertPayload, Brand>();
            CreateMap<BrandUpdatePayload, Brand>();
        }
    }
}
