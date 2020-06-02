using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _service;

        public QuoteController(IQuoteService service)
        {
            _service = service;
        }

        // GET api/quote
        [HttpGet]
        public ActionResult<QuoteView> GetAnyQuote()
        {//Retorna uma frase aleatória de qualquer ator
            var aleatorio = _service.GetAnyQuote();
            if (aleatorio != null)
            {
                var retornoAux = new QuoteView()
                {
                    Id = aleatorio.Id,
                    Actor = aleatorio.Actor,
                    Detail = aleatorio.Detail
                };
                return retornoAux;
            }
            else
                return NotFound();
        }

        // GET api/quote/{actor}
        [HttpGet("{actor}")]
        public ActionResult<QuoteView> GetAnyQuote(string actor)
        {//Retorna uma frase aleatória do ator passado como parâmetro.
            var aleatorio = _service.GetAnyQuote(actor);
            
            if (aleatorio != null)
            {
                var retornoAux = new QuoteView()
                {
                    Id = aleatorio.Id,
                    Actor = aleatorio.Actor,
                    Detail = aleatorio.Detail
                };
                return retornoAux;
            }
            else
                return NotFound();
        }

    }
}
