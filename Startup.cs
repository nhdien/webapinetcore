using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPINetCore.Helpers;
using WebAPINetCore.Middlewares;
using WebAPINetCore.ModelContexts;
using WebAPINetCore.Services;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System.Text.Json;

namespace WebAPINetCore
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
            services.AddDbContext<AuthContext>();
            services.AddCors();

            services.AddControllers()
                .AddJsonOptions(x => {
                    x.JsonSerializerOptions.IgnoreNullValues = true;
                    x.JsonSerializerOptions.PropertyNamingPolicy = null;
                });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c => c
                .AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http
                }));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSingleton(Configuration);

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IHanhchinhService, HanhchinhService>();
            services.AddTransient<IDantocService, DantocService>();
            services.AddTransient<ITongiaoService, TongiaoService>();
            services.AddTransient<IQuanheService, QuanheService>();
            services.AddTransient<IHocvanService, HocvanService>();
            services.AddTransient<IDanhhieuService, DanhhieuService>();
            services.AddTransient<ICapbacService, CapbacService>();
            services.AddTransient<ILoaibangkhenService, LoaibangkhenService>();
            services.AddTransient<IHuanhuychuongService, HuanhuychuongService>();
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x => x
                .SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NET Core Sign-up and Verification API"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
