using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;

namespace Codenation.Challenge.Services
{
    public class UserProfileService : IProfileService
    {

        private readonly CodenationContext _context;
        public UserProfileService(CodenationContext dbContext)
        {
            _context = dbContext;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //JWT - Validated TokenRequest - parse
            var request = context.ValidatedRequest as ValidatedTokenRequest;
            //verifica se o token é nullo
            if (request != null)
            {
                //procurar na base as respectivas informações de acordo com o Email
                User user = _context.Users.FirstOrDefault(x => x.Email == request.UserName);
              // context.AddRequestedClaims(GetUserClaims(user))
                var claims = GetUserClaims(user);
                context.IssuedClaims = claims
                    .Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList(); 
            }                
                return Task.CompletedTask;                      
        }

        //task é uma resposta requisição assyncrona - ou seja nao vai esperar retornar uma resposta pra continuar o codigo(metodo assyncrono)
        public Task IsActiveAsync(IsActiveContext context) // esse metodo devolve se está ativo ou nao
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }


        //metodo que retorna lista de claims lá no Task | 
        public static Claim[] GetUserClaims(User user)
        {
            string role = "User";

            if (user.Email == "tegglestone9@blog.com")
            {
                role = "Admin";
            }
            return new []
            {
               // new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email), 
                new Claim(ClaimTypes.Role, role)
            };
        }

    }
}