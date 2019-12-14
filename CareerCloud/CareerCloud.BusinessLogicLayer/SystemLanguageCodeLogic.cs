using CareerCloud.Pocos;
using System;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic : BaseLanguageIDLogic<SystemLanguageCodePoco>

    {
        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository) : base(repository)
        {

        }
        public override void Add(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            foreach (SystemLanguageCodePoco poco in pocos)
            {

            }
            base.Add(pocos);
        }

        public override void Update(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(SystemLanguageCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {

                if (string.IsNullOrEmpty(poco.LanguageID))
                {
                    exceptions.Add(new ValidationException(1000, $"LanguageID for SystemLanguageCode {poco.LanguageID } not be empty"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(1001, $"Name for SystemLanguageCode {poco.LanguageID} not be empty"));
                }
                if (string.IsNullOrEmpty(poco.NativeName))
                {
                    exceptions.Add(new ValidationException(1002, $"NativeName for SystemLanguageCode {poco.LanguageID} not be empty"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }
    }
}
