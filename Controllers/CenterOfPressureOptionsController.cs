using BalanceTestingWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BalanceTestingWebApi.Controllers
{
    [ApiController]
    [Route("api/cop")]
    public class CenterOfPresureOptionsController : Controller
    {

        private readonly BalanceTestingDBContext _context;

        public CenterOfPresureOptionsController( BalanceTestingDBContext context)
        {
            _context = context;
        }

        

        [HttpGet]
        [Route("forceplatemanufacturers")]
        public ActionResult<List<TestType>> GetForcePlateManufacturers()
        {
            List<ForcePlateManufacturer> forcePlateManufacturers = new List<ForcePlateManufacturer>();

            //var optionsBuilder = new DbContextOptionsBuilder<BalanceTestingDBContext>();
            //optionsBuilder.UseSqlServer("Server=Saad-Laptop\\PHILLYDATA2022;Database=MainlineSurgicalBalanceTester;User Id=mainlinesurgery;Password=mainlinesurgery2;Encrypt=False;Pooling=False;TrustServerCertificate=False;", options => options.EnableRetryOnFailure());


            //var context = new BalanceTestingDBContext(optionsBuilder.Options);

            try
            {

                var dbName = _context.Database.GetDbConnection().Database;
                var server = _context.Database.GetDbConnection().DataSource;

                Console.WriteLine($"DB: {dbName}");
                Console.WriteLine($"Server: {server}");

                forcePlateManufacturers = _context.forcePlateManufacturers.ToList();
            
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(forcePlateManufacturers);
        }

        [HttpGet]
        [Route("forceplates/{forceplatemanufacturerid}")]
        public ActionResult<List<ForcePlate>> GetForcePlates(int forceplatemanufacturerid)
        {
            List<ForcePlate> forcePlates = new List<ForcePlate>();

            //var optionsBuilder = new DbContextOptionsBuilder<BalanceTestingDBContext>();
            //optionsBuilder.UseSqlServer(@"Server=Saad-Laptop\\PHILLYDATA2022;Database=MainlineSurgicalBalanceTester;User Id=mainlinesurgery;Password=mainlinesurgery2;Encrypt=False;Pooling=False;TrustServerCertificate=False;", options => options.EnableRetryOnFailure());

            //var context = new BalanceTestingDBContext(optionsBuilder.Options);
            try
            {

                var query = _context.forcePlates.Join(_context.forcePlateManufacturerXrefs, 
                                                    forcePlate => forcePlate.ForcePlateId, forcePlateManufacturerXRef => forcePlateManufacturerXRef.ForcePlateId, 
                                                    (forcePlate, forcePlateManufacturerXref) => new { forcePlateName = forcePlate.ForcePlateDescription, forcePlateId = forcePlate.ForcePlateId, forcePlateManufacturerXref = forcePlateManufacturerXref.ForcePlateManufacturerId }).Join(_context.forcePlateManufacturers, combined => combined.forcePlateManufacturerXref, loc => loc.ForcePlateManufacturerId, (combined, loc) => new { ForcePlateId = combined.forcePlateId, ForcePlateName = combined.forcePlateName });
                forcePlates = query.Select(x => new ForcePlate { ForcePlateId = x.ForcePlateId, ForcePlateDescription = x.ForcePlateName }).ToList();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Ok(forcePlates);
        }

        
    }
}
