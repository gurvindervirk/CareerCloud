using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.Pocos;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;

namespace CareerCloud.WCF
{
    
    public class Company : ICompany
    {
        private CompanyDescriptionLogic  _logic;
        private CompanyJobDescriptionLogic  _logicAJL;
        private CompanyJobEducationLogic  _logicEducation;
        private CompanyJobLogic  _logicJob;
        private CompanyJobSkillLogic  _logicJobSkill;
        private CompanyLocationLogic  _logicCompanyLocation;
        private CompanyProfileLogic _logicCompanyProfile;
        public Company()
        {
            EFGenericRepository<CompanyDescriptionPoco> repo = new EFGenericRepository<CompanyDescriptionPoco>(false);

            _logic = new CompanyDescriptionLogic(repo);

            EFGenericRepository<CompanyJobDescriptionPoco> repo1 = new EFGenericRepository<CompanyJobDescriptionPoco>(false);

            _logicAJL = new CompanyJobDescriptionLogic (repo1);

            EFGenericRepository<CompanyJobEducationPoco> repo2 = new EFGenericRepository<CompanyJobEducationPoco>(false);

            _logicEducation = new CompanyJobEducationLogic(repo2);

            EFGenericRepository<CompanyJobPoco> repo3 = new EFGenericRepository<CompanyJobPoco>(false);

            _logicJob = new CompanyJobLogic(repo3);

            EFGenericRepository<CompanyJobSkillPoco> repo4 = new EFGenericRepository<CompanyJobSkillPoco>(false);

            _logicJobSkill = new CompanyJobSkillLogic(repo4);

            EFGenericRepository<CompanyLocationPoco> repo5 = new EFGenericRepository<CompanyLocationPoco>(false);

            _logicCompanyLocation = new CompanyLocationLogic(repo5);

            EFGenericRepository<CompanyProfilePoco > repo6 = new EFGenericRepository<CompanyProfilePoco >(false);

            _logicCompanyProfile = new CompanyProfileLogic (repo6);
        }
        public void addCompanyDescriptionPoco(CompanyDescriptionPoco[] items)
        {
            _logic.Add(items);
        }

        public void addCompanyJobDescriptionPoco(CompanyJobDescriptionPoco[] items)
        {
             _logicAJL.Add(items);
        }

        public void addCompanyJobEducationPoco(CompanyJobEducationPoco[] Items)
        {
            _logicEducation.Add(Items);
        }

        public void addCompanyJobPoco(CompanyJobPoco[] items)
        {
            _logicJob.Add(items);
        }

        public void addCompanyJobSkillPoco(CompanyJobSkillPoco[] items)
        {
            _logicJobSkill.Add(items);
        }

        public void addCompanyLocationPoco(CompanyLocationPoco[] items)
        {
            _logicCompanyLocation.Add(items);
        }

        public void addCompanyProfilePoco(CompanyProfilePoco[] items)
        {
            _logicCompanyProfile.Add(items);
        }

        public IList<CompanyDescriptionPoco> GetAllCompanyDescriptionPoco()
        {
            return _logic.GetAll();
        }

        public IList<CompanyJobDescriptionPoco> GetAllCompanyJobDescriptionPoco()
        {
           return  _logicAJL.GetAll();
        }

        public IList<CompanyJobEducationPoco> GetAllCompanyJobEducationPoco()
        {
            return _logicEducation.GetAll();
        }

        public IList<CompanyJobPoco> GetAllCompanyJobPoco()
        {
            return _logicJob.GetAll();
        }

        public IList<CompanyJobSkillPoco> GetAllCompanyJobSkillPoco()
        {
            return _logicJobSkill.GetAll();
        }

        public IList<CompanyLocationPoco> GetAllCompanyLocationPoco()
        {
            return _logicCompanyLocation.GetAll();
        }

        public IList<CompanyProfilePoco> GetAllCompanyProfilePoco()
        {
            return _logicCompanyProfile.GetAll();
        }

        public CompanyDescriptionPoco GetSingleCompanyDescriptionPoco(Guid Id)
        {
            return _logic.Get(Id);
        }

        public CompanyJobDescriptionPoco GetSingleCompanyJobDescriptionPoco(Guid Id)
        {
            return _logicAJL.Get(Id);
        }

        public CompanyJobEducationPoco GetSingleCompanyJobEducationPoco(Guid Id)
        {
            return _logicEducation.Get(Id);
        }

        public CompanyJobPoco GetSingleCompanyJobPoco(Guid Id)
        {
            return _logicJob.Get(Id);
        }

        public CompanyJobSkillPoco GetSingleCompanyJobSkillPoco(Guid Id)
        {
            return _logicJobSkill.Get(Id);
        }

        public CompanyLocationPoco GetSingleCompanyLocationPoco(Guid Id)
        {
            return _logicCompanyLocation.Get(Id);
        }

        public CompanyProfilePoco GetSingleCompanyProfilePoco(Guid Id)
        {
            return _logicCompanyProfile.Get(Id);
        }

        public void removeCompanyDescriptionPoco(CompanyDescriptionPoco[] items)
        {
            _logic.Delete(items);
        }

        public void removeCompanyJobDescriptionPoco(CompanyJobDescriptionPoco[] items)
        {
            _logicAJL.Delete(items);
        }

        public void removeCompanyJobEducationPoco(CompanyJobEducationPoco[] Items)
        {
            _logicEducation.Delete(Items);
        }

        public void removeCompanyJobPoco(CompanyJobPoco[] items)
        {
            _logicJob.Delete(items);
        }

        public void removeCompanyJobSkillPoco(CompanyJobSkillPoco[] items)
        {
            _logicJobSkill.Delete(items);
        }

        public void removeCompanyLocationPoco(CompanyLocationPoco[] items)
        {
            _logicCompanyLocation.Delete(items);
        }

        public void removeCompanyProfilePoco(CompanyProfilePoco[] items)
        {
            _logicCompanyProfile.Delete(items);
        }

        public void updateCompanyDescriptionPoco(CompanyDescriptionPoco[] items)
        {
            _logic.Update(items);
        }
            public void updateCompanyJobDescriptionPoco(CompanyJobDescriptionPoco[] items)
        {
            _logicAJL.Update(items);
        }

        public void updateCompanyJobEducationPoco(CompanyJobEducationPoco[] Items)
        {
            _logicEducation.Update(Items);
        }

        public void updateCompanyJobPoco(CompanyJobPoco[] items)
        {
            _logicJob.Update(items);
        }

        public void updateCompanyJobSkillPoco(CompanyJobSkillPoco[] items)
        {
            _logicJobSkill.Update(items);
        }

        public void updateCompanyLocationPoco(CompanyLocationPoco[] items)
        {
            _logicCompanyLocation.Update(items);
        }

        public void updateCompanyProfilePoco(CompanyProfilePoco[] items)
        {
            _logicCompanyProfile.Update(items);
        }
    }
}
