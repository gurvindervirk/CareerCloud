﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace CareerCloud.Pocos
{
    [Table("Applicant_Work_History")]
    public class ApplicantWorkHistoryPoco : IPoco
    {


      
        [Key]
        public Guid Id { get; set; }

       
        public Guid Applicant { get; set; }

        [Column("Company_Name")]
        public String CompanyName { get; set; }


        [Column("Country_Code")]

        public String CountryCode { get; set; }



        [Column("Location")]
        public String Location { get; set; }



        [Column("Job_Title")]
        public String JobTitle { get; set; }



        [Column("Job_Description")]
        public String JobDescription { get; set; }



        [Column("Start_Month")]
        public Int16 StartMonth { get; set; }

        [Column("Start_Year")]
        public int StartYear { get; set; }


        [Column("End_Month")]
        public Int16 EndMonth { get; set; }

        [Column("End_Year")]
        public int EndYear { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }
        public virtual ApplicantProfilePoco  ApplicantProfiles { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCodes { get; set; }
    }
}

