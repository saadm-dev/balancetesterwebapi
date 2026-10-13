using BalanceTestingWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BalanceTestingWebApi
{
    public class BalanceTestingDBContext : DbContext
    {

        public BalanceTestingDBContext(DbContextOptions<BalanceTestingDBContext> options)
        : base(options)
        {

        }

        public BalanceTestingDBContext()
        {

        }
        public BalanceTestingDBContext(Func<object, object> value)
        {
            Value = value;
        }

        public DbSet<Login> login { get; set; }    
        public DbSet<MainPage> mainPage { get; set; }
        public DbSet<CenterOfPressure> centerOfPressure { get; set; }

        public DbSet<TestType> testTypes { get; set; }

        public DbSet<SensorSpeed> sensorSpeeds { get; set; }

        public DbSet<SensorFusionAlgorithmLevel> sensorFusionAlgorithmLevels { get; set; }

        public DbSet<Filter> filters { get; set; }

        public DbSet<Patient> patients { get; set; }

        public DbSet<ForcePlateManufacturer> forcePlateManufacturers { get; set; }

        public DbSet<ForcePlate> forcePlates { get; set; }

        public DbSet<ForcePlateManufacturerXref> forcePlateManufacturerXrefs { get; set; }
        public Func<object, object> Value { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ForcePlateManufacturerXref>()
                .HasKey(x => new
                {
                    x.ForcePlateId,
                    x.ForcePlateManufacturerId
                });

                modelBuilder.Entity<ForcePlate>()
                .ToTable("ForcePlate");   // or whatever the actual table name is

            modelBuilder.Entity<ForcePlateManufacturer>()
                .ToTable("ForcePlateManufacturer");   // or whatever the actual table name is

            modelBuilder.Entity<ForcePlateManufacturerXref>()
                .ToTable("ForcePlate_Manufacturer_XRef");   // or whatever the actual table name is
        }
    }
}
