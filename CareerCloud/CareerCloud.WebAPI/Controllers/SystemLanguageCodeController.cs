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
    [RoutePrefix("api/careercloud/LanguageCode")]
    public class SystemLanguageCodeController : ApiController
    {
        private SystemLanguageCodeLogic _logic;

        public SystemLanguageCodeController()
        {
            EFGenericRepository<SystemLanguageCodePoco> repo = new EFGenericRepository<SystemLanguageCodePoco>();
            _logic = new SystemLanguageCodeLogic(repo);
        }
        [HttpGet]
        [Route("{Id:String}")]
        [ResponseType(typeof(SecurityLoginPoco))]
        public IHttpActionResult GetSystemLanguageCode(String SystemLanguageCodeId)
        {

            try
            {
                SystemLanguageCodePoco poco = _logic.Get(SystemLanguageCodeId);
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
        [ResponseType(typeof(List<SystemLanguageCodePoco>))]
        public IHttpActionResult GetSystemLanguageCode()
        {
            try
            {
                List<SystemLanguageCodePoco> poco = _logic.GetAll();
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
        [ResponseType(typeof(List<SystemLanguageCodePoco>))]
        public IHttpActionResult PostSystemLanguageCode([FromBody]SystemLanguageCodePoco[] pocos)
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
        [Route("{Id:String}")]

        public IHttpActionResult PutSystemLanguageCode([FromBody]SystemLanguageCodePoco[] pocos)
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

        public IHttpActionResult DeleteSystemLanguageCode([FromBody]SystemLanguageCodePoco[] pocos)
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
