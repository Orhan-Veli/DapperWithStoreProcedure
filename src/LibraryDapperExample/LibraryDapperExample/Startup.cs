using LibraryDapperExample.Business.Abstract;
using LibraryDapperExample.Business.Concrete;
using LibraryDapperExample.Dal.Dapper.Abstract;
using LibraryDapperExample.Dal.Dapper.Concrete;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Handlers.Command;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Handlers.Query;
using LibraryDapperExample.Dal.Entity;
using LibraryDapperExample.Model;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample
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
            services.AddControllers();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<CreateBookCommandHandler>();
            services.AddTransient<GetAllBookQueryHandler>();
            services.AddSingleton<IBookService, BookService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
