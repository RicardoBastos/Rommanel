using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Reflection;
using Usuario.Domain;
using Usuario.Domain.Command;
using Usuario.Domain.Interfaces.Repository;
using Usuario.Domain.Services;
using Usuario.Infrastructure;
using Usuario.Infrastructure.Repositories;


namespace Usuario.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                 .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                 .AddJsonOptions(json => {
                     json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                     json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                 });

            services.AddDbContext<UsuarioContext>(options => options.UseInMemoryDatabase(databaseName: "Rommanel"));

            services.AddMediatR(Assembly.Load("Usuario.Domain"));

            this._ConfigureInjectionDependecy(services);
            this._ConfigureSwagger(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {

              
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rommanel API");
            });

            app.UseCors(option => option.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());


            app.UseHttpsRedirection();
            app.UseMvc();
        }





        private void _ConfigureInjectionDependecy(IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            services.AddScoped<IRequestHandler<InserirUsuarioCmd, Result>, UsuarioService>();
            services.AddScoped<IRequestHandler<AtualizarUsuarioCmd, Result>, UsuarioService>();
            services.AddScoped<IRequestHandler<ApagarUsuarioCmd, Result>, UsuarioService>();
        }

        private void _ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(s => {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Rommanel API",
                    Description = "API responsável pela integração",
                    TermsOfService = new Uri("https://rommanel.com/terms"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Rommanel",
                        Email = string.Empty,
                        Url = new Uri("http://github.com/ricardobastos")
                    }
                });


            });
        }
    }
}
