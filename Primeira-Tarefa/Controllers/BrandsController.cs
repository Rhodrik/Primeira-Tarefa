using Dommel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Primeira_Tarefa.DTO;
using Primeira_Tarefa.DTO.BrandDTO;
using Primeira_Tarefa.Payloads.BrandPayloads;
using Primeira_Tarefa.Services.Commands.BrandCommands;
using Primeira_Tarefa.Services.Queries.BrandQueries;
using Primeira_Tarefa.Types;

namespace Primeira_Tarefa.Controllers
{
    [Route("[controller]/")]
    public class BrandController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IMediator _mediator;

        public BrandController
            (
            Serilog.ILogger logger,
            IMediator mediator
            )
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Inserts a new Brand with the given data
        /// </summary>
        /// <param name="payload">Brand data to be inserted</param>
        /// <remarks>
        /// Inserts a new brand with the given data
        /// <para>
        /// To update an existing brand use the update route
        /// </para>
        /// </remarks>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<BrandInsertPayload>> InsertIntoPostgres([FromBody] BrandInsertPayload payload)
        {
            BrandInsertCommand command = new BrandInsertCommand(payload);
            _logger.Information("The payload data for insertion has been sent to the command successfully");

            await _mediator.Send(command);
            _logger.Information("The insert command has been invoked successfully");

            return Ok();
        }

        /// <summary>
        /// Returns all brands regardless of any filter
        /// </summary>
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<Brand>>> GetAll()
        {
            BrandGetAllQueries command = new BrandGetAllQueries();
            _logger.Information("The command has been successfully instantiated");

            IEnumerable<Brand> dto = await _mediator.Send(command);
            _logger.Information("A list of all brands has been successfully created");

            if (!dto.Any())
                return NoContent();
            _logger.Information("Validation was successfully performed to check if the list contains any records");

            return Ok(dto);
        }

        /// <summary>
        /// Returns brand based on the Id filter
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// To return all active brands, consume the actives route.
        /// <para>
        /// Or o return brand based on other filters, consume the search route
        /// </para>
        /// </remarks>
        [HttpGet]
        [Route("get/{Id:int}")]
        public async Task<ActionResult<Brand>> ByidFromPostgres([FromRoute] int id)
        {
            //BrandGetByIdQueries
            BrandGetByIdQueries command = new BrandGetByIdQueries(id);
            _logger.Information("The command has been successfully instantiated with the search id");
            Brand brand = await _mediator.Send(command);
            _logger.Information("The data searched has been returned by the command");

            if (brand == null)
                return NoContent();
            _logger.Information("Validation was successfully performed to check if the data contains any records");

            return Ok(brand);
        }

        /// <summary>
        /// Returns all brand with active status
        /// </summary>
        /// <remarks>
        /// Returns all brand with active status
        /// <para>
        /// To return brand based on other filters, consume the search route
        /// </para>
        /// </remarks>
        [HttpGet]
        [Route("actives")]
        public async Task<ActionResult<List<BrandActivesDTO>>> GetAllActives()
        {
            BrandGetActivesQueries command = new BrandGetActivesQueries();
            _logger.Information("The command has been successfully instantiated");

            IEnumerable<BrandActivesDTO> dto = await _mediator.Send(command);
            _logger.Information("A list of all the active brands has been successfully created");

            if (!dto.Any())
                return NoContent();
            _logger.Information("Validation was successfully performed to check if the list contains any records");

            return Ok(dto);
        }

        /// <summary>
        /// Returns brand based on optional filters of: Id, Description or Use Subgroup
        /// </summary>
        /// <param name="payload">Brand data to return</param>
        /// <remarks>
        /// None of the search fields is mandatory.
        /// <para>
        /// But at least one of them must be filled in.
        /// </para>
        /// <para>
        /// To return all active brands, consume the actives route.
        /// </para>
        /// </remarks>
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<BasePagedSearchDTO<BrandSearchDTO>>> Search([FromQuery] BrandSearchPayload payload)
        {
            BrandSearchQueries command = new BrandSearchQueries(payload);

            BasePagedSearchDTO<BrandSearchDTO> dTOs = await _mediator.Send(command);
            
            return Ok(dTOs);
        }

        /// <summary>
        /// Updates the data of the selected brand
        /// </summary>
        /// <param name="Id"> Brand Id to be searched</param>   
        /// <param name="payload">Brand data to be updated</param>
        /// <remarks>
        /// Updates the data of the selected Brand.
        /// <para>
        /// To insert data consume the insert route.
        /// </para>
        /// </remarks>
        [HttpPut]
        [Route("{Id:int}")]
        public async Task<ActionResult<int>> Upload(
            [FromRoute] int id,
            [FromBody] BrandUpdatePayload payload)
        {
            BrandUpdateCommand command = new BrandUpdateCommand(payload, id);
            _logger.Information("The necessary data for the update has been sent to the command successfully");

            await _mediator.Send(command);
            _logger.Information("The update command has been invoked successfully");

            return Ok();
        }
    }
}