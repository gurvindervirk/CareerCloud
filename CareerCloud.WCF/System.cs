using System;
using System.Collections.Generic;
using CareerCloud.Pocos;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;

namespace CareerCloud.WCF
{
    

    public class System : ISystem
       {
        private SystemCountryCodeLogic _logic;
        private SystemLanguageCodeLogic  _logicAJL;
        public System()
        {
            EFGenericRepository<SystemCountryCodePoco > repo = new EFGenericRepository<SystemCountryCodePoco >(false);

            _logic = new SystemCountryCodeLogic (repo);

            EFGenericRepository<SystemLanguageCodePoco > repo1 = new EFGenericRepository<SystemLanguageCodePoco >(false);

            _logicAJL = new SystemLanguageCodeLogic (repo1);
        }
        public void AddSystemCountryCodePoc(SystemCountryCodePoco[] items)
        {
            _logic.Add(items);
        }

        public void AddSystemLanguageCodePoco(SystemLanguageCodePoco[] items)
        {
            _logicAJL.Add(items);
        }

        public IList<SystemCountryCodePoco> GetAllSystemCountryCodePoco()
        {
            return _logic.GetAll();
        }

        public IList<SystemLanguageCodePoco> GetAllSystemLanguageCodePoco()
        {
            return _logicAJL.GetAll();
        }

        public SystemCountryCodePoco GetSingleSystemCountryCodePoco(String  Id)
        {
            return _logic.Get(Id);
        }
            

        public SystemLanguageCodePoco GetSingleSystemLanguageCodePoco(String  Id)
        {
            return _logicAJL.Get(Id);
        }
             

        public void RemoveSystemCountryCodePoc(SystemCountryCodePoco[] items)
        {
            _logic.Delete(items);
        }

        public void RemoveSystemLanguageCodePoco(SystemLanguageCodePoco[] items)
        {
            _logicAJL.Delete(items);
        }

        public void UpdateSystemCountryCodePoc(SystemCountryCodePoco[] items)
        {
            _logic.Update(items);
        }

        public void UpdateSystemLanguageCodePoco(SystemLanguageCodePoco[] items)
        {
            _logicAJL.Update(items);
        }
    }
}
