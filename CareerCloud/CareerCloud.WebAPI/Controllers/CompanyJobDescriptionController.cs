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
    [RoutePrefix("api/careercloud/companyJobDesc")]
    public class CompanyJobDescriptionController : ApiController
    {
        private CompanyJobDescriptionLogic _logic;

        public CompanyJobDescriptionController()
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repo = new EFGenericRepository<CompanyJobDescriptionPoco>();
            _logic = new CompanyJobDescriptionLogic(repo);
        }
        [HttpGet]
        [Route("{Id:Guid}")]
        [ResponseType(typeof(CompanyJobDescriptionPoco))]
        public IHttpActionResult  GetCompanyJobDescription(Guid CompanyJobDescriptionId)
        {

            try
            {
                CompanyJobDescriptionPoco poco = _logic.Get(CompanyJobDescriptionId);
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
        [ResponseType(typeof(List<CompanyJobDescriptionPoco>))]
        public IHttpActionResult  GetCompanyJobDescription()
        {
            try
            {
                List<CompanyJobDescriptionPoco> poco = _logic.GetAll();
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
        [ResponseType(typeof(List<CompanyJobDescriptionPoco>))]
        public IHttpActionResult  PostCompanyJobDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
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

        public IHttpActionResult PutCompanyJobDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
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

        public IHttpActionResult DeleteCompanyJobDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
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
