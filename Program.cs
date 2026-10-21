using BalanceTestingWebApi;
using Microsoft.EntityFrameworkCore;

public partial class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<BalanceTestingDBContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString(
                    "MainLineSurgicalBalanceTestingConnection")));

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.MapGet("/", () => Results.Ok(new
        {
            status = "Running",
            application = "BalanceTestingWebApi"
        }));

        app.Run();
    }
}