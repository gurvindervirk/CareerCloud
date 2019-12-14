using CareerCloud.Pocos;
using System;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
        {

        }
        public override void Add(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            foreach (CompanyDescriptionPoco poco in pocos)
            {
               
            }
            base.Add(pocos);
        }

        public override void Update(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {

                if (string.IsNullOrEmpty(poco.CompanyName ))
                {
                    exceptions.Add(new ValidationException(106, $"CompanyName for CompanyDescription{poco.Id} cannot be null"));
                }
                   else if (poco.CompanyName.Length < 3)
                {
                    exceptions.Add(new ValidationException(106, $"Companyname for CompanyDescription{poco.Id} must be Minimum of 2 Characters"));
                }
                if (string.IsNullOrEmpty(poco.CompanyDescription ))
                {
                    exceptions.Add(new ValidationException(107, $"CompanyDescription for CompanyDescription{poco.Id} cannot be null"));
                }
               else if (poco.CompanyDescription.Length < 3)
                {
                    exceptions.Add(new ValidationException(107, $"CompanyDescription for CompanyDescription{poco.Id} must be Minimum of 2 Characters"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
