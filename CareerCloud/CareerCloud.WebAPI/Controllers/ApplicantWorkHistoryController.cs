﻿using System;
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
    [RoutePrefix("api/careercloud/applicantWork")]
    public class ApplicantWorkHistoryController : ApiController
    {
        private ApplicantWorkHistoryLogic _logic;

        public ApplicantWorkHistoryController()
        {
            EFGenericRepository<ApplicantWorkHistoryPoco> repo = new EFGenericRepository<ApplicantWorkHistoryPoco>();
            _logic = new ApplicantWorkHistoryLogic(repo);
        }
        [HttpGet]
        [Route("{Id:Guid}")]
        [ResponseType(typeof(ApplicantWorkHistoryPoco))]
        public IHttpActionResult  GetApplicantWorkHistory(Guid ApplicantWorkHistoryId)
        {

            try
            {
                ApplicantWorkHistoryPoco poco = _logic.Get(ApplicantWorkHistoryId);
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
        [ResponseType(typeof(List<ApplicantWorkHistoryPoco>))]
        public IHttpActionResult GetApplicantWorkHistory()
        {
            try
            {
                List<ApplicantWorkHistoryPoco> poco = _logic.GetAll();
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
        [ResponseType(typeof(List<ApplicantWorkHistoryPoco>))]
        public IHttpActionResult  PostApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
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

        public IHttpActionResult  PutApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
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

        public IHttpActionResult  DeleteApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
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
