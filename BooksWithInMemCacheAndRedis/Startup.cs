using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Books.API.Context;
using Books.API.DataServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BooksWithInMemCacheAndRedis
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

            #region SQL
            var connectionString = Configuration["ConnectionStrings:MediasDBConnectionString"];
            services.AddDbContext<BooksContext>(o => o.UseInMemoryDatabase("BooksDB"), ServiceLifetime.Singleton);
            services.AddSingleton<IBooksRepository, BooksRepository>();
            #endregion

            #region SWAGGER

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                        $"BooksOpenAPISpecification",
                        new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = "Books API",
                            Version = "v1",
                            Description = "Through this API you can access books.",
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                            {
                                Email = "lcc.omar.aceves@gmail.com",
                                Name = "Omar Aceves",
                                Url = new Uri("https://github.com/omaraceves")
                            },
                            License = new Microsoft.OpenApi.Models.OpenApiLicense()
                            {
                                Name = "MIT License",
                                Url = new Uri("https://opensource.org/licenses/MIT")
                            }
                        });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });

            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/BooksOpenAPISpecification/swagger.json",
                    "Books API");

                setupAction.RoutePrefix = "";

                setupAction.DefaultModelExpandDepth(2);
                setupAction.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
            });

            //Initialize in memory DB
            var repo = app.ApplicationServices.GetService<IBooksRepository>();
            InMemoryDBInitializer.Initialize(repo);
        }
    }
}
