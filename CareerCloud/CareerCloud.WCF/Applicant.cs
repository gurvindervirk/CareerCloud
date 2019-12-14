using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Applicant" in both code and config file together.
    public class Applicant : IApplicant
    {
        private ApplicantEducationLogic _logic;
        private ApplicantJobApplicationLogic  _logicAJL;
        private ApplicantProfileLogic  _logicProfile;
        private ApplicantResumeLogic _logicApplicantResume;
        private ApplicantSkillLogic _logicApplicantSkillLogic;
        private ApplicantWorkHistoryLogic  _logicApplicantWorkHistoryLogic;
        public Applicant()
       {
            EFGenericRepository<ApplicantEducationPoco> repo = new EFGenericRepository<ApplicantEducationPoco>(false);

            _logic = new ApplicantEducationLogic(repo);

            EFGenericRepository<ApplicantJobApplicationPoco  > repo1 = new EFGenericRepository<ApplicantJobApplicationPoco>(false);

            _logicAJL  = new ApplicantJobApplicationLogic (repo1);

            EFGenericRepository<ApplicantProfilePoco > repo2 = new EFGenericRepository<ApplicantProfilePoco >(false);

           _logicProfile  = new ApplicantProfileLogic (repo2);

            EFGenericRepository<ApplicantResumePoco > repo3 = new EFGenericRepository<ApplicantResumePoco >(false);

            _logicApplicantResume = new ApplicantResumeLogic (repo3);

            EFGenericRepository<ApplicantSkillPoco > repo4 = new EFGenericRepository<ApplicantSkillPoco >(false);

            _logicApplicantSkillLogic = new ApplicantSkillLogic  (repo4);

            EFGenericRepository<ApplicantWorkHistoryPoco > repo5 = new EFGenericRepository<ApplicantWorkHistoryPoco >(false);

            _logicApplicantWorkHistoryLogic = new ApplicantWorkHistoryLogic (repo5);
        }

        public void addapplicanteducation(ApplicantEducationPoco[] item)
        {
                     _logic.Add(item);
        }

        public IList<ApplicantEducationPoco> GetAllApplicantEducationPocos()
        {
                       return _logic.GetAll();
                    }

        public ApplicantEducationPoco GetSingleApplicantEducationPoco(Guid Id)
        {
                      return _logic.Get(Id);
         }

        public void removeapplicanteducation(ApplicantEducationPoco[] items)
        {

            _logic.Delete(items);
        }

        public void updateapplicanteducation(ApplicantEducationPoco[] items)
        {
          
            _logic.Update(items);
        }


        public void addApplicantJobApplicationPoco(ApplicantJobApplicationPoco[] item)
        {
            _logicAJL.Add(item);
            
        }

        public void addApplicantProfilePoco(ApplicantProfilePoco[] item)
        {
            _logicProfile.Add(item);
        }

        public void addApplicantResumePoco(ApplicantResumePoco[] item)
        {
            _logicApplicantResume .Add(item);
        }

        public void addApplicantSkillPoco(ApplicantSkillPoco[] item)
        {
            _logicApplicantSkillLogic.Add(item);
        }

        public void addApplicantWorkHistoryPoco(ApplicantWorkHistoryPoco[] item)
        {
            _logicApplicantWorkHistoryLogic.Add(item);
        }

       

        public IList<ApplicantJobApplicationPoco> GetAllApplicantJobApplicationPoco()
        {
            return _logicAJL .GetAll();
        }

        public IList<ApplicantProfilePoco> GetAllApplicantProfilePoco()
        {
            return _logicProfile .GetAll();
        }

        public IList<ApplicantResumePoco> GetAllApplicantResumePoco()
        {
            return _logicApplicantResume.GetAll();
        }

        public IList<ApplicantSkillPoco> GetAllApplicantSkillPoco()
        {
            return _logicApplicantSkillLogic.GetAll();
        }

        public IList<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistoryPoco()
        {
            return _logicApplicantWorkHistoryLogic.GetAll();

        }

        public ApplicantJobApplicationPoco GetSingleApplicantJobApplicationPoco(Guid Id)
        {
            return _logicAJL.Get  (Id);
        }

        public ApplicantProfilePoco GetSingleApplicantProfilePoco(Guid Id)
        {
            return _logicProfile .Get(Id);
        }

        public ApplicantResumePoco GetSingleApplicantResumePoco(Guid Id)
        {
            return _logicApplicantResume .Get(Id);
        }

        public ApplicantSkillPoco GetSingleApplicantSkillPoco(Guid Id)
        {
            return _logicApplicantSkillLogic .Get(Id);
        }

        public ApplicantWorkHistoryPoco GetSingleApplicantWorkHistoryPoco(Guid Id)
        {
            return  _logicApplicantWorkHistoryLogic .Get(Id);
        }

       

        public void removeApplicantJobApplicationPoco(ApplicantJobApplicationPoco[] items)
        {
           _logicAJL .Delete(items);
        }

        public void removeApplicantProfilePoco(ApplicantProfilePoco[] items)
        {
            _logicProfile .Delete(items);
        }
         public void removeApplicantResumePoco(ApplicantResumePoco[] items)
        {
            _logicApplicantResume .Delete(items);
        }

        public void removeApplicantSkillPoco(ApplicantSkillPoco[] items)
        {
            _logicApplicantSkillLogic .Delete(items);
        }

        public void removeApplicantWorkHistoryPoco(ApplicantWorkHistoryPoco[] items)
        {
           _logicApplicantWorkHistoryLogic .Delete(items);
        }
          public void updateApplicantJobApplicationPoco(ApplicantJobApplicationPoco[] items)
        {
            _logicAJL.Update(items);
        }

        public void updateApplicantProfilePoco(ApplicantProfilePoco[] items)
        {
          _logicProfile .Update(items);
        }

        public void updateApplicantResumePoco(ApplicantResumePoco[] items)
        {
            _logicApplicantResume .Update(items);
        }

        public void updateApplicantSkillPoco(ApplicantSkillPoco[] items)
        {
            _logicApplicantSkillLogic .Update(items);
        }

        public void updateApplicantWorkHistoryPoco(ApplicantWorkHistoryPoco[] items)
        {
            _logicApplicantWorkHistoryLogic .Update(items);
        }
    }
}

