using System;
using System.Collections.Generic;
using System.ServiceModel;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    
    [ServiceContract]
    public interface ISystem
    {
       
        [OperationContract]
        void AddSystemCountryCodePoc(SystemCountryCodePoco [] items);
        [OperationContract]
        void AddSystemLanguageCodePoco(SystemLanguageCodePoco [] items);

        [OperationContract]
        void UpdateSystemCountryCodePoc(SystemCountryCodePoco[] items);

        [OperationContract]
        void UpdateSystemLanguageCodePoco(SystemLanguageCodePoco[] items);

        [OperationContract]
        void RemoveSystemCountryCodePoc(SystemCountryCodePoco[] items);

        [OperationContract]
        void RemoveSystemLanguageCodePoco(SystemLanguageCodePoco[] items);

        [OperationContract]
        IList<SystemCountryCodePoco> GetAllSystemCountryCodePoco();

        [OperationContract]
        IList<SystemLanguageCodePoco> GetAllSystemLanguageCodePoco();

        [OperationContract]
        SystemCountryCodePoco GetSingleSystemCountryCodePoco(String  Id);

        [OperationContract]
        SystemLanguageCodePoco GetSingleSystemLanguageCodePoco(String  Id);
     }
}
