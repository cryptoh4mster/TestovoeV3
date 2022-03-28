using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using System;
using System.IO;
using TestovoeV3.Logger;
using TestovoeV3.Mappings;
using TestovoeV3BLL.Services;
using TestovoeV3DAL.EF;
using TestovoeV3DAL.Helpers;
using TestovoeV3DAL.Interfaces;
using TestovoeV3DAL.Repositories;

namespace TestovoeV3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration.GetConnectionString("DataAccessMSSQLProvider");
            services.AddDbContext<FilesContext>(options => options.UseSqlServer(sqlConnectionString));
            services.AddAutoMapper(typeof(MappingsProfile));

           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestovoeV3", Version = "v1" });
            });
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ByteToFileResolver>();
            services.AddTransient<FileToByteResolver>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestovoeV3 v1"));
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:8081").AllowAnyMethod().AllowAnyHeader());

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
