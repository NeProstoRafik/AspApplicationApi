using AspApplication.Application.Contracts;
using AspApplication.Application.Implementations;
using AspApplication.Application.Interfaces;
using AspApplication.Application.Validators;
using AspApplication.DataAccess;
using AspApplication.DataAccess.interfaces;
using AspApplication.DataAccess.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace AspApplicationApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
        builder.Services.AddScoped<IApplicationService, ApplicationService>();
        builder.Services.AddScoped<IActivityService, ActivityService>();

        builder.Services.AddScoped<IValidator<ApplicationDTO>, ApplicationCreateValidator>();
        builder.Services.AddScoped<IValidator<ApplicationDTOUpdate>, ApplicationUpdateValidator>();
        builder.Services.AddScoped<IValidator<AspApplication.Domain.Entity.Application>, ApplicationSubmitValidator>();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            db.Database.Migrate();
        }

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
