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
    [RoutePrefix("api/careercloud/applicantSkill")]
    public class ApplicantSkillController : ApiController
    {
        private ApplicantSkillLogic _logic;

        public ApplicantSkillController()
        {
            EFGenericRepository<ApplicantSkillPoco> repo = new EFGenericRepository<ApplicantSkillPoco>();
            _logic = new ApplicantSkillLogic(repo);
        }
        [HttpGet]
        [Route("{Id:Guid}")]
        [ResponseType(typeof(ApplicantSkillPoco))]
        public IHttpActionResult  GetApplicantSkill(Guid ApplicantSkillId)
        {

            try
            {
                ApplicantSkillPoco poco = _logic.Get(ApplicantSkillId);
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
        [ResponseType(typeof(List<ApplicantSkillPoco>))]
        public IHttpActionResult   GetApplicantSkillPoco()
        {
            try
            {
                List<ApplicantSkillPoco> poco = _logic.GetAll();
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
        [ResponseType(typeof(List<ApplicantSkillPoco>))]
        public IHttpActionResult  PostApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
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

        public IHttpActionResult  PutApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
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
        DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
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
