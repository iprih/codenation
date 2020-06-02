using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private CodenationContext _context;
        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {//deve retornar uma lista de submiss�es a partir do id do desafio e do id da acelera��o
            return _context.Candidates.Where(x => x.AccelerationId == accelerationId)
                .Select(x => x.User)
                .SelectMany(x => x.Submissions).Where(x => x.ChallengeId == challengeId)
                .Distinct().ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {//deve retornar o valor do maior score a partir do id do desafio
            return _context.Submissions.Where(x => x.ChallengeId == challengeId)
                .Max(x => x.Score);
        }

        public Submission Save(Submission submission)
        {//deve retornar uma submiss�o ap�s salvar os dados. Caso a tupla UserId e ChallengeId n�o exista, far� a inser��o da submiss�o, caso contr�rio far� a atualiza��o dos dados da submiss�o
            var exist = _context.Submissions.Find(submission.UserId, submission.ChallengeId);

            if (exist == null)
            {
                _context.Submissions.Add(submission);
            }
            else
            {
                exist.Score = submission.Score;
            }

            //persistir os dados
            _context.SaveChanges();

            return submission;
        }
    }
}
