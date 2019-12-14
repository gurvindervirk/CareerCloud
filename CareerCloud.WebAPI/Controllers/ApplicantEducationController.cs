using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/education")]
    //[RoutePrefix("api/careercloud/applicant/v1")]
    public class ApplicantEducationController : ApiController
    {
        private ApplicantEducationLogic _logic;

        public ApplicantEducationController()
        {
            EFGenericRepository<ApplicantEducationPoco> repo = new EFGenericRepository<ApplicantEducationPoco>();
            _logic = new ApplicantEducationLogic(repo);
        }
        [HttpGet]
        [Route("{Id:Guid}")]
        [ResponseType(typeof(ApplicantEducationPoco))]
        public IHttpActionResult  GetApplicantEducation(Guid applicantEducationId)
        {

            try
            {
                ApplicantEducationPoco poco = _logic.Get(applicantEducationId);
                if (poco == null)
                {
                    return NotFound();
                }
                return Ok(poco);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<ApplicantEducationPoco>))]
        public IHttpActionResult GetApplicantEducation()
        {
            try
            {
                List<ApplicantEducationPoco> poco = _logic.GetAll();
                if (poco == null)
                {
                    return NotFound();
                }
                return Ok(poco);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(List<ApplicantEducationPoco>))] public IHttpActionResult
           PostApplicantEducation([FromBody] ApplicantEducationPoco[] pocos  )
        {
            try
            {
                _logic.Add(pocos);
                return Ok(pocos);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [Route("{Id:Guid}")]

        public IHttpActionResult
          PutApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            try
            {
               
                _logic.Update(pocos);
                return Ok(pocos);
                
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpDelete]
        [Route("{Id:Guid}")]

        public IHttpActionResult
        DeleteApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            try
            {

                _logic.Delete (pocos);
                return Ok(pocos);

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
