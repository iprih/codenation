using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private CodenationContext _context;
        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {//deve retornar uma lista de candidatos a partir do id da aceleração
            return _context.Candidates.Where(x => x.AccelerationId == accelerationId)
                .Distinct().ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {//deve retornar uma lista candidatos a partir do id da empresa
            return _context.Candidates.Where(x => x.CompanyId == companyId)
                .Distinct().ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return _context.Candidates.Find(userId, accelerationId, companyId);
        }

        public Candidate Save(Candidate candidate)
        {// deve retornar um candidato após salvar os dados. Caso a tupla UserId, AccelartionId e CompanyId não exista, fará a inserção do candidato, 
         //caso contrário fará a atualização dos dados do candidato
            var exist = _context.Candidates.Find(candidate.UserId, candidate.AccelerationId, candidate.CompanyId);

            if(exist == null)
            {
                _context.Candidates.Add(candidate);
            }
            else
            {
                exist.Status = candidate.Status;
            }
            _context.SaveChanges();

            return candidate;
        }
    }
}
