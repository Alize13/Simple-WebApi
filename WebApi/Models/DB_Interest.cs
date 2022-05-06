using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Dapper;

namespace WebApi.Models
{
    public class DB_Interest
    {
        #region 公開屬性
        /// <summary>
        /// 流水號
        /// </summary>
        public int InterestID { get; set; }

        /// <summary>
        /// 興趣
        /// </summary>
        public string Interest { get; set; }
        #endregion

        #region 方法

        /// <summary>
        /// 取得興趣列表
        /// </summary>
        /// <returns></returns>
        public static object GetList(ref List<DB_Interest> _results)
        {
            object reObj = 0;
            _results = new List<DB_Interest>();
            try
            {
                string ConnStr = WebConfigurationManager.ConnectionStrings["DBTESTConnStr"].ConnectionString;

                using (var cn = new SqlConnection(ConnStr))
                {
                    _results = cn.Query<DB_Interest>(@"SELECT * FROM Interests").ToList();
                }
            }
            catch (Exception ex)
            {
                //reObj = ex.ToString();
                throw new Exception(ex.Message);
            }
            return reObj;
        }

        #endregion
    }
}