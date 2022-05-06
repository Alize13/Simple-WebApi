using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebApi.Data.CodeEnum;

namespace WebApi.Models
{
    public class APIResultObject
    {
        #region Private property

        private StatusCode _statusCode;  // 狀態參數
        private string _message = string.Empty; // 信息
        private object _retObj = false; // 回傳資料集合
        private string _siteID = string.Empty; //站台(有針對站台的話才給)
        #endregion

        #region Public  property

        /// <summary>
        /// 狀態參數
        /// </summary>
        public StatusCode Code
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }

        /// <summary>
        /// 信息
        /// </summary>
        public string ErrMsg
        {
            get { return _message; }
            set { _message = value; }
        }
        /// <summary>
        /// 狀態參數
        /// </summary>
        public object RetObj
        {
            get { return _retObj; }
            set { _retObj = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 構造函數
        /// </summary>
        public APIResultObject()
        {
        }

        /// <summary>
        /// 構造函數
        /// </summary>
        /// <param name="statusCode">狀態代碼</param>
        /// <param name="retObj">結果對象</param>
        /// <param name="retObj">消息</param>
        public APIResultObject(StatusCode statusCode, object retObj, string message = "")
        {
            _statusCode = statusCode;
            _retObj = retObj;
            if (!message.Equals(""))
            {
                _message = message;
            }
        }

        #endregion
    }
}