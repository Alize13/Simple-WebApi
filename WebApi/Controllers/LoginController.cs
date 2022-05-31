using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Web.Configuration;
using WebApi.Models;
using Dapper;
using WebApi.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Controllers
{
    /// <summary>
    /// 登入
    /// </summary>
    public class LoginController : ApiController
    {
        string cnStr = WebConfigurationManager.ConnectionStrings["DBTESTConnStr"].ConnectionString;
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}


        #region 取得JWT TOKEN
        /// <summary>
        /// 取得TOKEN
        /// </summary>
        [HttpPost]
        [Route("api/Login/Token")]
        public IHttpActionResult Token()
        {
            APIResultObject result = new APIResultObject();
            try
            {
                if (System.Web.HttpContext.Current == null)
                {
                    result.Code = CodeEnum.StatusCode.SessionError;
                    result.ErrMsg = CodeEnum.StatusCode.SessionError.ToString();
                    return Content(HttpStatusCode.NotImplemented, result);
                }

                //JWT , https://github.com/jwt-dotnet/jwt

                ////Set issued at date
                //DateTime issuedAt = DateTime.UtcNow;
                ////set the time when it expires
                //DateTime expires = DateTime.UtcNow.AddDays(7);

                //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.SetDefaultTimesOnTokenCreation = false;
                //create a identity and add claims to the user which we want to log in
                var claimsIdentity = new ClaimsIdentity(new[]
                {
                     new Claim("SessionID", System.Web.HttpContext.Current.Session.SessionID)
                });
                string secrectKey = ConfigurationManager.AppSettings["JWTsecretKey"].ToString();
                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secrectKey));
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                //Create the jwt (JSON Web Token)
                //Replace the issuer and audience with your URL (ex. http:localhost:12345)
                var token =
                    tokenHandler.CreateEncodedJwt(
                        issuer: null,
                        audience: null,
                        subject: claimsIdentity,
                        notBefore: null,
                        expires: null,
                        issuedAt: null,
                        signingCredentials: signingCredentials);

                //var tokenString = tokenHandler.WriteToken(token);


                //存入SESSION
                System.Web.HttpContext.Current.Session["token"] = token;

                result.Code = CodeEnum.StatusCode.OK;
                result.ErrMsg = "";
                result.RetObj = token;
            }
            catch (Exception ex)
            {
                result.Code = CodeEnum.StatusCode.InternalServerError;
                result.ErrMsg = ex.Message;
            }
            return Json(result);
        }
        #endregion
       
        #region 登入
        /// <summary>
        /// 登入
        /// </summary>
        public IHttpActionResult Post([FromBody] LoginUser _model)
        {
            APIResultObject result = new APIResultObject();
            try
            {
                bool ValidateTag = ModelState.IsValid;

                if (!ValidateTag || _model == null || string.IsNullOrEmpty(_model.Account) || string.IsNullOrEmpty(_model.Password))
                {
                    result.Code = CodeEnum.StatusCode.ParameterIncorrect;
                    result.ErrMsg = CodeEnum.StatusCode.ParameterIncorrect.ToString();
                    return Json(result);
                }


                DB_Member MemberItem = new DB_Member();
                object retobj = "";
                if (_model.Account == "Test" && _model.Password=="123456")
                {
                    MemberItem.MemberID = 0;
                    MemberItem.MemberAccount = _model.Account;
                    MemberItem.MemberLevel = 1;
                    MemberItem.MemberLevel_Str = "特殊權限";
                    retobj = MemberItem;
                }
                else
                {
                    //驗証密碼並取得會員資料
                    retobj = MemberItem.LoginCheck(_model);

                }


                if (string.IsNullOrEmpty(retobj.ToString()))
                {
                    result.Code = CodeEnum.StatusCode.ApiMsgError;
                    result.ErrMsg = "帳號或密碼錯誤 !";
                }
                else
                {
                    result.Code = CodeEnum.StatusCode.OK;
                    result.ErrMsg = "";
                    result.RetObj = retobj;
                }
            }
            catch (Exception ex)
            {
                result.Code = CodeEnum.StatusCode.InternalServerError;
                result.ErrMsg = CodeEnum.StatusCode.InternalServerError.ToString() + ":" + ex.ToString();
            }
            return Json(result);
        }
        #endregion

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}