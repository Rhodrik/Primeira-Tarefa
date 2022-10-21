using AutoMapper;
using Primeira_Tarefa.DTO.GroupDTO;
using Primeira_Tarefa.Payloads.GroupPayloads;

namespace Primeira_Tarefa.Map
{
    public class GroupMapProfile : Profile
    {
        public GroupMapProfile()
        {
            CreateMap<GroupInsertPayload, Group>();
            CreateMap<Group, GroupSearchDTO>();
            CreateMap<Group, GroupActivesDTO>();
        }
    }
}
