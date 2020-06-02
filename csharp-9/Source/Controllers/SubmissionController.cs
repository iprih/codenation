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
    public class SubmissionController : ControllerBase
    {
        private ISubmissionService _submissionService;
        private readonly IMapper _mapper;

        public SubmissionController(ISubmissionService service, IMapper mapper)
        {
            _submissionService = service;
            _mapper = mapper;

        }
        // GET api/submission/higherScore
        [HttpGet("higherScore")]
        public ActionResult<SubmissionDTO> GetHigherScore(int? challengeId)
        {//deve apontar para o método FindHigherScoreByChallengeId e retornar o valor do maior score
            if (challengeId.HasValue)
            {
                return Ok(_submissionService.FindHigherScoreByChallengeId(challengeId.Value));
            }
            else
                return NoContent();
        }

        // GET api/submission
        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? accelerationId = null, int? challengeId = null)
        {
            if (accelerationId.HasValue && challengeId.HasValue)
            {
                return Ok(_submissionService.FindByChallengeIdAndAccelerationId(accelerationId.Value, challengeId.Value)
                    .Select(x => _mapper.Map<SubmissionDTO>(x))
                    .ToList());
            }

            else
                return NoContent();
        }

        //POST api/submission
        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var submission = _mapper.Map<Submission>(value);
            var retorno = _submissionService.Save(submission);
            return Ok(_mapper.Map<SubmissionDTO>(retorno));





        }
        
    }
}
