using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Codenation.Challenge.Services;
using Codenation.Challenge;
using IdentityServer4.Validation;
using IdentityServer4.Services;
using Codenation.Challenge.Models;

namespace Source
{
    public class StartupIdentityServer
    {
        public IHostingEnvironment Environment { get; }

        public StartupIdentityServer(IHostingEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //configuração de contexto
            services.AddDbContext<CodenationContext>();
            //adicionar scoped interfaces - services - classe de validação de senha e usuário
            services.AddScoped<IResourceOwnerPasswordValidator, PasswordValidatorService>();
            services.AddScoped<IProfileService, UserProfileService>();
            //start classe identityconfig 
            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(IdentityConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityConfig.GetApis())
                .AddInMemoryClients(IdentityConfig.GetClients())
                .AddProfileService<UserProfileService>();
            //ambiente
            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("ambiente de produção precisa de chave real");
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {                        
            //app.UseStaticFiles();
            app.UseIdentityServer();            
        }
    }
}
