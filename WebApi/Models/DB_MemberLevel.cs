using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Dapper;

namespace WebApi.Models
{
    public class DB_MemberLevel
    {
        #region 公開屬性
        /// <summary>
        /// 流水號
        /// </summary>
        public int LevelID { get; set; }

        /// <summary>
        /// 會員等級
        /// </summary>
        public int MemberLevel { get; set; }

        /// <summary>
        /// 會員等級名稱
        /// </summary>
        public string LevelName { get; set; }
        #endregion

        #region 方法

        #region 取得會員等級列表
        /// <summary>
        /// 取得會員等級列表
        /// </summary>
        /// <returns></returns>
        public static object GetList(ref List<DB_MemberLevel> _results)
        {
            object reObj = 0;
            _results = new List<DB_MemberLevel>();
            try
            {
                string ConnStr = WebConfigurationManager.ConnectionStrings["DBTESTConnStr"].ConnectionString;

                using (var cn = new SqlConnection(ConnStr))
                {
                    _results = cn.Query<DB_MemberLevel>(@"SELECT * FROM MemberLevels").ToList();
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

        #endregion
    }
}