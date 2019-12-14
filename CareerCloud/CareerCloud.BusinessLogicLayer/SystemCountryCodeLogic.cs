using CareerCloud.Pocos;
using System;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic :  BaseCodeLogic<SystemCountryCodePoco>
    {
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository) : base(repository)
        {

        }
        public override void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            foreach (SystemCountryCodePoco poco in pocos)
            {
               
            }
            base.Add(pocos);
        }

        public override void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {

                if (string.IsNullOrEmpty(poco.Code))
                {
                    exceptions.Add(new ValidationException(900, $"Code for SystemCountryCode {poco.Code } not be empty"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(901, $"Name for SystemCountryCode {poco.Code } not be empty"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }
    }
}
