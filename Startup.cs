using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Data;
using ProductCatalog.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace ProductCatalog
{
  public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddResponseCompression();
            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<ProductRepository, ProductRepository>();

            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Info { Title = "Catalogo de Produto", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(x => {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalogo de Produto - V1");
            });
        }
    }
}
