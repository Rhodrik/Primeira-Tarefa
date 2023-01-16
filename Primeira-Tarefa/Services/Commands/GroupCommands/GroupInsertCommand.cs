using MediatR;
using Primeira_Tarefa.Payloads.GroupPayloads;

namespace Primeira_Tarefa.Services.Commands.GroupCommands
{
    public class GroupInsertCommand : IRequest
    {
        public GroupInsertCommand(GroupInsertPayload payload)
        {
            Payload = payload;
        }
        public GroupInsertPayload Payload { get; }
    }
}
