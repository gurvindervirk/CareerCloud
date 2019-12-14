using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantJobApplicationLogic : BaseLogic<ApplicantJobApplicationPoco>
    {
        private const int saltLengthLimit = 10;

        public ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : base(repository)
        {

        }
        public override void Add(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            foreach (ApplicantJobApplicationPoco poco in pocos)
            {
                
            }
            base.Add(pocos);
        }

        public override void Update(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantJobApplicationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
               

                if (poco.ApplicationDate  > DateTime.Now.Date)
                {
                    exceptions.Add(new ValidationException(110, $"Application Date for ApplicantJobApplication {poco.Id} must not be greater than Current Date"));
                }
             

            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
