using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Repositories;
using WebApi.Infrastructure;
using WebApi.Infrastructure.Repositories;
using WebApi.Services;

namespace WebApi;
public class Program
{
    private static void Main()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<WebApiDbContext>( options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString( "DefaultConnection" ),
                b => b.MigrationsAssembly( "WebApi.Infrastructure" ) ) );

        builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
        builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

        builder.Services.AddScoped<IReservationService, ReservationService>();

        WebApplication app = builder.Build();

        if ( app.Environment.IsDevelopment() )
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