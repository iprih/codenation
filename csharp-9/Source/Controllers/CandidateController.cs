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
    public class CandidateController : ControllerBase
    {
        private ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService service, IMapper mapper)
        {
            _candidateService = service;
            _mapper = mapper;
        }
        // GET api/candidate/{userId}/{accelerationId}/{companyId}
        [HttpGet("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {//deve apontar para o método FindById e retornar um CandidateDTO
            var candidate = _candidateService.FindById(userId, accelerationId, companyId);

            if (candidate != null)
            {
                var retorno = _mapper.Map<CandidateDTO>(candidate);

                return Ok(retorno);
            }

            else
                return NotFound();
        }

        // GET api/candidate
        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? accelerationId = null, int? companyId = null)
        {//companyId: deve apontar para o método FindByCompanyId e retornar uma lista de CandidateDTO
         //accelerationId: deve apontar para o método FindByAccelerationId e retornar uma lista de CandidateDTO
            if (companyId.HasValue)
            {
                return Ok(_candidateService.FindByCompanyId(companyId.Value)
                     .Select(x => _mapper.Map<CandidateDTO>(x))
                     .ToList());          
            }
            else if (accelerationId.HasValue)
            {
                return Ok(_candidateService.FindByAccelerationId(accelerationId.Value)
                    .Select(x => _mapper.Map<CandidateDTO>(x))
                    .ToList());
            }
            else
                return NoContent();
        }

        // POST api/user
        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var candidate = _mapper.Map<Candidate>(value);
            var retorno = _candidateService.Save(candidate);

            return Ok(_mapper.Map<CandidateDTO>(retorno));
        }
    }
}
