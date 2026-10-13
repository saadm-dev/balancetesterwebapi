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
    [Route("api/main")]
    public class MainController : Controller
    {

        private readonly BalanceTestingDBContext _context;

        public MainController( BalanceTestingDBContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("maindetails/{id}")]
        public ActionResult<List<MainPage>> GetMainDetails(int id)
        {
            List <MainPage> mainPageItems = new List<MainPage>();

            long maxId = 0;

            //var optionsBuilder = new DbContextOptionsBuilder<BalanceTestingDBContext>();
            //optionsBuilder.UseSqlServer(@"Server=Saad-Laptop\PHILLYDATA2022;Database=MainlineSurgicalBalanceTester;User Id=mainlinesurgery;Password=mainlinesurgery2;Encrypt=False;Pooling=False;TrustServerCertificate=False;", options => options.EnableRetryOnFailure());

           // var context = new BalanceTestingDBContext(optionsBuilder.Options);
            
            try
            {
                if (id== 0)
                {
                    MainPage mainPage = new MainPage();

                    var query = _context.mainPage.Where(x => x.MainPageId == id);

                    if (query.Any())
                    {
                        maxId = _context.mainPage.Max(m => m.MainPageId);

                    }
                    else
                    {
                        maxId = 1;
                    }

                    mainPage.MainPageId = maxId;
                    mainPage.Weight = 0.0F;
                    mainPage.SensorSpeed = "Normal";
                    mainPage.SensorFusionAlgorithmLevel = "Low-level Fusion";
                    mainPage.Filter = "Kalman Filter";
                    mainPage.TestType = "Feet Together - EC | Right";
                    mainPageItems.Add(mainPage);
                }

                else
                {

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    MainPage mainPage = _context.mainPage.Where(m => m.MainPageId == id).FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    mainPageItems.Add(mainPage);
                    }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Ok(mainPageItems);
        }

        [Authorize]
        [HttpGet]
        [Route("testtypes")]
        public ActionResult<List<TestType>> GetTestTypes()
        {
            List<TestType> testTypes = new List<TestType>();

            //var optionsBuilder = new DbContextOptionsBuilder<BalanceTestingDBContext>();
            //optionsBuilder.UseSqlServer("Server=Saad-Laptop\\PHILLYDATA2022;Database=MainlineSurgicalBalanceTester;User Id=mainlinesurgery;Password=mainlinesurgery2;Encrypt=False;Pooling=False;TrustServerCertificate=False;", options => options.EnableRetryOnFailure());


            //var context = new BalanceTestingDBContext(optionsBuilder.Options);

            try
            {

                var dbName = _context.Database.GetDbConnection().Database;
                var server = _context.Database.GetDbConnection().DataSource;

                Console.WriteLine($"DB: {dbName}");
                Console.WriteLine($"Server: {server}");

                testTypes = _context.testTypes.ToList();
            
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(testTypes);
        }

        [Authorize]
        [HttpGet]
        [Route("sensorspeeds")]
        public ActionResult<List<SensorSpeed>> GetSensorSpeeds()
        {
            List<SensorSpeed> sensorSpeeds= new List<SensorSpeed>();

            //var optionsBuilder = new DbContextOptionsBuilder<BalanceTestingDBContext>();
            //optionsBuilder.UseSqlServer(@"Server=Saad-Laptop\\PHILLYDATA2022;Database=MainlineSurgicalBalanceTester;User Id=mainlinesurgery;Password=mainlinesurgery2;Encrypt=False;Pooling=False;TrustServerCertificate=False;", options => options.EnableRetryOnFailure());

            //var context = new BalanceTestingDBContext(optionsBuilder.Options);
            try
            {

                sensorSpeeds = _context.sensorSpeeds.ToList();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Ok(sensorSpeeds);
        }

        [Authorize]
        [HttpGet]
        [Route("sensorfusionalgorithms")]
        public ActionResult<List<SensorFusionAlgorithmLevel>> GetSensorFusionAlgorithms()
        {
            List<SensorFusionAlgorithmLevel> sensorFusionAlgorithmLevels= new List<SensorFusionAlgorithmLevel>();

            //var optionsBuilder = new DbContextOptionsBuilder<BalanceTestingDBContext>();
            //optionsBuilder.UseSqlServer(@"Server=Saad-Laptop\\PHILLYDATA2022;Database=MainlineSurgicalBalanceTester;User Id=mainlinesurgery;Password=mainlinesurgery2;Encrypt=False;Pooling=False;TrustServerCertificate=False;", options => options.EnableRetryOnFailure());

            try {
                //var context = new BalanceTestingDBContext(optionsBuilder.Options);

                sensorFusionAlgorithmLevels= _context.sensorFusionAlgorithmLevels.ToList() ;
                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            }

            return Ok(sensorFusionAlgorithmLevels);
        }

        [Authorize]
        [HttpGet]
        [Route("filters")]
        public ActionResult<List<Filter>> GetFilters()
        {
            List<Filter> filters= new List<Filter>();

            //var optionsBuilder = new DbContextOptionsBuilder<BalanceTestingDBContext>();
            //optionsBuilder.UseSqlServer(@"Server=Saad-Laptop\\PHILLYDATA2022;Database=MainlineSurgicalBalanceTester;User Id=mainlinesurgery;Password=mainlinesurgery2;Encrypt=False;Pooling=False;TrustServerCertificate=False;", options => options.EnableRetryOnFailure());

            //var context = new BalanceTestingDBContext();

            try
            {

                filters= _context.filters.ToList();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Ok(filters);
        }

    }
}
