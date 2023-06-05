using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*设备事故业务逻辑层实现*/
    public class dalAccident
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加设备事故实现*/
        public static bool AddAccident(ENTITY.Accident accident)
        {
            string sql = "insert into Accident(deviceObj,reason,accidentContent,accidentTime,userObj) values(@deviceObj,@reason,@accidentContent,@accidentTime,@userObj)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceObj",SqlDbType.Int),
             new SqlParameter("@reason",SqlDbType.VarChar),
             new SqlParameter("@accidentContent",SqlDbType.VarChar),
             new SqlParameter("@accidentTime",SqlDbType.DateTime),
             new SqlParameter("@userObj",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = accident.deviceObj; //事故的设备
            parm[1].Value = accident.reason; //事故原因
            parm[2].Value = accident.accidentContent; //事故内容
            parm[3].Value = accident.accidentTime; //事故时间
            parm[4].Value = accident.userObj; //上报的用户

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据accidentId获取某条设备事故记录*/
        public static ENTITY.Accident getSomeAccident(int accidentId)
        {
            /*构建查询sql*/
            string sql = "select * from Accident where accidentId=" + accidentId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Accident accident = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                accident = new ENTITY.Accident();
                accident.accidentId = Convert.ToInt32(DataRead["accidentId"]);
                accident.deviceObj = Convert.ToInt32(DataRead["deviceObj"]);
                accident.reason = DataRead["reason"].ToString();
                accident.accidentContent = DataRead["accidentContent"].ToString();
                accident.accidentTime = Convert.ToDateTime(DataRead["accidentTime"].ToString());
                accident.userObj = DataRead["userObj"].ToString();
            }
            return accident;
        }

        /*更新设备事故实现*/
        public static bool EditAccident(ENTITY.Accident accident)
        {
            string sql = "update Accident set deviceObj=@deviceObj,reason=@reason,accidentContent=@accidentContent,accidentTime=@accidentTime,userObj=@userObj where accidentId=@accidentId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceObj",SqlDbType.Int),
             new SqlParameter("@reason",SqlDbType.VarChar),
             new SqlParameter("@accidentContent",SqlDbType.VarChar),
             new SqlParameter("@accidentTime",SqlDbType.DateTime),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@accidentId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = accident.deviceObj;
            parm[1].Value = accident.reason;
            parm[2].Value = accident.accidentContent;
            parm[3].Value = accident.accidentTime;
            parm[4].Value = accident.userObj;
            parm[5].Value = accident.accidentId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除设备事故*/
        public static bool DelAccident(string p)
        {
            string sql = "delete from Accident where accidentId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询设备事故*/
        public static DataSet GetAccident(string strWhere)
        {
            try
            {
                string strSql = "select * from Accident" + strWhere + " order by accidentId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询设备事故*/
        public static System.Data.DataTable GetAccident(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Accident";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "accidentId", strShow, strSql, strWhere, " accidentId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllAccident()
        {
            try
            {
                string strSql = "select * from Accident";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
