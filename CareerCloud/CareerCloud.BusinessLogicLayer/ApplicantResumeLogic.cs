using CareerCloud.Pocos;
using System;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantResumeLogic : BaseLogic<ApplicantResumePoco>
    {
        public ApplicantResumeLogic(IDataRepository<ApplicantResumePoco> repository) : base(repository)
        {

        }
        public override void Add(ApplicantResumePoco[] pocos)
        {
            Verify(pocos);
            foreach (ApplicantResumePoco poco in pocos)
            {
                
            }
            base.Add(pocos);
        }

        public override void Update(ApplicantResumePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantResumePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Resume ))
                {
                    exceptions.Add(new ValidationException(113, $"Resume for ApplicantResume{poco.Id} must not be blank"));
                }
               
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
