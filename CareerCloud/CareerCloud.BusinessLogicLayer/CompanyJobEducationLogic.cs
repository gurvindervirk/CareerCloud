using CareerCloud.Pocos;
using System;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;
namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
    {
        public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository)
        {

        }
        public override void Add(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            foreach (CompanyJobEducationPoco poco in pocos)
            {
                
            }
            base.Add(pocos);
        }

        public override void Update(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major ))
                {
                    exceptions.Add(new ValidationException(200, $"Major for CompanyJobEducation{poco.Id} cannot be null"));
                }
                else if (poco.Major.Length <3)
                {
                    exceptions.Add(new ValidationException(200, $"Major for CompanyJobEducation{poco.Id} must have minimum 2 Characters"));
                }
                if (poco.Importance <0)
                {
                    exceptions.Add(new ValidationException(201, $"Importance for CompanyJobEducation{poco.Id} must not be Less Than Zero"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
