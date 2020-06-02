using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private IChallengeService _challengeService;
        private readonly IMapper _mapper;

        public ChallengeController(IChallengeService service, IMapper mapper)
        {
            _challengeService = service;
            _mapper = mapper;
        }

        //GET api/challenge
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {// accelerationId e userId: deve apontar para o método FindByAccelerationIdAndUserId e retornar uma lista de ChallengeDTO
            if (accelerationId.HasValue && userId.HasValue)
            {
                return Ok(_challengeService.FindByAccelerationIdAndUserId(accelerationId.Value, userId.Value)
                    .Select(x => _mapper.Map<ChallengeDTO>(x))
                    .ToList());
            }
            else
                return NoContent(); //204
        }

        //POST api/challenge
        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // mapear Dto para Model
            var user = _mapper.Map<Models.Challenge>(value);
            //Salvar
            var retorno = _challengeService.Save(user);
            //mapear Model para Dto
            return Ok(_mapper.Map<ChallengeDTO>(retorno));
        }
    }
}
