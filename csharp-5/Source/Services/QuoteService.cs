using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            //lista inteira de quotes
            var query = _context.Quotes.ToList();
            // se não retronar valor na lista não retorna valor na requisição
            if (query.Count == 0)
                return null;
            // a partir do tamanho da lista, retorna um valor aleatório que utilizaremos de index
            var RandomIndex = _randomService.RandomInteger(query.Count());
            // o metodo skip ignora a lista até o index passado como argumento
            var retorno = query.Skip(RandomIndex).FirstOrDefault();
            //retorno frase aleatorio

            if (retorno != null)
            {
                return retorno;
            }                
            return null;
        }

        public Quote GetAnyQuote(string actor)
        {//lista inteira de quotes por ator
            var query = _context.Quotes.ToList();
            // se não retronar valor na lista não retorna valor na requisição
            if (query.Count == 0)
                return null;
            // a partir do tamanho da lista, retorna um valor aleatório que utilizaremos de index
            var RandomIndex = _randomService.RandomInteger(query.Count());

            var autor = _context.Quotes.Where(x => x.Actor == actor).Skip(RandomIndex).FirstOrDefault();

            if (autor != null)
            {
               return autor;
            }
            return null;

        }
    }
}