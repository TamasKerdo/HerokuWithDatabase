using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FirstSQLServerSetup.Entities;
using FirstSQLServerSetup.Repository;
using Microsoft.Extensions.Configuration;

namespace FirstSQLServerSetup
{
    public class Startup
    {
        //public static IConfigurationRoot Configuration { get; set; }

        //public Startup()
        //{
        //    var builder = new ConfigurationBuilder()
        //        .AddEnvironmentVariables();

        //    Configuration = builder.Build();
        //}
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ToDoContext>(options => options.UseNpgsql("User ID=ciolvjrqffogpm;Password=cc3d7450b3d80e35b1344f1fb81649e8ad09613b0d770526f6ce273dbe5169ba;Host=ec2-54-217-214-201.eu-west-1.compute.amazonaws.com;Port=5432;Database=d51b4807a328g9;Pooling=true;sslmode=Require;Trust Server Certificate=true;Timeout=1000;"));
            services.AddScoped<ToDoContext>();
            services.AddScoped<ToDoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }
            app.UseMvc();
        }
    }
}
