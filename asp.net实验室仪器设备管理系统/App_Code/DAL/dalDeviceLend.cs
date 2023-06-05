using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*设备借用业务逻辑层实现*/
    public class dalDeviceLend
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加设备借用实现*/
        public static bool AddDeviceLend(ENTITY.DeviceLend deviceLend)
        {
            string sql = "insert into DeviceLend(deviceObj,lendNumber,lendDate,lendDays,returnDate,userObj,lendMemo) values(@deviceObj,@lendNumber,@lendDate,@lendDays,@returnDate,@userObj,@lendMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceObj",SqlDbType.Int),
             new SqlParameter("@lendNumber",SqlDbType.Int),
             new SqlParameter("@lendDate",SqlDbType.DateTime),
             new SqlParameter("@lendDays",SqlDbType.Float),
             new SqlParameter("@returnDate",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@lendMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = deviceLend.deviceObj; //借用的设备
            parm[1].Value = deviceLend.lendNumber; //借用数量
            parm[2].Value = deviceLend.lendDate; //借用日期
            parm[3].Value = deviceLend.lendDays; //借用天数
            parm[4].Value = deviceLend.returnDate; //归还时间
            parm[5].Value = deviceLend.userObj; //借用人
            parm[6].Value = deviceLend.lendMemo; //备注信息

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据lendId获取某条设备借用记录*/
        public static ENTITY.DeviceLend getSomeDeviceLend(int lendId)
        {
            /*构建查询sql*/
            string sql = "select * from DeviceLend where lendId=" + lendId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.DeviceLend deviceLend = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                deviceLend = new ENTITY.DeviceLend();
                deviceLend.lendId = Convert.ToInt32(DataRead["lendId"]);
                deviceLend.deviceObj = Convert.ToInt32(DataRead["deviceObj"]);
                deviceLend.lendNumber = Convert.ToInt32(DataRead["lendNumber"]);
                deviceLend.lendDate = Convert.ToDateTime(DataRead["lendDate"].ToString());
                deviceLend.lendDays = float.Parse(DataRead["lendDays"].ToString());
                deviceLend.returnDate = DataRead["returnDate"].ToString();
                deviceLend.userObj = DataRead["userObj"].ToString();
                deviceLend.lendMemo = DataRead["lendMemo"].ToString();
            }
            return deviceLend;
        }

        /*更新设备借用实现*/
        public static bool EditDeviceLend(ENTITY.DeviceLend deviceLend)
        {
            string sql = "update DeviceLend set deviceObj=@deviceObj,lendNumber=@lendNumber,lendDate=@lendDate,lendDays=@lendDays,returnDate=@returnDate,userObj=@userObj,lendMemo=@lendMemo where lendId=@lendId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceObj",SqlDbType.Int),
             new SqlParameter("@lendNumber",SqlDbType.Int),
             new SqlParameter("@lendDate",SqlDbType.DateTime),
             new SqlParameter("@lendDays",SqlDbType.Float),
             new SqlParameter("@returnDate",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@lendMemo",SqlDbType.VarChar),
             new SqlParameter("@lendId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = deviceLend.deviceObj;
            parm[1].Value = deviceLend.lendNumber;
            parm[2].Value = deviceLend.lendDate;
            parm[3].Value = deviceLend.lendDays;
            parm[4].Value = deviceLend.returnDate;
            parm[5].Value = deviceLend.userObj;
            parm[6].Value = deviceLend.lendMemo;
            parm[7].Value = deviceLend.lendId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除设备借用*/
        public static bool DelDeviceLend(string p)
        {
            string sql = "delete from DeviceLend where lendId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询设备借用*/
        public static DataSet GetDeviceLend(string strWhere)
        {
            try
            {
                string strSql = "select * from DeviceLend" + strWhere + " order by lendId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询设备借用*/
        public static System.Data.DataTable GetDeviceLend(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from DeviceLend";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "lendId", strShow, strSql, strWhere, " lendId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllDeviceLend()
        {
            try
            {
                string strSql = "select * from DeviceLend";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
