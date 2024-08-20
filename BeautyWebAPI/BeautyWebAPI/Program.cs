
using BeautyWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionstring = builder.Configuration.GetConnectionString("Default") ??
                throw new NullReferenceException("No connection string in Conbgig!");
            
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContextFactory<BeautyStudioDbContext>((DbContextOptionsBuilder options)=> options.UseSqlServer(connectionstring));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}