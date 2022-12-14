using API.Data;
using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private string  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Custom extension method to hundle services
            services.AddApplicationServices(_config);

            // Custom extension method to hundle identity services
            services.AddIdentityServices(_config);

            // Add the swagger service api
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));
            }

            // Use the middleware we created to handle all excpeiton through the middleware instead of handlign exception inside each methode in the controllers
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseCors(MyAllowSpecificOrigins);
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            // Add migrations automatically from the app to create new db tables and add the new mocked data
            using var scrope = app.ApplicationServices.CreateScope();
            var services = scrope.ServiceProvider;
            try 
            {
                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();
                await Seed.SeedUsers(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migration");
            }
        }
    }
}
