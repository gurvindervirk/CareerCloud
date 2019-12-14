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
    public interface ISecurity
    {
        [OperationContract]
        void addSecurityLoginPoco(SecurityLoginPoco [] items);
        [OperationContract]
        void addSecurityLoginsLogPoco(SecurityLoginsLogPoco [] items);
        [OperationContract]
        void addSecurityLoginsRolePoco(SecurityLoginsRolePoco [] items);
        [OperationContract]
        void addSecurityRolePoco(SecurityRolePoco [] items);

        [OperationContract]
        void updateSecurityLoginPoco(SecurityLoginPoco[] items);
        [OperationContract]
        void updateSecurityLoginsLogPoco(SecurityLoginsLogPoco[] items);
        [OperationContract]
        void updateSecurityLoginsRolePoco(SecurityLoginsRolePoco[] items);
        [OperationContract]
        void updateSecurityRolePoco(SecurityRolePoco[] items);

        [OperationContract]
        void removeSecurityLoginPoco(SecurityLoginPoco[] items);
        [OperationContract]
        void removeSecurityLoginsLogPoco(SecurityLoginsLogPoco[] items);
        [OperationContract]
        void removeSecurityLoginsRolePoco(SecurityLoginsRolePoco[] items);
        [OperationContract]
        void removeSecurityRolePoco(SecurityRolePoco[] items);

        [OperationContract]
        IList<SecurityLoginPoco > GetAllSecurityLoginPoco();
        [OperationContract]
        IList<SecurityLoginsLogPoco > GetAllSecurityLoginsLogPoco();
        [OperationContract]
        IList<SecurityRolePoco > GetAllSecurityRolePoco();
        [OperationContract]
        IList<SecurityLoginsRolePoco > GetAllSecurityLoginsRolePoco();

        [OperationContract]
        SecurityLoginPoco GetSingleSecurityLoginPoco(Guid Id);
        [OperationContract]
        SecurityLoginsLogPoco GetSingleSecurityLoginsLogPoco(Guid Id);
        [OperationContract]
        SecurityRolePoco GetSingleSecurityRolePoco(Guid Id);

        SecurityLoginsRolePoco GetSingleSecurityLoginsRolePoco(Guid Id);
       
    }
}
