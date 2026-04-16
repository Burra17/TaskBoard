using Scalar.AspNetCore;
using TaskBoard.API.Middleware;
using TaskBoard.Application;
using TaskBoard.Infrastructure;

namespace TaskBoard.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            // Add Middleware for better exeptionhandling
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
