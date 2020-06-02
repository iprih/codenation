using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Services
{
    public class PasswordValidatorService : IResourceOwnerPasswordValidator
    {
        private readonly CodenationContext _context;
        public PasswordValidatorService(CodenationContext dbContext)
        {
            _context = dbContext;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //acessar context de user
            // var user = _context.Users.FirstOrDefault(X => X.Email == context.UserName);
            UserService userService = new UserService(_context);

            User user = userService.FindByEmail(context.UserName);

            //validar senha
            if (user != null && user.Password == context.Password)
            {
                //retornar objeto com propriedades GrantValidationResult - sub, auth e claims
                context.Result = new GrantValidationResult(
                    //subject: sempre passa o nome de usuario ou id.. algo que seja unique
                    subject: user.Id.ToString(),
                     "custom",
                     UserProfileService.GetUserClaims(user)); //aqui vai acessar a classe de validação

                return Task.CompletedTask;
            }
            // add descrição de erro de token
            context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant, "Invalid username or password");
            return Task.FromResult(context.Result);
        }
    }
}