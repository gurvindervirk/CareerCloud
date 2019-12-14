using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
  
    [Table("Security_Logins")]
    public class SecurityLoginPoco : IPoco
    {
        
        [Key]
        public Guid Id { get; set; }

        //[Required(ErrorMessage = "Please enter user name.")]
        //[DataType(DataType.Text)]
        //[Display(Name = "User Name")]
        //[StringLength(30)]
        public String LoginName { get; set; }

        //[Required(ErrorMessage = "Please enter password.")]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        
        //[MinLength(6, ErrorMessage = "Minimum Password must be 6 in charaters")]
        public String Password { get; set; }

        [Column("Created_Date")]
        //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }


        [Column("Password_Update_Date")]

        public DateTime? PasswordUpdate { get; set; }

        [Column("Agreement_Accepted_Date")]

        public DateTime? AgreementAccepted { get; set; }

        [Column("Is_Locked")]

        public Boolean IsLocked { get; set; }


        [Column("Is_Inactive")]

        public Boolean IsInactive { get; set; }

        [Column("Email_Address")]
        //[Required(ErrorMessage = "EmailID Required")]
        //[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public String EmailAddress { get; set; }

        [Column("Phone_Number")]
        //[Required(ErrorMessage = "PhoneNo Required")]
        //[RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong PhoneNo")]
        public String PhoneNumber { get; set; }


        [Column("Full_Name")]
        //[Required(ErrorMessage = "Full Name Required")]
        public String FullName { get; set; }


        [Column("Force_Change_Password")]

        public Boolean ForceChangePassword { get; set; }

        [Column("Prefferred_Language")]
        //[Required(ErrorMessage = "Prefferred Language Required")]
        public String PrefferredLanguage { get; set; }
        [Timestamp]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }
        public virtual ICollection<SecurityLoginsRolePoco>SecurityLoginsRoles{ get; set; }
        public virtual ICollection<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
               
    }

}
