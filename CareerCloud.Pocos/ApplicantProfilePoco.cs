﻿using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CareerCloud.Pocos
{

    [Table("Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {

        [Key]
        public Guid Id { get; set; }

        public Guid Login { get; set; }

        [Column("Current_Salary")]
        public Decimal? CurrentSalary { get; set; }

        [Column("Current_Rate")]
        public Decimal? CurrentRate { get; set; }

       
        public String Currency { get; set; }

      
        [Column("Country_Code")]

        public String Country { get; set; }

        [Column("State_Province_Code")]
        public String Province { get; set; }

        [Column("Street_Address")]
        public String Street { get; set; }

        [Column("City_Town")]
        public String City { get; set; }

        [Column("Zip_Postal_Code")]
        public String PostalCode { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }
        public virtual SecurityLoginPoco   SecurityLogin { get; set; }

        public virtual SystemCountryCodePoco  SystemCountryCodes{ get; set; }
        public virtual ICollection<ApplicantEducationPoco>ApplicantEducations{ get; set; }
        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public virtual ICollection<ApplicantResumePoco> ApplicantResumes { get; set; }
        public virtual ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }

    }
}


