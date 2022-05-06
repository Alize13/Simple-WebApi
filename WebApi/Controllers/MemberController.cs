using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class MemberController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            APIResultObject result = new APIResultObject();
            try
            {
                DB_Member Member = new DB_Member();
                result.Code = CodeEnum.StatusCode.OK;
                result.ErrMsg = "";
                result.RetObj = Member.Delete(id);
            }
            catch (Exception ex)
            {
                result.Code = CodeEnum.StatusCode.InternalServerError;
                result.ErrMsg = ex.Message;
            }
            return Json(result);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(MemberSearchParam param)
        {
            APIResultObject result = new APIResultObject();
            try
            {
                DB_Member List = new DB_Member();
                result.Code = CodeEnum.StatusCode.OK;
                result.ErrMsg = "";
                result.RetObj = List.GetListPaging(param);
            }
            catch (Exception ex)
            {
                result.Code = CodeEnum.StatusCode.InternalServerError;
                result.ErrMsg = ex.Message;
            }
            return Json(result);
        }

        // Post api/<controller>/5
        public IHttpActionResult Post(DB_Member _model)
        {
            APIResultObject result = new APIResultObject();
            try
            {
                result.Code = CodeEnum.StatusCode.OK;
                result.ErrMsg = "";
                result.RetObj = _model.Create();
            }
            catch (Exception ex)
            {
                result.Code = CodeEnum.StatusCode.InternalServerError;
                result.ErrMsg = ex.Message;
            }
            return Json(result);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(DB_Member _model)
        {

            APIResultObject result = new APIResultObject();
            try
            {
                result.Code = CodeEnum.StatusCode.OK;
                result.ErrMsg = "";
                result.RetObj = _model.Update();
            }
            catch (Exception ex)
            {
                result.Code = CodeEnum.StatusCode.InternalServerError;
                result.ErrMsg = ex.Message;
            }
            return Json(result);
        }

    }
}
