using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private CodenationContext _context;
        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {//deve retornar uma lista de empresas a partir do id da aceleração
            return _context.Accelerations.Where(x => x.Id == accelerationId)
                .SelectMany(x => x.Candidates)
                .Select(x => x.Company)
                .Distinct()//unique
                .ToList();
        }

        public Company FindById(int id)
        {
            return _context.Companies.Find(id);
        }

        public IList<Company> FindByUserId(int userId)
        {//deve retornar uma lista de empresas a partir do id do usuário
            return _context.Candidates.Where(x => x.UserId == userId)
                .Select(x => x.Company) // pega as empresas
                .Distinct().ToList();
            
        }

        public Company Save(Company company)
        {
            var estado = company.Id == 0 ? EntityState.Added : EntityState.Modified;

                //setar estado do entity
            _context.Entry(company).State = estado;

                //persistir os dados
            _context.SaveChanges();

                //retornar o objeto
            return company;
            }
    }
}