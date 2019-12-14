using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        private const int saltLengthLimit = 10;

        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {

        }
       

        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            foreach (ApplicantEducationPoco poco in pocos)
            {
                
            }
            base.Add(pocos);
        }

        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major))
                {
                    exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation{poco.Id} cannot be null"));
                }
                else if (poco.Major.Length < 3)
                {
                    exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation {poco.Id} must be at least 3 characters."));
                }


                if (poco.StartDate > DateTime.Now)
                {
                    exceptions.Add(new ValidationException(108, $"Start Date for ApplicantEducation {poco.Id} must be Equal to Current Date"));
                }

                if (poco.CompletionDate <= DateTime.Now)
                {
                    exceptions.Add(new ValidationException(109, $"Completion Date for ApplicantEducation {poco.Id} must be greater than to start Date"));
                }


            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }



    } 
}

