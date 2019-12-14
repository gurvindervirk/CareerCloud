using System;
using System.Collections.Generic;
using CareerCloud.Pocos;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
namespace CareerCloud.WCF
{
    public class Security : ISecurity
    {
        private SecurityLoginLogic  _logic;
        private SecurityLoginsLogLogic  _logicAJL;
        private SecurityLoginsRoleLogic  _logicLoginRole;
        private SecurityRoleLogic  _logicSecurityRole;
        public Security ()
        {

            EFGenericRepository<SecurityLoginPoco > repo = new EFGenericRepository<SecurityLoginPoco >(false);

            _logic = new SecurityLoginLogic (repo);

            EFGenericRepository<SecurityLoginsLogPoco > repo1 = new EFGenericRepository<SecurityLoginsLogPoco >(false);

            _logicAJL = new SecurityLoginsLogLogic  (repo1);

            EFGenericRepository<SecurityLoginsRolePoco > repo2 = new EFGenericRepository<SecurityLoginsRolePoco >(false);

            _logicLoginRole = new SecurityLoginsRoleLogic (repo2);

            EFGenericRepository<SecurityRolePoco > repo3 = new EFGenericRepository<SecurityRolePoco >(false);

            _logicSecurityRole = new SecurityRoleLogic  (repo3);
        }

        public void addSecurityLoginPoco(SecurityLoginPoco[] items)
        {
            _logic.Add(items);
        }

        public void addSecurityLoginsLogPoco(SecurityLoginsLogPoco[] items)
        {
            _logicAJL.Add(items);
        }

        public void addSecurityLoginsRolePoco(SecurityLoginsRolePoco[] items)
        {
            _logicLoginRole.Add(items);
        }

        public void addSecurityRolePoco(SecurityRolePoco[] items)
        {
            _logicSecurityRole.Add(items);
        }

        public IList<SecurityLoginPoco> GetAllSecurityLoginPoco()
        {
            return _logic.GetAll();
        }

        public IList<SecurityLoginsLogPoco> GetAllSecurityLoginsLogPoco()
        {
            return _logicAJL.GetAll();
        }

        public IList<SecurityLoginsRolePoco> GetAllSecurityLoginsRolePoco()
        {
            return _logicLoginRole.GetAll();
        }

        public IList<SecurityRolePoco> GetAllSecurityRolePoco()
        {
            return _logicSecurityRole.GetAll();
        }

        public SecurityLoginPoco GetSingleSecurityLoginPoco(Guid Id)
        {
            return _logic.Get(Id);
        }

        public SecurityLoginsLogPoco GetSingleSecurityLoginsLogPoco(Guid Id)
        {
            return _logicAJL.Get(Id);
        }

        public SecurityLoginsRolePoco GetSingleSecurityLoginsRolePoco(Guid Id)
        {
            return _logicLoginRole.Get(Id);
        }

        public SecurityRolePoco GetSingleSecurityRolePoco(Guid Id)
        {
            return _logicSecurityRole.Get(Id);
        }

        public void removeSecurityLoginPoco(SecurityLoginPoco[] items)
        {
            _logic.Delete(items);
        }

        public void removeSecurityLoginsLogPoco(SecurityLoginsLogPoco[] items)
        {
            _logicAJL.Delete(items);
        }

        public void removeSecurityLoginsRolePoco(SecurityLoginsRolePoco[] items)
        {
            _logicLoginRole.Delete(items);
        }

        public void removeSecurityRolePoco(SecurityRolePoco[] items)
        {
            _logicSecurityRole.Delete(items);
        }

        public void updateSecurityLoginPoco(SecurityLoginPoco[] items)
        {
            _logic.Update(items);
        }

        public void updateSecurityLoginsLogPoco(SecurityLoginsLogPoco[] items)
        {
            _logicAJL.Update(items);
        }

        public void updateSecurityLoginsRolePoco(SecurityLoginsRolePoco[] items)
        {
            _logicLoginRole.Update(items);
        }

        public void updateSecurityRolePoco(SecurityRolePoco[] items)
        {
            _logicSecurityRole.Update (items);
        }
          
    }
}
