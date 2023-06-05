using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*报废设备业务逻辑层实现*/
    public class dalRubbish
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加报废设备实现*/
        public static bool AddRubbish(ENTITY.Rubbish rubbish)
        {
            string sql = "insert into Rubbish(deviceObj,rubbishReason,rubbishNumber,deprecitionMoney,rubbishDate,rubbishMemo) values(@deviceObj,@rubbishReason,@rubbishNumber,@deprecitionMoney,@rubbishDate,@rubbishMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceObj",SqlDbType.Int),
             new SqlParameter("@rubbishReason",SqlDbType.VarChar),
             new SqlParameter("@rubbishNumber",SqlDbType.Int),
             new SqlParameter("@deprecitionMoney",SqlDbType.Float),
             new SqlParameter("@rubbishDate",SqlDbType.DateTime),
             new SqlParameter("@rubbishMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = rubbish.deviceObj; //报废的设备
            parm[1].Value = rubbish.rubbishReason; //报废原因
            parm[2].Value = rubbish.rubbishNumber; //报废数量
            parm[3].Value = rubbish.deprecitionMoney; //折旧金额
            parm[4].Value = rubbish.rubbishDate; //报废日期
            parm[5].Value = rubbish.rubbishMemo; //备注信息

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据rubbishId获取某条报废设备记录*/
        public static ENTITY.Rubbish getSomeRubbish(int rubbishId)
        {
            /*构建查询sql*/
            string sql = "select * from Rubbish where rubbishId=" + rubbishId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Rubbish rubbish = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                rubbish = new ENTITY.Rubbish();
                rubbish.rubbishId = Convert.ToInt32(DataRead["rubbishId"]);
                rubbish.deviceObj = Convert.ToInt32(DataRead["deviceObj"]);
                rubbish.rubbishReason = DataRead["rubbishReason"].ToString();
                rubbish.rubbishNumber = Convert.ToInt32(DataRead["rubbishNumber"]);
                rubbish.deprecitionMoney = float.Parse(DataRead["deprecitionMoney"].ToString());
                rubbish.rubbishDate = Convert.ToDateTime(DataRead["rubbishDate"].ToString());
                rubbish.rubbishMemo = DataRead["rubbishMemo"].ToString();
            }
            return rubbish;
        }

        /*更新报废设备实现*/
        public static bool EditRubbish(ENTITY.Rubbish rubbish)
        {
            string sql = "update Rubbish set deviceObj=@deviceObj,rubbishReason=@rubbishReason,rubbishNumber=@rubbishNumber,deprecitionMoney=@deprecitionMoney,rubbishDate=@rubbishDate,rubbishMemo=@rubbishMemo where rubbishId=@rubbishId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceObj",SqlDbType.Int),
             new SqlParameter("@rubbishReason",SqlDbType.VarChar),
             new SqlParameter("@rubbishNumber",SqlDbType.Int),
             new SqlParameter("@deprecitionMoney",SqlDbType.Float),
             new SqlParameter("@rubbishDate",SqlDbType.DateTime),
             new SqlParameter("@rubbishMemo",SqlDbType.VarChar),
             new SqlParameter("@rubbishId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = rubbish.deviceObj;
            parm[1].Value = rubbish.rubbishReason;
            parm[2].Value = rubbish.rubbishNumber;
            parm[3].Value = rubbish.deprecitionMoney;
            parm[4].Value = rubbish.rubbishDate;
            parm[5].Value = rubbish.rubbishMemo;
            parm[6].Value = rubbish.rubbishId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除报废设备*/
        public static bool DelRubbish(string p)
        {
            string sql = "delete from Rubbish where rubbishId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询报废设备*/
        public static DataSet GetRubbish(string strWhere)
        {
            try
            {
                string strSql = "select * from Rubbish" + strWhere + " order by rubbishId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询报废设备*/
        public static System.Data.DataTable GetRubbish(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Rubbish";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "rubbishId", strShow, strSql, strWhere, " rubbishId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllRubbish()
        {
            try
            {
                string strSql = "select * from Rubbish";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
