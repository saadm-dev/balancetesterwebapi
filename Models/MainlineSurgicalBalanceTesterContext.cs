using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BalanceTestingWebApi.Models;

public partial class MainlineSurgicalBalanceTesterContext : DbContext
{
    public MainlineSurgicalBalanceTesterContext()
    {
    }

    public MainlineSurgicalBalanceTesterContext(DbContextOptions<MainlineSurgicalBalanceTesterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnatomyBone> AnatomyBones { get; set; }

    //public virtual DbSet<AnatomyGooglePoselandmarkerLandmarkBoneConnectGooglePoselandmarkerLandmark> AnatomyGooglePoselandmarkerLandmarkBoneConnectGooglePoselandmarkerLandmarks { get; set; }

    public virtual DbSet<AnatomyGooglePoselandmarkerLandmarkXref> AnatomyGooglePoselandmarkerLandmarkXrefs { get; set; }

    public virtual DbSet<BalanceTest> BalanceTests { get; set; }

    public virtual DbSet<BodySegment> BodySegments { get; set; }

    public virtual DbSet<BodySegmentAnatomyBoneXref> BodySegmentAnatomyBoneXrefs { get; set; }

    public virtual DbSet<CenterOfPressure> CenterOfPressures { get; set; }

    public virtual DbSet<Copmethod> Copmethods { get; set; }

    public virtual DbSet<Filter> Filters { get; set; }

    public virtual DbSet<ForcePlate> ForcePlates { get; set; }

    public virtual DbSet<ForcePlateManufacturer> ForcePlateManufacturers { get; set; }

    public virtual DbSet<ForcePlateManufacturerXref> ForcePlateManufacturerXrefs { get; set; }

    public virtual DbSet<ForcePlateSpecification> ForcePlateSpecifications { get; set; }

    public virtual DbSet<GooglePoselandmarkLandmarkRelativeMass> GooglePoselandmarkLandmarkRelativeMasses { get; set; }

    public virtual DbSet<GooglePoselandmarkLandmarkRelativeMassInvestigator> GooglePoselandmarkLandmarkRelativeMassInvestigators { get; set; }

    public virtual DbSet<GooglePoselandmarkLandmarkRelativeMassInvestigatorXref> GooglePoselandmarkLandmarkRelativeMassInvestigatorXrefs { get; set; }

    public virtual DbSet<GooglePoselandmarkerLandmark> GooglePoselandmarkerLandmarks { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<MainPage> MainPages { get; set; }

    public virtual DbSet<MedicalCondition> MedicalConditions { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientRelativeSegmentMassNotInUse> PatientRelativeSegmentMassNotInUses { get; set; }

    public virtual DbSet<Procedure> Procedures { get; set; }

    public virtual DbSet<RelativeSegmentMassbackup> RelativeSegmentMassbackups { get; set; }

    public virtual DbSet<SegmentCenterOfGravity> SegmentCenterOfGravities { get; set; }

    public virtual DbSet<SensorFusionAlgorithmLevel> SensorFusionAlgorithmLevels { get; set; }

    public virtual DbSet<SensorSpeed> SensorSpeeds { get; set; }

    public virtual DbSet<TestType> TestTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=phillydata2022.database.windows.net,1433;Initial Catalog=MainlineSurgicalCenter;User Id=mainlinesurgery;Password=surgerymainline1!;Encrypt=False;Pooling=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnatomyBone>(entity =>
        {
            entity.HasKey(e => e.BoneId).HasName("PK_Antomy_Bone");

            entity.ToTable("AnatomyBone");

            entity.Property(e => e.BoneId)
                .ValueGeneratedNever()
                .HasColumnName("BoneID");
            entity.Property(e => e.BoneDescription).HasColumnType("text");
            entity.Property(e => e.BoneName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        /*modelBuilder.Entity<AnatomyGooglePoselandmarkerLandmarkBoneConnectGooglePoselandmarkerLandmark>(entity =>
        {
            entity.ToTable("Anatomy_GooglePoselandmarkerLandmark_Bone_Connect_GooglePoselandmarkerLandmark");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.BoneId).HasColumnName("BoneID");
            entity.Property(e => e.GooglePoselandmarkerLandmark1Id).HasColumnName("GooglePoselandmarkerLandmark1ID");
            entity.Property(e => e.GooglePoselandmarkerLandmark2Id).HasColumnName("GooglePoselandmarkerLandmark2ID");
        });
        */
        modelBuilder.Entity<AnatomyGooglePoselandmarkerLandmarkXref>(entity =>
        {
            entity.HasKey(e => new { e.LandmarkId, e.BoneId });

            entity.ToTable("Anatomy_GooglePoselandmarkerLandmark_XRef");

            entity.Property(e => e.LandmarkId).HasColumnName("LandmarkID");
            entity.Property(e => e.BoneId).HasColumnName("BoneID");
        });

        modelBuilder.Entity<BalanceTest>(entity =>
        {
            entity.ToTable("BalanceTest");

            entity.Property(e => e.BalanceTestId)
                .ValueGeneratedNever()
                .HasColumnName("BalanceTestID");
            entity.Property(e => e.BalanceTestDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BalanceTestDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
        });

        modelBuilder.Entity<BodySegment>(entity =>
        {
            entity.HasKey(e => e.SegmentId);

            entity.ToTable("BodySegment");

            entity.Property(e => e.SegmentId)
                .ValueGeneratedNever()
                .HasColumnName("SegmentID");
            entity.Property(e => e.SegmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BodySegmentAnatomyBoneXref>(entity =>
        {
            entity.HasKey(e => new { e.BodySegmentId, e.AnatomyBoneId });

            entity.ToTable("BodySegment_AnatomyBone_XRef");

            entity.Property(e => e.BodySegmentId).HasColumnName("BodySegmentID");
            entity.Property(e => e.AnatomyBoneId).HasColumnName("Anatomy_Bone_ID");
        });

        modelBuilder.Entity<CenterOfPressure>(entity =>
        {
            entity.ToTable("CenterOfPressure");

            entity.Property(e => e.CenterOfPressureId)
                .ValueGeneratedNever()
                .HasColumnName("CenterOfPressureID");
            entity.Property(e => e.CopmethodId).HasColumnName("COPMethodID");
            entity.Property(e => e.TotalMoment)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Copmethod>(entity =>
        {
            entity.ToTable("COPMethod");

            entity.Property(e => e.CopmethodId)
                .ValueGeneratedNever()
                .HasColumnName("COPMethodID");
            entity.Property(e => e.CopmethodName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COPMethodName");
        });

        modelBuilder.Entity<Filter>(entity =>
        {
            entity.ToTable("Filter");

            entity.Property(e => e.FilterId)
                .ValueGeneratedNever()
                .HasColumnName("FilterID");
            entity.Property(e => e.FilterName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ForcePlate>(entity =>
        {
            entity.ToTable("ForcePlate");

            entity.Property(e => e.ForcePlateId)
                .ValueGeneratedNever()
                .HasColumnName("ForcePlateID");
            entity.Property(e => e.ForcePlateDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ForcePlateManufacturer>(entity =>
        {
            entity.ToTable("ForcePlateManufacturer");

            entity.Property(e => e.ForcePlateManufacturerId)
                .ValueGeneratedNever()
                .HasColumnName("ForcePlateManufacturerID");
            entity.Property(e => e.ForcePlateManufacturerName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ForcePlateManufacturerXref>(entity =>
        {
            entity.HasKey(e => new { e.ForcePlateId, e.ForcePlateManufacturerId }).HasName("PK_ForcePlate_Manufactrer_XRef");

            entity.ToTable("ForcePlate_Manufacturer_XRef");

            entity.Property(e => e.ForcePlateId).HasColumnName("ForcePlateID");
            entity.Property(e => e.ForcePlateManufacturerId).HasColumnName("ForcePlateManufacturerID");
        });

        modelBuilder.Entity<ForcePlateSpecification>(entity =>
        {
            entity.HasKey(e => e.ForcePlateId);

            entity.Property(e => e.ForcePlateId)
                .ValueGeneratedNever()
                .HasColumnName("ForcePlateID");
        });

        modelBuilder.Entity<GooglePoselandmarkLandmarkRelativeMass>(entity =>
        {
            entity.HasKey(e => e.LandmarkId);

            entity.ToTable("GooglePoselandmarkLandmarkRelativeMass");

            entity.Property(e => e.LandmarkId)
                .ValueGeneratedNever()
                .HasColumnName("LandmarkID");
            entity.Property(e => e.Investigator)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LandmarkDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GooglePoselandmarkLandmarkRelativeMassInvestigator>(entity =>
        {
            entity.HasKey(e => e.GooglePoselandmarkLandmarkRelativeMassInvestigatorId).HasName("PK_RelativeSegmentMassInvestigator");

            entity.ToTable("GooglePoselandmarkLandmarkRelativeMassInvestigator");

            entity.Property(e => e.GooglePoselandmarkLandmarkRelativeMassInvestigatorId)
                .ValueGeneratedNever()
                .HasColumnName("GooglePoselandmarkLandmarkRelativeMassInvestigatorID");
            entity.Property(e => e.GooglePoselandmarkLandmarkRelativeMassInvestigatorDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GooglePoselandmarkLandmarkRelativeMassInvestigatorXref>(entity =>
        {
            entity.HasKey(e => e.InvestigatorId).HasName("PK_Patient_RelativeSegmentMass_XRef");

            entity.ToTable("GooglePoselandmarkLandmarkRelativeMass_Investigator_XRef");

            entity.Property(e => e.InvestigatorId)
                .ValueGeneratedNever()
                .HasColumnName("InvestigatorID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.SegmentId).HasColumnName("SegmentID");
        });

        modelBuilder.Entity<GooglePoselandmarkerLandmark>(entity =>
        {
            entity.HasKey(e => e.LandmarkId).HasName("PK_Landmark");

            entity.ToTable("GooglePoselandmarkerLandmark");

            entity.Property(e => e.LandmarkId)
                .ValueGeneratedNever()
                .HasColumnName("LandmarkID");
            entity.Property(e => e.LandmarkDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("Login");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MainPage>(entity =>
        {
            entity.ToTable("MainPage");

            entity.Property(e => e.MainPageId)
                .ValueGeneratedNever()
                .HasColumnName("MainPageID");
            entity.Property(e => e.Filter)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("filter");
            entity.Property(e => e.SensorFusionAlgorithmLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sensorFusionAlgorithmLevel");
            entity.Property(e => e.SensorSpeed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sensorSpeed");
            entity.Property(e => e.TestType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("testType");
        });

        modelBuilder.Entity<MedicalCondition>(entity =>
        {
            entity.ToTable("MedicalCondition");

            entity.Property(e => e.MedicalConditionId)
                .ValueGeneratedNever()
                .HasColumnName("MedicalConditionID");
            entity.Property(e => e.MedicalConditionDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("PatientID");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dob)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactAddress1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactAddress2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactCity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactRelationship)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactState)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactZip)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ssn)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("SSN");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PatientRelativeSegmentMassNotInUse>(entity =>
        {
            entity.HasKey(e => e.SegmentId).HasName("PK_PatientRelativeSegmentMass");

            entity.ToTable("PatientRelativeSegmentMass_not_in_use");

            entity.Property(e => e.SegmentId)
                .ValueGeneratedNever()
                .HasColumnName("SegmentID");
            entity.Property(e => e.Investigator)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SegmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Procedure>(entity =>
        {
            entity.ToTable("Procedure");

            entity.Property(e => e.ProcedureId)
                .ValueGeneratedNever()
                .HasColumnName("ProcedureID");
            entity.Property(e => e.ProcedureDescription)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RelativeSegmentMassbackup>(entity =>
        {
            entity.HasKey(e => e.SegmentId).HasName("PK_RelativeSegmentMass");

            entity.ToTable("RelativeSegmentMassbackup");

            entity.Property(e => e.SegmentId)
                .ValueGeneratedNever()
                .HasColumnName("SegmentID");
            entity.Property(e => e.Investigator)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SegmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SegmentCenterOfGravity>(entity =>
        {
            entity.HasKey(e => e.PositionCenterOfGravityId);

            entity.ToTable("SegmentCenterOfGravity");

            entity.Property(e => e.PositionCenterOfGravityId)
                .ValueGeneratedNever()
                .HasColumnName("PositionCenterOfGravityID");
            entity.Property(e => e.SegmentId).HasColumnName("SegmentID");
            entity.Property(e => e.SegmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SensorFusionAlgorithmLevel>(entity =>
        {
            entity.ToTable("SensorFusionAlgorithmLevel");

            entity.Property(e => e.SensorFusionAlgorithmLevelId)
                .ValueGeneratedNever()
                .HasColumnName("SensorFusionAlgorithmLevelID");
            entity.Property(e => e.SensorFusionAlgorithmLevelDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SensorSpeed>(entity =>
        {
            entity.ToTable("SensorSpeed");

            entity.Property(e => e.SensorSpeedId)
                .ValueGeneratedNever()
                .HasColumnName("SensorSpeedID");
            entity.Property(e => e.SensorSpeedDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TestType>(entity =>
        {
            entity.ToTable("TestType");

            entity.Property(e => e.TestTypeId)
                .ValueGeneratedNever()
                .HasColumnName("TestTypeID");
            entity.Property(e => e.TestTypeDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
