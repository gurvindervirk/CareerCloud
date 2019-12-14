using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IApplicant" in both code and config file together.
    [ServiceContract]
    public interface IApplicant
    {
        [OperationContract]
      void  addapplicanteducation(ApplicantEducationPoco[] item);
        [OperationContract]
        void updateapplicanteducation(ApplicantEducationPoco[] items );
        [OperationContract]
        void removeapplicanteducation(ApplicantEducationPoco[] items);
        [OperationContract]
        IList<ApplicantEducationPoco> GetAllApplicantEducationPocos();
        [OperationContract]
        ApplicantEducationPoco GetSingleApplicantEducationPoco(Guid Id);

        //ApplicantJobApplicationPoco

        [OperationContract]
        void addApplicantJobApplicationPoco(ApplicantJobApplicationPoco[] item);
        [OperationContract]
        void updateApplicantJobApplicationPoco(ApplicantJobApplicationPoco[] items);
        [OperationContract]
        void removeApplicantJobApplicationPoco(ApplicantJobApplicationPoco[] items);
        [OperationContract]
        IList<ApplicantJobApplicationPoco> GetAllApplicantJobApplicationPoco();
        [OperationContract]
        ApplicantJobApplicationPoco GetSingleApplicantJobApplicationPoco(Guid Id);
        
        //ApplicantProfile
        [OperationContract]
        void addApplicantProfilePoco(ApplicantProfilePoco [] item);
        [OperationContract]
        void updateApplicantProfilePoco(ApplicantProfilePoco[] items);
        [OperationContract]
        void removeApplicantProfilePoco(ApplicantProfilePoco[] items);
        [OperationContract]
        IList<ApplicantProfilePoco> GetAllApplicantProfilePoco();
        [OperationContract]
        ApplicantProfilePoco GetSingleApplicantProfilePoco(Guid Id);

        //ApplicantResumePoco

        [OperationContract]
        void addApplicantResumePoco(ApplicantResumePoco [] item);
        [OperationContract]
        void updateApplicantResumePoco(ApplicantResumePoco [] items);
        [OperationContract]
        void removeApplicantResumePoco(ApplicantResumePoco [] items);
        [OperationContract]
        IList<ApplicantResumePoco > GetAllApplicantResumePoco();
        [OperationContract]
        ApplicantResumePoco GetSingleApplicantResumePoco(Guid Id);

        //ApplicantSkillPoco

        [OperationContract]
        void addApplicantSkillPoco(ApplicantSkillPoco [] item);
        [OperationContract]
        void updateApplicantSkillPoco(ApplicantSkillPoco[] items);
        [OperationContract]
        void removeApplicantSkillPoco(ApplicantSkillPoco[] items);
        [OperationContract]
        IList<ApplicantSkillPoco> GetAllApplicantSkillPoco();
        [OperationContract]
        ApplicantSkillPoco GetSingleApplicantSkillPoco(Guid Id);

        //ApplicantWorkHistoryPoco

        [OperationContract]
        void addApplicantWorkHistoryPoco(ApplicantWorkHistoryPoco [] item);
        [OperationContract]
        void updateApplicantWorkHistoryPoco(ApplicantWorkHistoryPoco[] items);
        [OperationContract]
        void removeApplicantWorkHistoryPoco(ApplicantWorkHistoryPoco[] items);
        [OperationContract]
        IList<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistoryPoco();
        [OperationContract]
        ApplicantWorkHistoryPoco GetSingleApplicantWorkHistoryPoco(Guid Id);
    }
}
