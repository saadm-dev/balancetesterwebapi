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

        [HttpPost("login")]
        public async Task<IActionResult> Login(
     [FromBody] LoginRequest request)
        {
            if (request == null ||
                string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new
                {
                    message = "Username and password are required."
                });
            }

            try
            {
                var patient = await _context.patients
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                        x.Login == request.Username);

                if (patient == null ||
                    patient.Password != request.Password)
                {
                    return Unauthorized(new
                    {
                        message = "Invalid username or password."
                    });
                }

                return Ok(new
                {
                    message = "Login successful"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(500, new
                {
                    message = "An internal server error occurred."
                });
            }
        }
    }
}
