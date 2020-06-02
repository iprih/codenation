using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    { 
        private ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _companyService = service;
            _mapper = mapper;
        }

        // GET api/company/{id}
        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            var company = _companyService.FindById(id);

            if (company != null)
            {
                return Ok(_mapper.Map<CompanyDTO>(company));
            }
            else
                return NotFound();//404
        }
        //GET api/company
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {//accelerationId: deve apontar para o método FindByAccelerationIde retornar uma lista de CompanyDTO
         //userId: deve apontar para o método FindByUserId e retornar uma lista de CompanyDTO
            if (accelerationId.HasValue)
            {
                return Ok(_companyService.FindByAccelerationId(accelerationId.Value)
                    .Select(x => _mapper.Map<CompanyDTO>(x))
                    .ToList());
            }
            else if (userId.HasValue)
            {
                return Ok(_companyService.FindByUserId(userId.Value)
                    .Select(x => _mapper.Map<CompanyDTO>(x))
                    .ToList());
            }
            else
                return NoContent(); //204
        }
        //POST api/company
        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // mapear Dto para Model
            var user = _mapper.Map<Company>(value);
            //Salvar
            var retorno = _companyService.Save(user);
            //mapear Model para Dto
            return Ok(_mapper.Map<CompanyDTO>(retorno));
        }


    }

}
