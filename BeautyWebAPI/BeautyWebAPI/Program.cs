
using BeautyWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            var connectionstring = builder.Configuration.GetConnectionString("Default") ??
                throw new NullReferenceException("No connection string in Conbgig!");
            
            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContextFactory<BeautyStudioDbContext>((DbContextOptionsBuilder options)=> options.UseSqlServer(connectionstring));

            WebApplication app = builder.Build();
           // await UpdateDatabase(app);

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
            //app.RunAsync();  //?????
        }

        //private static async Task UpdateDatabase(IHost app)
        //{
        //    using IServiceScope serviceScope = app.Services.CreateScope();
        //    await using DataContext context = serviceScope.ServiceProvider.GetService<DataContext>()!;
        //    await context.Initialize();
        //}
    }
}