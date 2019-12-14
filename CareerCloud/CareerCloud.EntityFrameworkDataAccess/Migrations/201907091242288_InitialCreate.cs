namespace CareerCloud.EntityFrameworkDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicant_Educations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Applicant = c.Guid(nullable: false),
                        Major = c.String(),
                        Certificate_Diploma = c.String(),
                        Start_Date = c.DateTime(),
                        Completion_Date = c.DateTime(),
                        Completion_Percent = c.Byte(),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicant_Profiles", t => t.Applicant, cascadeDelete: true)
                .Index(t => t.Applicant);
            
            CreateTable(
                "dbo.Applicant_Profiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.Guid(nullable: false),
                        Current_Salary = c.Decimal(precision: 18, scale: 2),
                        Current_Rate = c.Decimal(precision: 18, scale: 2),
                        Currency = c.String(),
                        Country_Code = c.String(nullable: false, maxLength: 128),
                        State_Province_Code = c.String(),
                        Street_Address = c.String(),
                        City_Town = c.String(),
                        Zip_Postal_Code = c.String(),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Security_Logins", t => t.Login, cascadeDelete: true)
                .ForeignKey("dbo.System_Country_Codes", t => t.Country_Code, cascadeDelete: true)
                .Index(t => t.Login)
                .Index(t => t.Country_Code);
            
            CreateTable(
                "dbo.Applicant_Job_Applications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Applicant = c.Guid(nullable: false),
                        Job = c.Guid(nullable: false),
                        Application_Date = c.DateTime(nullable: false),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicant_Profiles", t => t.Applicant, cascadeDelete: true)
                .ForeignKey("dbo.Company_Jobs", t => t.Job, cascadeDelete: true)
                .Index(t => t.Applicant)
                .Index(t => t.Job);
            
            CreateTable(
                "dbo.Company_Jobs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Company = c.Guid(nullable: false),
                        Profile_Created = c.DateTime(nullable: false),
                        Is_Inactive = c.Boolean(nullable: false),
                        Is_Company_Hidden = c.Boolean(nullable: false),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company_Profiles", t => t.Company, cascadeDelete: true)
                .Index(t => t.Company);
            
            CreateTable(
                "dbo.Company_Jobs_Descriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Job = c.Guid(nullable: false),
                        Job_Name = c.String(),
                        Job_Descriptions = c.String(),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company_Jobs", t => t.Job, cascadeDelete: true)
                .Index(t => t.Job);
            
            CreateTable(
                "dbo.Company_Job_Educations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Job = c.Guid(nullable: false),
                        Major = c.String(),
                        Importance = c.Short(nullable: false),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company_Jobs", t => t.Job, cascadeDelete: true)
                .Index(t => t.Job);
            
            CreateTable(
                "dbo.Company_Job_Skills",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Job = c.Guid(nullable: false),
                        Skill = c.String(),
                        Skill_Level = c.String(),
                        Importance = c.Int(nullable: false),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company_Jobs", t => t.Job, cascadeDelete: true)
                .Index(t => t.Job);
            
            CreateTable(
                "dbo.Company_Profiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Registration_Date = c.DateTime(nullable: false),
                        Company_Website = c.String(),
                        Company_Name = c.String(),
                        Contact_Phone = c.String(),
                        Contact_Name = c.String(),
                        Company_Logo = c.Binary(),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Company_Descriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Company = c.Guid(nullable: false),
                        LanguageId = c.String(maxLength: 128),
                        Company_Name = c.String(),
                        Company_Description = c.String(),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company_Profiles", t => t.Company, cascadeDelete: true)
                .ForeignKey("dbo.System_Language_Codes", t => t.LanguageId)
                .Index(t => t.Company)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.System_Language_Codes",
                c => new
                    {
                        LanguageID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Native_Name = c.String(),
                    })
                .PrimaryKey(t => t.LanguageID);
            
            CreateTable(
                "dbo.Company_Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Company = c.Guid(nullable: false),
                        Country_Code = c.String(),
                        State_Province_Code = c.String(),
                        Street_Address = c.String(),
                        City_Town = c.String(),
                        Zip_Postal_Code = c.String(),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company_Profiles", t => t.Company, cascadeDelete: true)
                .Index(t => t.Company);
            
            CreateTable(
                "dbo.Applicant_Resumes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Applicant = c.Guid(nullable: false),
                        Resume = c.String(),
                        Last_Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicant_Profiles", t => t.Applicant, cascadeDelete: true)
                .Index(t => t.Applicant);
            
            CreateTable(
                "dbo.Applicant_Skills",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Applicant = c.Guid(nullable: false),
                        Skill = c.String(),
                        Skill_Level = c.String(),
                        Start_Month = c.Byte(nullable: false),
                        Start_Year = c.Int(nullable: false),
                        End_Month = c.Byte(nullable: false),
                        End_Year = c.Int(nullable: false),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicant_Profiles", t => t.Applicant, cascadeDelete: true)
                .Index(t => t.Applicant);
            
            CreateTable(
                "dbo.Applicant_Work_History",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Applicant = c.Guid(nullable: false),
                        Company_Name = c.String(),
                        Country_Code = c.String(nullable: false, maxLength: 128),
                        Location = c.String(),
                        Job_Title = c.String(),
                        Job_Description = c.String(),
                        Start_Month = c.Short(nullable: false),
                        Start_Year = c.Int(nullable: false),
                        End_Month = c.Short(nullable: false),
                        End_Year = c.Int(nullable: false),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicant_Profiles", t => t.Applicant, cascadeDelete: true)
                .ForeignKey("dbo.System_Country_Codes", t => t.Country_Code)
                .Index(t => t.Applicant)
                .Index(t => t.Country_Code);
            
            CreateTable(
                "dbo.System_Country_Codes",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Security_Logins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoginName = c.String(),
                        Password = c.String(),
                        Created_Date = c.DateTime(nullable: false),
                        Password_Update_Date = c.DateTime(),
                        Agreement_Accepted_Date = c.DateTime(),
                        Is_Locked = c.Boolean(nullable: false),
                        Is_Inactive = c.Boolean(nullable: false),
                        Email_Address = c.String(),
                        Phone_Number = c.String(),
                        Full_Name = c.String(),
                        Force_Change_Password = c.Boolean(nullable: false),
                        Prefferred_Language = c.String(),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Security_Logins_Log",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.Guid(nullable: false),
                        Source_IP = c.String(),
                        Logon_Date = c.DateTime(nullable: false),
                        Is_Succesful = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Security_Logins", t => t.Login, cascadeDelete: true)
                .Index(t => t.Login);
            
            CreateTable(
                "dbo.Security_Logins_Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.Guid(nullable: false),
                        Role = c.Guid(nullable: false),
                        Time_Stamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Security_Logins", t => t.Role, cascadeDelete: true)
                .ForeignKey("dbo.Security_Roles", t => t.Role, cascadeDelete: true)
                .Index(t => t.Role)
                .Index(t => t.Role);
            
            CreateTable(
                "dbo.Security_Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Role = c.String(),
                        Is_Inactive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applicant_Educations", "Applicant", "dbo.Applicant_Profiles");
            DropForeignKey("dbo.Applicant_Profiles", "Country_Code", "dbo.System_Country_Codes");
            DropForeignKey("dbo.Applicant_Profiles", "Login", "dbo.Security_Logins");
            DropForeignKey("dbo.Security_Logins_Roles", "Role", "dbo.Security_Roles");
            DropForeignKey("dbo.Security_Logins_Roles", "Role", "dbo.Security_Logins");
            DropForeignKey("dbo.Security_Logins_Log", "Login", "dbo.Security_Logins");
            DropForeignKey("dbo.Applicant_Work_History", "Country_Code", "dbo.System_Country_Codes");
            DropForeignKey("dbo.Applicant_Work_History", "Applicant", "dbo.Applicant_Profiles");
            DropForeignKey("dbo.Applicant_Skills", "Applicant", "dbo.Applicant_Profiles");
            DropForeignKey("dbo.Applicant_Resumes", "Applicant", "dbo.Applicant_Profiles");
            DropForeignKey("dbo.Applicant_Job_Applications", "Job", "dbo.Company_Jobs");
            DropForeignKey("dbo.Company_Jobs", "Company", "dbo.Company_Profiles");
            DropForeignKey("dbo.Company_Locations", "Company", "dbo.Company_Profiles");
            DropForeignKey("dbo.Company_Descriptions", "LanguageId", "dbo.System_Language_Codes");
            DropForeignKey("dbo.Company_Descriptions", "Company", "dbo.Company_Profiles");
            DropForeignKey("dbo.Company_Job_Skills", "Job", "dbo.Company_Jobs");
            DropForeignKey("dbo.Company_Job_Educations", "Job", "dbo.Company_Jobs");
            DropForeignKey("dbo.Company_Jobs_Descriptions", "Job", "dbo.Company_Jobs");
            DropForeignKey("dbo.Applicant_Job_Applications", "Applicant", "dbo.Applicant_Profiles");
            DropIndex("dbo.Applicant_Educations", new[] { "Applicant" });
            DropIndex("dbo.Applicant_Profiles", new[] { "Country_Code" });
            DropIndex("dbo.Applicant_Profiles", new[] { "Login" });
            DropIndex("dbo.Security_Logins_Roles", new[] { "Role" });
            DropIndex("dbo.Security_Logins_Roles", new[] { "Role" });
            DropIndex("dbo.Security_Logins_Log", new[] { "Login" });
            DropIndex("dbo.Applicant_Work_History", new[] { "Country_Code" });
            DropIndex("dbo.Applicant_Work_History", new[] { "Applicant" });
            DropIndex("dbo.Applicant_Skills", new[] { "Applicant" });
            DropIndex("dbo.Applicant_Resumes", new[] { "Applicant" });
            DropIndex("dbo.Applicant_Job_Applications", new[] { "Job" });
            DropIndex("dbo.Company_Jobs", new[] { "Company" });
            DropIndex("dbo.Company_Locations", new[] { "Company" });
            DropIndex("dbo.Company_Descriptions", new[] { "LanguageId" });
            DropIndex("dbo.Company_Descriptions", new[] { "Company" });
            DropIndex("dbo.Company_Job_Skills", new[] { "Job" });
            DropIndex("dbo.Company_Job_Educations", new[] { "Job" });
            DropIndex("dbo.Company_Jobs_Descriptions", new[] { "Job" });
            DropIndex("dbo.Applicant_Job_Applications", new[] { "Applicant" });
            DropTable("dbo.Security_Roles");
            DropTable("dbo.Security_Logins_Roles");
            DropTable("dbo.Security_Logins_Log");
            DropTable("dbo.Security_Logins");
            DropTable("dbo.System_Country_Codes");
            DropTable("dbo.Applicant_Work_History");
            DropTable("dbo.Applicant_Skills");
            DropTable("dbo.Applicant_Resumes");
            DropTable("dbo.Company_Locations");
            DropTable("dbo.System_Language_Codes");
            DropTable("dbo.Company_Descriptions");
            DropTable("dbo.Company_Profiles");
            DropTable("dbo.Company_Job_Skills");
            DropTable("dbo.Company_Job_Educations");
            DropTable("dbo.Company_Jobs_Descriptions");
            DropTable("dbo.Company_Jobs");
            DropTable("dbo.Applicant_Job_Applications");
            DropTable("dbo.Applicant_Profiles");
            DropTable("dbo.Applicant_Educations");
        }
    }
}
