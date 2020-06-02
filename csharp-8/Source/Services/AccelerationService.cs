using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private CodenationContext _context;
        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {//deve retornar uma lista de acelerações a partir do id da empresa
            return _context.Candidates.Where(x => x.CompanyId == companyId)
                .Select(x => x.Acceleration)
                .Distinct().ToList();
        }

        public Acceleration FindById(int id)
        {
            return _context.Accelerations.Find(id);
        }

        public Acceleration Save(Acceleration acceleration)
        {
            var estado = acceleration.Id == 0 ? EntityState.Added : EntityState.Modified;

            //setar estado do entity
            _context.Entry(acceleration).State = estado;

            //persistir os dados
            _context.SaveChanges();

            //retornar o objeto
            return acceleration;
        }
    }
}
