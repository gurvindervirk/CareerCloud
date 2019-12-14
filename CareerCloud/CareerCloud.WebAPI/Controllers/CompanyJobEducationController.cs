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
    [RoutePrefix("api/careercloud/companyJobEducation")]
    public class CompanyJobEducationController : ApiController
    {
        private CompanyJobEducationLogic _logic;

        public CompanyJobEducationController()
        {
            EFGenericRepository<CompanyJobEducationPoco> repo = new EFGenericRepository<CompanyJobEducationPoco>();
            _logic = new CompanyJobEducationLogic(repo);
        }
        [HttpGet]
        [Route("{Id:Guid}")]
        [ResponseType(typeof(CompanyJobEducationPoco))]
        public IHttpActionResult  GetCompanyJobEducationl(Guid CompanyJobEducationId)
        {

            try
            {
               CompanyJobEducationPoco poco = _logic.Get(CompanyJobEducationId);
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
        [ResponseType(typeof(List<CompanyJobEducationPoco>))]
        public IHttpActionResult  GetCompanyJobEducation()
        {
            try
            {
                List<CompanyJobEducationPoco> poco = _logic.GetAll();
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
        [ResponseType(typeof(List<CompanyJobEducationPoco>))]
        public IHttpActionResult PostCompanyJobEducation([FromBody]CompanyJobEducationPoco[] pocos)
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

        public IHttpActionResult PutCompanyJobEducation([FromBody]CompanyJobEducationPoco[] pocos)
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

        public IHttpActionResult DeleteCompanyJobEducation([FromBody]CompanyJobEducationPoco[] pocos)
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
