
using AspApplicationApi.DAL;
using AspApplicationApi.DAL.interfaces;
using AspApplicationApi.DAL.Repositories;
using AspApplicationApi.Service.Emplementations;
using AspApplicationApi.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AspApplicationApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddScoped<IClientRepository, ClientRepository>();       
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            builder.Services.AddScoped<IActivityService, ActivityService>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();

            }
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
