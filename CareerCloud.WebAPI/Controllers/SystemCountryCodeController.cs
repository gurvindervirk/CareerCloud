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
    [RoutePrefix("api/careercloud/CountryCode")]
    public class SystemCountryCodeController : ApiController
    {
        private SystemCountryCodeLogic _logic;

        public SystemCountryCodeController()
        {
            EFGenericRepository<SystemCountryCodePoco> repo = new EFGenericRepository<SystemCountryCodePoco>();
            _logic = new  SystemCountryCodeLogic(repo);
        }
        [HttpGet]
        [Route("{Id:String}")]
        [ResponseType(typeof(SecurityLoginPoco))]
        public IHttpActionResult GetSystemCountryCode(String SystemCountryCodeId)
        {

            try
            {
                SystemCountryCodePoco poco = _logic.Get(SystemCountryCodeId);
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
        [ResponseType(typeof(List<SystemCountryCodePoco>))]
        public IHttpActionResult GetSystemCountryCode()
        {
            try
            {
                List<SystemCountryCodePoco> poco = _logic.GetAll();
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
        [ResponseType(typeof(List<SystemCountryCodePoco>))]
        public IHttpActionResult PostSystemCountryCode([FromBody]SystemCountryCodePoco[] pocos)
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
        [Route("Id:String")]

        public IHttpActionResult PutSystemCountryCode([FromBody]SystemCountryCodePoco[] pocos)
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
        [Route("{Id:String}")]

        public IHttpActionResult DeleteSystemCountryCode([FromBody]SystemCountryCodePoco[] pocos)
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
