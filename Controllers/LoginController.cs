using BalanceTestingWebApi;
using BalanceTestingWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;

namespace BalanceTestingWebApi.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {

        private readonly BalanceTestingDBContext _context;

        public LoginController(BalanceTestingDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        [Authorize]
        public async Task<IActionResult> Login([FromForm] string username, [FromForm] string password)
        {
            List<Login> users = new List<Login>();
            var user = new List<Patient>();
            try
            {
                //var optionsBuilder = new DbContextOptionsBuilder<BalanceTestingDBContext>();
                //optionsBuilder.UseSqlServer(@"Server=Saad-Laptop\PHILLYDATA2022;Database=MainlineSurgicalBalanceTester;User Id=mainlinesurgery;Password=mainlinesurgery2;Encrypt=False;Pooling=False;TrustServerCertificate=True;", options => options.EnableRetryOnFailure());

                //var context = new BalanceTestingDBContext(optionsBuilder.Options);
                user = _context.patients.Where(x => x.Login== username && x.Password == password).ToList();
                // After a successful login response containing the token:
                //await SecureStorage.SetAsync("jwt_token", user.Token);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            finally
            {

            }

            return Ok(user) ;

        }
    }
}
