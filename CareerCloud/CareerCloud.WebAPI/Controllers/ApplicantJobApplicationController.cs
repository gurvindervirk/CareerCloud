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
    [RoutePrefix("api/careercloud/applicantJob/v1")]
    public class ApplicantJobApplicationController : ApiController
    {
        private ApplicantJobApplicationLogic _logic;

        public ApplicantJobApplicationController()
        {
            EFGenericRepository<ApplicantJobApplicationPoco> repo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            _logic = new ApplicantJobApplicationLogic(repo);
        }
        [HttpGet]
        [Route("{Id:Guid}")]
        [ResponseType(typeof(ApplicantJobApplicationPoco))]
        public IHttpActionResult   GetApplicantJobApplication(Guid ApplicantJobApplicationId)
        {

            try
            {
                ApplicantJobApplicationPoco poco = _logic.Get(ApplicantJobApplicationId);
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
        [ResponseType(typeof(List<ApplicantJobApplicationPoco>))]
        public IHttpActionResult   GetApplicantEducation()
        {
            try
            {
                List<ApplicantJobApplicationPoco> poco = _logic.GetAll();
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
        [ResponseType(typeof(List<ApplicantJobApplicationPoco>))]
        public IHttpActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
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
          PutApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
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
        DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            try
            {

                _logic.Delete(pocos);
                return Ok(pocos);

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
