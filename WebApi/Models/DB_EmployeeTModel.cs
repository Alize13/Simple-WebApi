using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBOperator.Helper;
using DBOperator.Models;

namespace WebApi.Models.DB_Employee
{
    #region DB_EmployeeTModel=================
    /// <summary>
    /// 
    /// </summary>
    [DBMapping("EmployeeT")]
    public class DB_EmployeeTModel : SysBaseModel
    {
        #region Public property

        private int m_EmployeeID;
        /// <summary>
        /// 
        /// </summary>
        [DBSetting("EmployeeID", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int EmployeeID
        {
            get
            {
                return m_EmployeeID;
            }
            set
            {
                m_EmployeeID = value;
            }
        }

        private int m_CompanyID;
        /// <summary>
        /// 隸屬公司
        /// </summary>
        [DBSetting("CompanyID", DbType = SqlDataType.Int, IsCanNull = false, DataLength = 4)]
        public int CompanyID
        {
            get
            {
                return m_CompanyID;
            }
            set
            {
                m_CompanyID = value;
            }
        }

        private int? m_SecurityID;
        /// <summary>
        /// 
        /// </summary>
        [DBSetting("SecurityID", DbType = SqlDataType.Int, DataLength = 4)]
        public int? SecurityID
        {
            get
            {
                return m_SecurityID;
            }
            set
            {
                m_SecurityID = value;
            }
        }

        private string m_EmployeeName;
        /// <summary>
        /// 員工姓名
        /// </summary>
        [DBSetting("EmployeeName", IsCanNull = false, DataLength = 20)]
        public string EmployeeName
        {
            get
            {
                return m_EmployeeName;
            }
            set
            {
                m_EmployeeName = value;
            }
        }

        private string m_EmployeeNo;
        /// <summary>
        /// 員工編號
        /// </summary>
        [DBSetting("EmployeeNo", DbType = SqlDataType.VarChar, IsCanNull = false, DataLength = 10)]
        public string EmployeeNo
        {
            get
            {
                return m_EmployeeNo;
            }
            set
            {
                m_EmployeeNo = value;
            }
        }

        private string m_EmployeeMail;
        /// <summary>
        /// 員工電子信箱
        /// </summary>
        [DBSetting("EmployeeMail", DbType = SqlDataType.VarChar, DataLength = 50)]
        public string EmployeeMail
        {
            get
            {
                return m_EmployeeMail;
            }
            set
            {
                m_EmployeeMail = value;
            }
        }

        private DateTime? m_EmployeeBirthday;
        /// <summary>
        /// 生日
        /// </summary>
        [DBSetting("EmployeeBirthday", DbType = SqlDataType.Date, DataLength = 3)]
        public DateTime? EmployeeBirthday
        {
            get
            {
                return m_EmployeeBirthday;
            }
            set
            {
                m_EmployeeBirthday = value;
            }
        }

        private DateTime? m_EmployeeStartDay;
        /// <summary>
        /// 到職日
        /// </summary>
        [DBSetting("EmployeeStartDay", DbType = SqlDataType.Date, DataLength = 3)]
        public DateTime? EmployeeStartDay
        {
            get
            {
                return m_EmployeeStartDay;
            }
            set
            {
                m_EmployeeStartDay = value;
            }
        }

        private DateTime? m_EmployeeEndDay;
        /// <summary>
        /// 離職日
        /// </summary>
        [DBSetting("EmployeeEndDay", DbType = SqlDataType.Date, DataLength = 3)]
        public DateTime? EmployeeEndDay
        {
            get
            {
                return m_EmployeeEndDay;
            }
            set
            {
                m_EmployeeEndDay = value;
            }
        }

        private bool m_EmployeeIsEnd;
        /// <summary>
        /// 是否離職（1：是，  0：否）
        /// </summary>
        [DBSetting("EmployeeIsEnd", DbType = SqlDataType.Bit, IsCanNull = false, DataLength = 1)]
        public bool EmployeeIsEnd
        {
            get
            {
                return m_EmployeeIsEnd;
            }
            set
            {
                m_EmployeeIsEnd = value;
            }
        }

        private int? m_EmployeeSalary;
        /// <summary>
        /// 薪資
        /// </summary>
        [DBSetting("EmployeeSalary", DbType = SqlDataType.Int, DataLength = 4)]
        public int? EmployeeSalary
        {
            get
            {
                return m_EmployeeSalary;
            }
            set
            {
                m_EmployeeSalary = value;
            }
        }

        private string m_EmployeePosition;
        /// <summary>
        /// 職務
        /// </summary>
        [DBSetting("EmployeePosition", DataLength = 40)]
        public string EmployeePosition
        {
            get
            {
                return m_EmployeePosition;
            }
            set
            {
                m_EmployeePosition = value;
            }
        }

        private string m_EmployeeAccount;
        /// <summary>
        /// 會員帳號
        /// </summary>
        [DBSetting("EmployeeAccount", DbType = SqlDataType.VarChar, IsCanNull = false, DataLength = 20)]
        public string EmployeeAccount
        {
            get
            {
                return m_EmployeeAccount;
            }
            set
            {
                m_EmployeeAccount = value;
            }
        }

        private string m_EmployeePassword;
        /// <summary>
        /// 會員密碼
        /// </summary>
        [DBSetting("EmployeePassword", DbType = SqlDataType.VarChar, IsCanNull = false, DataLength = 20)]
        public string EmployeePassword
        {
            get
            {
                return m_EmployeePassword;
            }
            set
            {
                m_EmployeePassword = value;
            }
        }

        private bool m_EmployeeState;
        /// <summary>
        /// 是否啟用
        /// </summary>
        [DBSetting("EmployeeState", DbType = SqlDataType.Bit, IsCanNull = false, DataLength = 1)]
        public bool EmployeeState
        {
            get
            {
                return m_EmployeeState;
            }
            set
            {
                m_EmployeeState = value;
            }
        }

        #endregion

        #region Method

        #region 確認指定欄位的值是否存在 CheckValueExist(string ColumnName, object Value ,ref bool IsExist, bool IsCreateMode = true)
        /// <summary>
        /// 確認指定欄位的值是否存在，true:已存在相同的值 ; false : 未存在 (有新增和編輯模式)
        /// </summary>
        /// <param name="ColumnName">欄位名稱</param>
        /// <param name="Value">要確認指定欄位是否有此值(只提供字串[string] 或數字[int])</param>
        /// <param name="IsExist">ture:已存在該值的資料 ; false:不存在該值的資料</param>
        /// <param name="IsCreateMode">模式 true:新增模式(預設值) ; false:編輯模式(排除本身的)</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public object CheckValueExist(string ColumnName, object Value, ref bool IsExist, bool IsCreateMode = true)
        {
            OBFactory orm = new OBFactory();
            List<DB_EmployeeTModel> list = new List<DB_EmployeeTModel>();
            System.Data.SqlClient.SqlParameter para;

            if (Value.GetType() == string.Empty.GetType())
            {
                para = DBAccess.MakeInParam(ColumnName, SqlDataType.NVarChar, Value.ToString());
            }
            else
            {
                para = DBAccess.MakeInParam(ColumnName, SqlDataType.Int, (int)Value);
            }

            System.Data.SqlClient.SqlParameter[] ParList = { para };
            object retObj;
            if (IsCreateMode)
            {
                retObj = orm.ReadListToObjs<DB_EmployeeTModel>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<DB_EmployeeTModel>(ColumnName + "=@" + ColumnName + " and EmployeeID<>" + this.EmployeeID.ToString(), ref list, ParList);
            }

            if (retObj.ToString() == "0")
            {
                if (list.Count > 0)
                {
                    IsExist = true;
                }
                else
                {
                    IsExist = false;
                }
            }
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_EmployeeTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆EmployeeT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref DB_EmployeeTModel item, string strCusTableName = "")
        {
            OBFactory orm = new OBFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆EmployeeT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆EmployeeT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref DB_EmployeeTModel item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            OBFactory orm = new OBFactory();
            List<DB_EmployeeTModel> itemlist = new List<DB_EmployeeTModel>();
            object retObj = orm.ReadListToObjs(strSqlWhere, ref itemlist, sqlParameterList: MySqlParameterList, CusTableName: strCusTableName);
            if (retObj.ToString() == "0" && itemlist.Count > 0)
            {
                if (itemlist.Count == 1)
                {
                    item = itemlist[0];
                }
                else
                {
                    retObj = "Error：有一筆以上的資料";
                }
            }
            return retObj;
        }
        #endregion

        #region 取得多筆DB_EmployeeTModel資料 ReadList
        /// <summary>
        /// 取得多筆 EmployeeT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>      
        /// <returns></returns>
        public static object ReadList(ref List<DB_EmployeeTModel> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            OBFactory orm = new OBFactory();

            object retObj = orm.ReadListToObjs<DB_EmployeeTModel>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 EmployeeT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 EmployeeT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="IsWithlogicDelete">false:未被邏輯刪除的資料(預設值) ; true:已被邏輯刪除的資料</param>
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<DB_EmployeeTModel> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            OBFactory orm = new OBFactory();

            object retObj = orm.ReadListToObjs<DB_EmployeeTModel>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增EmployeeT 項目
        /// </summary>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            OBFactory orm = new OBFactory();
            object retObj = orm.InsertByObj<DB_EmployeeTModel>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 EmployeeT 項目
        /// </summary>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>   
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            OBFactory orm = new OBFactory();
            object retObj = orm.UpdateObj<DB_EmployeeTModel>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目EmployeeT Delete()
        /// <summary>
        /// 刪除項目EmployeeT
        /// </summary>     
        public object Delete(string strCusTableName = "")
        {
            OBFactory orm = new OBFactory();
            object retObj = orm.DeleteObj<DB_EmployeeTModel>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目EmployeeT Delete(int iPKey, string strCusTableName = "")
        /// <summary>
        /// 刪除項目EmployeeT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param>       
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            OBFactory orm = new OBFactory();
            object retObj = orm.DeleteObj<DB_EmployeeTModel>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目EmployeeT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目EmployeeT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>       
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            OBFactory orm = new OBFactory();
            object retObj = orm.DeleteObj<DB_EmployeeTModel>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}