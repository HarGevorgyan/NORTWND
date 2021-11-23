using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NORTWND.API.Middlewares;
using NORTWND.BLL.Operations;
using NORTWND.Core.Abstractions.Repositories;
using NORTWND.DAL;
using NORTWND.DAL.Repositories;
using System.Threading.Tasks;

namespace NORTWND.API

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
            services.AddDbContext<NORTHWNDContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddScoped<IOrdersBL, OrdersBL>();
            services.AddScoped<ICustomersBL, CustomersBL>();
            services.AddScoped<IProductsBL, ProductsBL>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IAuthBL,AuthBL>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => {
                options.Events.OnRedirectToLogin = (context) => { context.Response.StatusCode = 401; return Task.CompletedTask; };
                options.Events.OnRedirectToAccessDenied = (context) => { context.Response.StatusCode = 403; return Task.CompletedTask; };
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NORTWND", Version = "v1" });
            });

        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NORTWND v1"));
                
            }

            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
