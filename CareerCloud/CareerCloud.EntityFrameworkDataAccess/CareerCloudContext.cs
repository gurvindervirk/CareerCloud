using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public CareerCloudContext() {
        }
         public CareerCloudContext(bool createProxy=true ): base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
        {
            Database.Log = s=> System.Diagnostics.Debug.WriteLine(1);
            Configuration.ProxyCreationEnabled = createProxy;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicantEducationPoco>()
                .Property(a => a.TimeStamp).IsRowVersion();
            modelBuilder.Entity<ApplicantJobApplicationPoco>()
               .Property(a => a.TimeStamp).IsRowVersion();
            modelBuilder.Entity<ApplicantProfilePoco>()
               .Property(a => a.TimeStamp).IsRowVersion();
            modelBuilder.Entity<ApplicantSkillPoco>()
               .Property(a => a.TimeStamp).IsRowVersion();
            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
               .Property(a => a.TimeStamp).IsRowVersion();
            modelBuilder.Entity<CompanyDescriptionPoco>()
               .Property(a => a.TimeStamp).IsRowVersion();
            modelBuilder.Entity<CompanyJobEducationPoco>()
               .Property(a => a.TimeStamp).IsRowVersion();
            modelBuilder.Entity<CompanyJobSkillPoco>()
               .Property(a => a.TimeStamp).IsRowVersion();
            modelBuilder.Entity<CompanyJobDescriptionPoco>()
               .Property(a => a.TimeStamp).IsRowVersion();
            modelBuilder.Entity<CompanyProfilePoco>()
               .Property(a => a.TimeStamp).IsRowVersion();
            modelBuilder.Entity<SecurityLoginPoco>()
               .Property(a => a.TimeStamp).IsRowVersion();
            modelBuilder.Entity<SecurityLoginsRolePoco>()
               .Property(a => a.TimeStamp).IsRowVersion();
            modelBuilder.Entity<CompanyJobPoco>()
               .Property(a => a.TimeStamp).IsRowVersion();
            modelBuilder.Entity<CompanyLocationPoco>()
              .Property(a => a.TimeStamp).IsRowVersion();

            modelBuilder.Entity<CompanyDescriptionPoco>()
             .HasRequired<CompanyProfilePoco>(s => s.CompanyProfiles)
             .WithMany(g => g.CompanyDescriptions)
             .HasForeignKey<Guid>(s => s.Company);

            modelBuilder.Entity<CompanyJobPoco>()
             .HasRequired<CompanyProfilePoco>(s => s.CompanyProfiles)
             .WithMany(g => g.CompanyJobs)
             .HasForeignKey<Guid>(s => s.Company);

            modelBuilder.Entity<CompanyLocationPoco>()
            .HasRequired<CompanyProfilePoco>(s => s.CompanyProfiles)
            .WithMany(g => g.CompanyLocations)
            .HasForeignKey<Guid>(s => s.Company);

            modelBuilder.Entity<CompanyJobDescriptionPoco>()
           .HasRequired<CompanyJobPoco>(s => s.CompanyJobs)
           .WithMany(g => g.CompanyJobDescriptions)
           .HasForeignKey<Guid>(s => s.Job);

            modelBuilder.Entity<CompanyJobEducationPoco>()
           .HasRequired<CompanyJobPoco>(s => s.CompanyJobs)
           .WithMany(g => g.CompanyJobEducations)
           .HasForeignKey<Guid>(s => s.Job);

            modelBuilder.Entity<CompanyJobSkillPoco>()
          .HasRequired<CompanyJobPoco>(s => s.CompanyJobs)
          .WithMany(g => g.CompanyJobSkills)
          .HasForeignKey<Guid>(s => s.Job);

          modelBuilder.Entity<SecurityLoginsLogPoco>()
         .HasRequired<SecurityLoginPoco>(s => s.SecurityLogin)
         .WithMany(g => g.SecurityLoginsLogs)
         .HasForeignKey<Guid>(s => s.Login);

            modelBuilder.Entity<SecurityLoginsRolePoco>()
         .HasRequired<SecurityRolePoco>(s => s.SecurityRole)
         .WithMany(g => g.SecurityLoginsRoles)
         .HasForeignKey<Guid>(s => s.Role);

            modelBuilder.Entity<SecurityLoginsRolePoco>()
           .HasRequired<SecurityLoginPoco>(s => s.SecurityLogin)
           .WithMany(g => g.SecurityLoginsRoles)
           .HasForeignKey<Guid>(s => s.Role);

           modelBuilder.Entity<ApplicantProfilePoco>()
          .HasRequired<SystemCountryCodePoco>(s => s.SystemCountryCodes)
          .WithMany(g => g.ApplicantProfiles)
          .HasForeignKey<string>(s => s.Country);

          modelBuilder.Entity<ApplicantProfilePoco>()
         .HasRequired<SecurityLoginPoco>(s => s.SecurityLogin)
         .WithMany(g => g.ApplicantProfiles)
         .HasForeignKey<Guid>(s => s.Login);

         modelBuilder.Entity<ApplicantEducationPoco>()
        .HasRequired<ApplicantProfilePoco>(s => s.ApplicantProfiles)
        .WithMany(g => g.ApplicantEducations)
        .HasForeignKey<Guid>(s => s.Applicant);

            modelBuilder.Entity<ApplicantJobApplicationPoco>()
           .HasRequired<ApplicantProfilePoco>(s => s.ApplicantProfiles)
           .WithMany(g => g.ApplicantJobApplications)
           .HasForeignKey<Guid>(s => s.Applicant);

           modelBuilder.Entity<ApplicantResumePoco>()
          .HasRequired<ApplicantProfilePoco>(s => s.ApplicantProfiles)
          .WithMany(g => g.ApplicantResumes)
          .HasForeignKey<Guid>(s => s.Applicant);

            modelBuilder.Entity<ApplicantSkillPoco>()
          .HasRequired<ApplicantProfilePoco>(s => s.ApplicantProfiles)
          .WithMany(g => g.ApplicantSkills)
          .HasForeignKey<Guid>(s => s.Applicant);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
          .HasRequired<ApplicantProfilePoco>(s => s.ApplicantProfiles)
          .WithMany(g => g.ApplicantWorkHistories)
          .HasForeignKey<Guid>(s => s.Applicant);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
         .HasRequired<SystemCountryCodePoco>(s => s.SystemCountryCodes)
         .WithMany(g => g.ApplicantWorkHistories)
         .HasForeignKey<string>(s => s.CountryCode)
         .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantJobApplicationPoco>()
         .HasRequired<CompanyJobPoco>(s => s.CompanyJobs)
         .WithMany(g => g.ApplicantJobApplications)
         .HasForeignKey<Guid>(s => s.Job);
        }
        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }

        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

    }
}
