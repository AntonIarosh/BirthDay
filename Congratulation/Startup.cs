using CongratulationAPI.AppServices.Services;
using CongratulationAPI.DataAccess;
using CongratulationAPI.Domain.Validation;
using CongratulationAPI.Infrastructure.Repository;
using CongratulationAPI.Infrastructure.Repositoryes.BirthDayRepository;
using CongratulationAPI.Infrastructure.Repositoryes.CongratulationRepository;
using CongratulationAPI.Infrastructure.Repositoryes.KnowRepository;
using CongratulationAPI.Infrastructure.Repositoryes.UserRepository;
using CongratulationAPI.Mapper.Mapping;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CongratulationAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddTransient<IBirthDayValidation, BirthDayValidation>();
            services.AddCors();
            services.AddDbContext<BaseDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("ApplicationConnection")));
            services.AddScoped<DbContext>(service=>service.GetRequiredService<BaseDbContext>());
            services.AddControllers();
            services.AddMvc().AddFluentValidation();
            services.AddAutoMapper(typeof(ApplicationMapperProfile));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IKnowRepository), typeof(KnowRepository));
            services.AddScoped(typeof(IBirthDayRepository), typeof(BirthDayRepository));
            services.AddScoped(typeof(ICongratulationRepository), typeof(CongratulationRepository));

            /* services.AddTransient<IUserRepository, UserRepository>();
             services.AddTransient<IBirthDayRepository, BirthDayRepository>();
             services.AddTransient<IKnowRepository, KnowRepository>();
             services.AddTransient<ICongratulationRepository, CongratulationRepository>();*/

            services.AddTransient<IBirthDayService, BirthDayService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IKnowService, KnowService>();
            services.AddTransient<ICongratulationService, CongratulationService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Congratulation", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Congratulation v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true) // allow any origin
              .AllowCredentials()); // allow credentials

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
