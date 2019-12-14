namespace CareerCloud.EntityFrameworkDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicant_Educations", "Applicant", c => c.Guid(nullable: false));
            AlterColumn("dbo.Applicant_Profiles", "Login", c => c.Guid(nullable: false));
            AlterColumn("dbo.Applicant_Profiles", "Country_Code", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Applicant_Job_Applications", "Applicant", c => c.Guid(nullable: false));
            AlterColumn("dbo.Applicant_Job_Applications", "Job", c => c.Guid(nullable: false));
            AlterColumn("dbo.Company_Jobs", "Company", c => c.Guid(nullable: false));
            AlterColumn("dbo.Company_Jobs_Descriptions", "Job", c => c.Guid(nullable: false));
            AlterColumn("dbo.Company_Job_Educations", "Job", c => c.Guid(nullable: false));
            AlterColumn("dbo.Company_Job_Skills", "Job", c => c.Guid(nullable: false));
            AlterColumn("dbo.Company_Descriptions", "Company", c => c.Guid(nullable: false));
            AlterColumn("dbo.Company_Descriptions", "LanguageId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Company_Locations", "Company", c => c.Guid(nullable: false));
            AlterColumn("dbo.Applicant_Resumes", "Applicant", c => c.Guid(nullable: false));
            AlterColumn("dbo.Applicant_Skills", "Applicant", c => c.Guid(nullable: false));
            AlterColumn("dbo.Applicant_Work_History", "Applicant", c => c.Guid(nullable: false));
            AlterColumn("dbo.Applicant_Work_History", "Country_Code", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Security_Logins", "LoginName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Security_Logins", "Password", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Security_Logins_Log", "Login", c => c.Guid(nullable: false));
            AlterColumn("dbo.Security_Logins_Roles", "Role", c => c.Guid(nullable: false));
            DropColumn("dbo.Company_Profiles", "Company_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company_Profiles", "Company_Name", c => c.String());
            AlterColumn("dbo.Security_Logins_Roles", "Role", c => c.Guid(nullable: false));
            AlterColumn("dbo.Security_Logins_Log", "Login", c => c.Guid(nullable: false));
            AlterColumn("dbo.Security_Logins", "Password", c => c.String());
            AlterColumn("dbo.Security_Logins", "LoginName", c => c.String());
            AlterColumn("dbo.Applicant_Work_History", "Country_Code", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Applicant_Work_History", "Applicant", c => c.Guid(nullable: false));
            AlterColumn("dbo.Applicant_Skills", "Applicant", c => c.Guid(nullable: false));
            AlterColumn("dbo.Applicant_Resumes", "Applicant", c => c.Guid(nullable: false));
            AlterColumn("dbo.Company_Locations", "Company", c => c.Guid(nullable: false));
            AlterColumn("dbo.Company_Descriptions", "LanguageId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Company_Descriptions", "Company", c => c.Guid(nullable: false));
            AlterColumn("dbo.Company_Job_Skills", "Job", c => c.Guid(nullable: false));
            AlterColumn("dbo.Company_Job_Educations", "Job", c => c.Guid(nullable: false));
            AlterColumn("dbo.Company_Jobs_Descriptions", "Job", c => c.Guid(nullable: false));
            AlterColumn("dbo.Company_Jobs", "Company", c => c.Guid(nullable: false));
            AlterColumn("dbo.Applicant_Job_Applications", "Job", c => c.Guid(nullable: false));
            AlterColumn("dbo.Applicant_Job_Applications", "Applicant", c => c.Guid(nullable: false));
            AlterColumn("dbo.Applicant_Profiles", "Country_Code", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Applicant_Profiles", "Login", c => c.Guid(nullable: false));
            AlterColumn("dbo.Applicant_Educations", "Applicant", c => c.Guid(nullable: false));
        }
    }
}
