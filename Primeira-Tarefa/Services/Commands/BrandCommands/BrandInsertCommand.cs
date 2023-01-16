using MediatR;
using Primeira_Tarefa.Payloads.BrandPayloads;

namespace Primeira_Tarefa.Services.Commands.BrandCommands
{
    public class BrandInsertCommand : IRequest
    {
        public BrandInsertCommand(BrandInsertPayload payload)
        {
            Payload = payload;
        }
        public BrandInsertPayload Payload { get; }
    }
}