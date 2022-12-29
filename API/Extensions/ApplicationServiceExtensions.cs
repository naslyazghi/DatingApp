using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        private static string  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins, policy  =>
                {
                    policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                });
            });

            // configuration for Cloudinary service for uploading photo
            // This code will read the CloudinarySettings from the appsetting.json file and map them to the CloudinarySettings class to easily use those info
            // The options pattern uses classes to provide strongly typed access to groups of related settings.
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));

            // Addd services for dependency Injection
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPhotoService, PhotoService>();

            // Add services for Action filter
            // This service will automatically retrieve the username when a user logs in and update the LastActive property for that user. 
            // (Kind of a middleware but this one is an action filter that will act only on specific controller and endpoint instead of middleware that will act anytime there is a request on all controllers and endpoints)
            services.AddScoped<LogUserActivity>();

            // Add automapper service
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            return services;
        }
    }
}