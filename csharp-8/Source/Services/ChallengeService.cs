using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private CodenationContext _context;
        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {//deve retornar uma lista de desafios a partir do id da aceleração e do id do usuário
            return _context.Users.Where(x => x.Id == userId)
                .SelectMany(x => x.Candidates)
                .Where(x => x.AccelerationId == accelerationId)
                .Select(x => x.Acceleration.Challenge)
                .Distinct().ToList();            
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            var estado = challenge.Id == 0 ? EntityState.Added : EntityState.Modified;

            //setar estado do entity
            _context.Entry(challenge).State = estado;

            //persistir os dados
            _context.SaveChanges();

            //retornar o objeto
            return challenge;
        }
    }
}