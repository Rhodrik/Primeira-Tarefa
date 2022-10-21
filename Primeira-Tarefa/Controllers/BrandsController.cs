using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Primeira_Tarefa.DataBase;
using Primeira_Tarefa.DTO.BrandDTO;
using Primeira_Tarefa.DTO.GroupDTO;
using Primeira_Tarefa.Map;
using Primeira_Tarefa.Payloads.BrandPayloads;
using Primeira_Tarefa.Payloads.GroupPayloads;
using Primeira_Tarefa.Types;
using Primeira_Tarefa.Validators.BrandValidators;
using System.Collections.Generic;

namespace Primeira_Tarefa.Controllers
{
    [Route("[controller]/")]
    public class BrandsController : ControllerBase
    {
        private readonly BrandDataBase _brandDataBase;
        private readonly IMapper _mapper;
        private readonly IValidator<BrandInsertPayload> _insertvalidator;
        private readonly IValidator<BrandUpdatePayload> _updatevalidator;
        private readonly IValidator<BrandSearchPayload> _searchvalidator;
        private readonly IValidator<BrandGetByIdPayload> _getbyidvalidator;

        public BrandsController
            (
            BrandDataBase brandDataBase,
            IMapper mapper,
            IValidator<BrandInsertPayload> insertvalidator,
            IValidator<BrandUpdatePayload> updatevalidator,
            IValidator<BrandSearchPayload> searchvalidator,
            IValidator<BrandGetByIdPayload> getbyidvalidator
            )
        {
            _brandDataBase = brandDataBase;
            _mapper = mapper;
            _insertvalidator = insertvalidator;
            _updatevalidator = updatevalidator;
            _searchvalidator = searchvalidator;
            _getbyidvalidator = getbyidvalidator;
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
        public ActionResult<int> Incert([FromBody] BrandInsertPayload payload)
        {
            _insertvalidator.ValidateAndThrow(payload);
            // Exceção Generica a ser tratada, com o catch do ErrorHandlerMiddleWere:
            //throw new Exception("*******");

            Brand brandmap = _mapper.Map<Brand>(payload);
            Brand brand = new Brand()
            {
                Id = _brandDataBase.BrandList.Count() + 1,
                Description = payload.Description,
                Status = payload.Status,
                MainProvider_Name = payload.MainProvider_Name,
                Since = payload.Since
            };

            _brandDataBase.BrandList.Add(brand);

            return Created("", brand.Id);
        }

        /// <summary>
        /// Returns all brands regardless of any filter
        /// </summary>
        [HttpGet]
        [Route("all")]
        public ActionResult<List<Brand>> GetAll()
        {
            if (_brandDataBase.BrandList.Count == 0)
            {
                return NoContent();
            }

            return Ok(_brandDataBase.BrandList);
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
        [Route("byid/{Id:int}")]
        public ActionResult<int> GetById([FromRoute(Name = "Id")] int id)
        {
            BrandGetByIdPayload payload = new BrandGetByIdPayload();

            payload.SetId(id);

            _getbyidvalidator.ValidateAndThrow(payload);

            Brand brand = _brandDataBase.BrandList.FirstOrDefault(x => x.Id == id);

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
        public ActionResult<List<Brand>> GetAllActives()
        {
            IEnumerable<Brand> actives = _brandDataBase.BrandList.Where(x => x.Status);
            if (!actives.Any())
                return NoContent();
            IEnumerable<BrandActivesDTO> dto = actives.Select(brand =>
            {
                return new BrandActivesDTO
                {
                    Id = brand.Id,
                    Description = brand.Description,
                };
            });

            IEnumerable<BrandActivesDTO> brandmap = _mapper.Map<IEnumerable<BrandActivesDTO>>(actives);

            return Ok(brandmap);
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
        public ActionResult<List<Brand>> Search([FromQuery] BrandSearchPayload payload)
        {
            IEnumerable<Brand> brands = _brandDataBase.BrandList.Where(x => x.Status == payload.Status);

            _searchvalidator.ValidateAndThrow(payload);

            brands = brands.Where(x => x.Description == payload.Description);
            brands = brands.Where(x => x.MainProvider_Name == payload.MainProvider_Name);


            IEnumerable<Brand> brandmap = _mapper.Map<IEnumerable<Brand>>(brands);

            return Ok(brandmap);
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
        public ActionResult<int> Upload(
            [FromRoute(Name = "Id")] int Id,
            [FromBody] BrandUpdatePayload payload)
        {
            _updatevalidator.ValidateAndThrow(payload);
            Brand? brand = _brandDataBase.BrandList.First(x => x.Id == Id);

            brand.Description = payload.Description;
            brand.Status = payload.Status;
            brand.MainProvider_Name = payload.MainProvider_Name;
            brand.Since = payload.Since;

            return NoContent();
        }
    }
}