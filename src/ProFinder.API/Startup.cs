using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProFinder.API.Domain;
using ProFinder.API.Domain.Repositories;
using ProFinder.API.Infrastructure;
using ProFinder.API.Infrastructure.Data;
using ProFinder.API.Infrastructure.Repositories;

namespace ProFinder.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors();

            services.AddDbContext<ProFinderDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ICompanyTypeRepository, CompanyTypeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            
            app.UseCors(
                options => options.WithOrigins("http://localhost:3000").AllowAnyMethod()
            );
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
