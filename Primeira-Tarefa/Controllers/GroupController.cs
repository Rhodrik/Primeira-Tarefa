using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Primeira_Tarefa.DataBase;
using Primeira_Tarefa.DTO.GroupDTO;
using Primeira_Tarefa.Payloads.GroupPayloads;
using Primeira_Tarefa.Validators.BrandValidators;
using Primeira_Tarefa.Validators.GroupValidators;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Primeira_Tarefa.Controllers
{
    [Route("[controller]/")]
    public class GroupController : ControllerBase
    {
        private readonly GroupDatabase _groupDatabase;
        private readonly IMapper _mapper;
        private readonly IValidator<GroupInsertPayload> _insertvalidator;
        private readonly IValidator<GroupUpdatePayload> _updatevalidator;
        private readonly IValidator<GroupSearchPayload> _searchvalidator;

        public GroupController
            (
            GroupDatabase groupDatabase,
            IMapper mapper,
            IValidator<GroupInsertPayload> insertvalidator,
            IValidator<GroupUpdatePayload> updatevalidator,
            IValidator<GroupSearchPayload> searchvalidator
            )
        {
            _groupDatabase = groupDatabase;
            _mapper = mapper;
            _insertvalidator = insertvalidator;
            _updatevalidator = updatevalidator;
            _searchvalidator = searchvalidator;
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
        public ActionResult<int> Insert([FromBody] GroupInsertPayload payload)
        {
            _insertvalidator.ValidateAndThrow(payload);

            Group groupmap = _mapper.Map<Group>(payload);

            Group group = new Group()
            {
                Id = _groupDatabase.GroupList.Count() + 1,
                Description = payload.Description,
                Status = payload.Status,
                UseSubgroup = payload.UseSubgroup,
            };

            _groupDatabase.GroupList.Add(groupmap);

            return Created("", group.Id);
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
        public ActionResult<List<GroupSearchDTO>> Search([FromQuery] GroupSearchPayload payload)
        {
            IEnumerable<Group> groups = _groupDatabase.GroupList.Where(x => x.Status == payload.Status);

            _searchvalidator.ValidateAndThrow(payload);

            groups = groups.Where(x => x.Description == payload.Description);
            
            IEnumerable<GroupSearchDTO> groupmap = _mapper.Map<IEnumerable<GroupSearchDTO>>(groups);

            return Ok(groups);

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
        public ActionResult<List<Group>> GetAlActives()
        {
            IEnumerable<Group> actives = _groupDatabase.GroupList.Where(x => x.Status);
            if (!actives.Any())
                return NoContent();
            IEnumerable<GroupActivesDTO> dto = actives.Select(group =>
            {
                return new GroupActivesDTO
                {
                    Id = group.Id,
                    Description = group.Description,
                };
            });

            IEnumerable<GroupActivesDTO> groupmap = _mapper.Map<IEnumerable<GroupActivesDTO>>(actives);

            return Ok(groupmap);
        }

        /// <summary>
        /// Updates the data of the selected group
        /// </summary>
        /// <param name="Id"> Group Id to be searched</param>
        /// <param name="payload">Group data to be updated</param>
        /// <remarks>
        /// Updates the data of the selected Group.
        /// <para>
        /// To insert data consume the post route.
        /// </para>
        /// </remarks>
        [HttpPut]
        [Route("{Id:int}")]
        public ActionResult<int> Upload(
            [FromRoute(Name = "Id")] int groupId, 
            [FromBody] GroupUpdatePayload payload)
        {
            payload.SetId(groupId);
            _updatevalidator.ValidateAndThrow(payload);

            Group group = _groupDatabase.GroupList.First(x => x.Id == groupId);

            group.Description = payload.Description;
            group.Status = payload.Status;
            group.UseSubgroup = payload.UseSubgroup;

            return NoContent();
        }
    }
}