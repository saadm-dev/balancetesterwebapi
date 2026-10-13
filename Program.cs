using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore; // Adjust the namespace as needed to where IMainService and MainService are defined
using BalanceTestingWebApi;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure JWT Authentication
/*builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
*/
builder.Services.AddDbContext<BalanceTestingDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MainLineSurgicalBalanceTestingConnection")));


// Add services to the container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();



var app = builder.Build();

// 2. Enable Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

app.MapGet("/routes", (IEnumerable<EndpointDataSource> sources) =>
{
    return sources.SelectMany(s => s.Endpoints)
                  .Select(e => e.DisplayName);
});

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

public partial class Program
{
        public static async Task Main(string[] args)
    {
        }

    public void ConfigureServices(IServiceCollection services)
    {
        //var builder = WebApplication.CreateBuilder(args);


        //builder.Services.AddDbContext<BalanceTestingDBContext>(options =>
        //options.UseSqlServer(builder.Configuration.GetConnectionString("MainLineSurgicalBalanceTestingConnection")));
    }
}