using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
   
    [ServiceContract]
    public interface ICompany
    {
        [OperationContract]
        void addCompanyDescriptionPoco(CompanyDescriptionPoco[] items);
        [OperationContract]
        void addCompanyJobDescriptionPoco(CompanyJobDescriptionPoco[] items);
        [OperationContract]
        void addCompanyJobEducationPoco(CompanyJobEducationPoco[] Items);
        [OperationContract]
        void addCompanyJobPoco(CompanyJobPoco[] items);
        [OperationContract]
        void addCompanyJobSkillPoco(CompanyJobSkillPoco[] items);
        [OperationContract]
        void addCompanyLocationPoco(CompanyLocationPoco[] items);
        [OperationContract]
        void addCompanyProfilePoco(CompanyProfilePoco[] items);


        [OperationContract]
        void updateCompanyDescriptionPoco(CompanyDescriptionPoco[] items);
        [OperationContract]
        void updateCompanyJobDescriptionPoco(CompanyJobDescriptionPoco[] items);
        [OperationContract]
        void updateCompanyJobEducationPoco(CompanyJobEducationPoco[] Items);
        [OperationContract]
        void updateCompanyJobPoco(CompanyJobPoco[] items);
        [OperationContract]
        void updateCompanyJobSkillPoco(CompanyJobSkillPoco[] items);
        [OperationContract]
        void updateCompanyLocationPoco(CompanyLocationPoco[] items);
        [OperationContract]
        void updateCompanyProfilePoco(CompanyProfilePoco[] items);

        [OperationContract]
        void removeCompanyDescriptionPoco(CompanyDescriptionPoco[] items);
        [OperationContract]
        void removeCompanyJobDescriptionPoco(CompanyJobDescriptionPoco[] items);
        [OperationContract]
        void removeCompanyJobEducationPoco(CompanyJobEducationPoco[] Items);
        [OperationContract]
        void removeCompanyJobPoco(CompanyJobPoco[] items);
        [OperationContract]
        void removeCompanyJobSkillPoco(CompanyJobSkillPoco[] items);
        [OperationContract]
        void removeCompanyLocationPoco(CompanyLocationPoco[] items);
        [OperationContract]
        void removeCompanyProfilePoco(CompanyProfilePoco[] items);

        [OperationContract]
        IList<CompanyDescriptionPoco > GetAllCompanyDescriptionPoco();
        [OperationContract]
        IList<CompanyJobDescriptionPoco > GetAllCompanyJobDescriptionPoco();
       [ OperationContract]
        IList<CompanyJobEducationPoco > GetAllCompanyJobEducationPoco();
        [OperationContract]
        IList<CompanyJobPoco > GetAllCompanyJobPoco();

        [OperationContract]
        IList<CompanyJobSkillPoco > GetAllCompanyJobSkillPoco();
        [OperationContract]
        IList<CompanyLocationPoco > GetAllCompanyLocationPoco();
        [OperationContract]
        IList<CompanyProfilePoco > GetAllCompanyProfilePoco();


        [OperationContract]
        CompanyDescriptionPoco GetSingleCompanyDescriptionPoco(Guid Id);
        [OperationContract]
        CompanyJobDescriptionPoco GetSingleCompanyJobDescriptionPoco(Guid Id);
        [OperationContract]
        CompanyJobEducationPoco GetSingleCompanyJobEducationPoco(Guid Id);
        [OperationContract]
        CompanyJobPoco GetSingleCompanyJobPoco(Guid Id);
        [OperationContract]
        CompanyJobSkillPoco GetSingleCompanyJobSkillPoco(Guid Id);
        [OperationContract]
        CompanyLocationPoco GetSingleCompanyLocationPoco(Guid Id);
        [OperationContract]
        CompanyProfilePoco GetSingleCompanyProfilePoco(Guid Id);


    }
}
