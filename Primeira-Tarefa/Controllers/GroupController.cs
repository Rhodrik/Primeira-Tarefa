using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Primeira_Tarefa.DTO;
using Primeira_Tarefa.DTO.GroupDTO;
using Primeira_Tarefa.Payloads.GroupPayloads;
using Primeira_Tarefa.Services.Commands.GroupCommands;
using Primeira_Tarefa.Services.Queries.GroupQueries;

namespace Primeira_Tarefa.Controllers
{
    [Route("[controller]/")]
    public class GroupController : ControllerBase
    {

        private readonly Serilog.ILogger _logger;
        private readonly IMapper _mapper;
        IMediator _mediator;


        public GroupController
            (
            Serilog.ILogger logger,
            IMapper mapper,
            IMediator mediator
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Inserts a new group with the given data
        /// </summary>
        /// <param name="payload">Group data to be inserted</param>
        /// <remarks>
        /// Inserts a new group with the given data
        /// <para>
        /// To update an existing group use the update route
        /// </para>
        /// </remarks>        
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<GroupInsertPayload>> InsertIntoPostgres([FromBody] GroupInsertPayload payload)
        {
            GroupInsertCommand command = new GroupInsertCommand(payload);
            _logger.Information("The payload data for insertion has been sent to the command successfully");

            await _mediator.Send(command);
            _logger.Information("The insert command has been invoked successfully");

            return Ok();
        }

        /// <summary>
        /// Returns groups based on optional filters of: Id, Description or Use Subgroup
        /// </summary>
        /// <param name="payload">Group data to return</param>
        /// <remarks>
        /// None of the search fields is mandatory.
        /// <para>
        /// But at least one of them must be filled in.
        /// </para>
        /// <para>
        /// To return all active groups, consume the actives route.
        /// </para>
        /// </remarks>
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<BasePagedSearchDTO<GroupSearchDTO>>> Search([FromQuery] GroupSearchPayload payload)
        {
            GroupSearchQueries command = new GroupSearchQueries(payload);

            BasePagedSearchDTO<GroupSearchDTO> dTOs = await _mediator.Send(command);

            return Ok(dTOs);
        }

        /// <summary>
        /// Returns all groups with active status
        /// </summary>
        /// <remarks>
        /// Returns all groups with active status
        /// <para>
        /// To return groups based on other filters, consume the search route
        /// </para>  
        /// </remarks>
        [HttpGet]
        [Route("actives")]
        public async Task<ActionResult<List<GroupActivesDTO>>> GetAllActives()
        {
            GroupGetActiveQueries command = new GroupGetActiveQueries();
            _logger.Information("The command has been successfully instantiated");

            IEnumerable<GroupActivesDTO> dto = await _mediator.Send(command);
            _logger.Information("A list of all the active groups has been successfully created");

            if (!dto.Any())
                return NoContent();
            _logger.Information("Validation was successfully performed to check if the list contains any records");

            return Ok(dto);
        }

        /// <summary>
        /// Updates the data of the selected group
        /// </summary>
        /// <param name="id"> Group Id to be searched</param>
        /// <param name="payload">Group data to be updated</param>
        /// <remarks>
        /// Updates the data of the selected Group.
        /// <para>
        /// To insert data consume the post route.
        /// </para>
        /// </remarks>
        [HttpPut]
        [Route("{Id:int}")]
        public async Task<ActionResult<int>> Upload(
            [FromRoute] int id,
            [FromBody] GroupUpdatePayload payload)
        {
            GroupUpdateCommand command = new GroupUpdateCommand(payload, id);
            _logger.Information("The necessary data for the update has been sent to the command successfully");

            await _mediator.Send(command);
            _logger.Information("The update command has been invoked successfully");

            return Ok();

        }
    }
}