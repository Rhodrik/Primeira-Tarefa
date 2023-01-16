using MediatR;
using Primeira_Tarefa.Payloads.BrandPayloads;

namespace Primeira_Tarefa.Services.Commands.BrandCommands
{
    public class BrandUpdateCommand : IRequest
    {
        public BrandUpdateCommand(BrandUpdatePayload payload, int id)
        {
            payload.SetId(id);
            Payload = payload;
        }
        public BrandUpdatePayload Payload { get; }
    }
}
