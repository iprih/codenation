using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private CodenationContext _context;
        
        public UserService(CodenationContext context)
        {
            _context = context;
        }
        
        public IList<User> FindByAccelerationName(string name)
        {//deve retornar uma lista de usuários a partir do nome da aceleração
            return _context.Accelerations.Where(x => x.Name == name)
                .SelectMany(x => x.Candidates)
                .Select(x => x.User)
                .Distinct().ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {//deve retornar uma lista de usuários a relacionado com a empresa pelo id da empresa

            return _context.Companies.Where(x => x.Id == companyId)
                .SelectMany(x => x.Candidates)
                .Select(x => x.User)
                .Distinct().ToList();
        }

        public User FindById(int id)
        {
            return _context.Users.Find(id);
        }

        public User Save(User user)
        {
            var estado = user.Id == 0 ? EntityState.Added : EntityState.Modified;

            //setar estado do entity
            _context.Entry(user).State = estado;

            //persistir os dados
            _context.SaveChanges();

            //retornar o objeto
            return user;

        }
    }
}
