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
    [Table("Applicant_Skills")]
    public class ApplicantSkillPoco : IPoco
    {
       
        [Key]
        public Guid Id { get; set; }
               
        public Guid Applicant { get; set; }
             
        public String Skill { get; set; }

        [Column("Skill_Level")]
        public String SkillLevel { get; set; }

        [Column("Start_Month")]
        public Byte StartMonth { get; set; }

        [Column("Start_Year")]
        public int StartYear { get; set; }

        [Column("End_Month")]
        public Byte EndMonth { get; set; }

        [Column("End_Year")]
        public int EndYear { get; set; }

        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }
        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }

    }
}
