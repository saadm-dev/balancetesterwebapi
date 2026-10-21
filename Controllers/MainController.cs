using BalanceTestingWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
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
                if (id == 0)
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

                    MainPage mainPage = _context.mainPage.Where(m => m.MainPageId == id).First();

                    if (mainPage is not null)
                    {
                        mainPageItems.Add(mainPage);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Ok(mainPageItems);
        }

            [HttpGet]
            [Route("testtypes")]
            public ActionResult<List<TestType>> GetTestTypes()
            {
                try
                {
                    var testTypes = _context.testTypes.ToList();
                    return Ok(testTypes);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(
                        $"GetTestTypes failed: {ex}");

                    return Problem(
                        title: "Failed to retrieve test types",
                        statusCode: StatusCodes.Status500InternalServerError);
                }
            }

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
                if (ex is not null)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return Ok(sensorFusionAlgorithmLevels);
        }

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
