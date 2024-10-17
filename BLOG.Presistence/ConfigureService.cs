using BLOG.Presistence.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BLOG.Domain.Repositories;
using BLOG.Presistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;



namespace BLOG.Presistence
{
    public static class ConfigureService
    {
        public static IServiceCollection AddPresistenceService(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddDbContext<BlogDbContext>(options =>
            options.UseSqlServer(configuration["ConnectionStrings:ctr"]));
             services.AddScoped<IBlogRepository, BlogRepository>();


             services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // default name 
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // default route
    // if route wrong -----> UNAUTHORIZED
}
).AddJwtBearer(option =>
{
    option.SaveToken = true;
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer =configuration["JWT:Issuer"],
        ValidAudience =configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
    };
});
            return services;
             
        }
    }
}
