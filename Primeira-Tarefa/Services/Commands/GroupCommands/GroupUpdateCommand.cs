using MediatR;
using Primeira_Tarefa.Payloads.GroupPayloads;

namespace Primeira_Tarefa.Services.Commands.GroupCommands
{
    public class GroupUpdateCommand : IRequest
    {
        public GroupUpdateCommand(GroupUpdatePayload payload, int id)
        {
            payload.SetId(id);
            Payload = payload;
        }
        public GroupUpdatePayload Payload { get; }
    }
}
