using CareerCloud.Pocos;
using System;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobDescriptionLogic : BaseLogic<CompanyJobDescriptionPoco>
    {
        public CompanyJobDescriptionLogic(IDataRepository<CompanyJobDescriptionPoco> repository) : base(repository)
        {

        }
        public override void Add(CompanyJobDescriptionPoco[] pocos)
        {
            Verify(pocos);
            foreach (CompanyJobDescriptionPoco poco in pocos)
            {
               
            }
            base.Add(pocos);
        }

        public override void Update(CompanyJobDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.JobName  ))
                {
                    exceptions.Add(new ValidationException(300, $"JobName for CompanyJobDescription{poco.Id} must not be Empty"));
                }
                if (string.IsNullOrEmpty(poco.JobDescriptions ))
                {
                    exceptions.Add(new ValidationException(301, $"JobDescription for CompanyJobDescription{poco.Id} must not be Empty"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
