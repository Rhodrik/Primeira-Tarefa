using AutoMapper;
using Primeira_Tarefa.Controllers;
using Primeira_Tarefa.DTO.BrandDTO;
using Primeira_Tarefa.Payloads;
using Primeira_Tarefa.Payloads.BrandPayloads;
using Primeira_Tarefa.Types;

namespace Primeira_Tarefa.Map
{
    public class BrandMapProfile : Profile
    {
        public BrandMapProfile()
        {
            CreateMap<BrandInsertPayload, Brand>();
            CreateMap<Brand, BrandActivesDTO>();
            CreateMap<Brand, BrandSeachDTO>();
        }

    }
}
