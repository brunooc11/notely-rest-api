using Microsoft.Extensions.DependencyInjection;
using NotelyRestApi.Database;
using Microsoft.EntityFrameworkCore;
using NotelyRestApi.Repositories;
using NotelyRestApi.Repositories.Implementations;
using Microsoft.OpenApi.Models;


namespace NotelyRestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. ( verificar no bitbucket)

            var services = builder.Services;

            builder.Services.AddDbContext<NotelyDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddTransient<INoteRepository, NoteRepository>();

            builder.Services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notely Rest API", Version = "v1" });
            });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notely Rest API");
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.MapGet("/", () => Results.Redirect("api/note")); // gg apaguei tudo do bitbucekt

            app.Run();
        }
    }
}
