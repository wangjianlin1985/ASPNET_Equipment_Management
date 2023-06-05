using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*设备维修业务逻辑层实现*/
    public class dalDeviceRepair
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加设备维修实现*/
        public static bool AddDeviceRepair(ENTITY.DeviceRepair deviceRepair)
        {
            string sql = "insert into DeviceRepair(deviceObj,errorReason,repairNumber,repairDate,repairPalce,repairMan,repairTime,repairMoney,repairMemo) values(@deviceObj,@errorReason,@repairNumber,@repairDate,@repairPalce,@repairMan,@repairTime,@repairMoney,@repairMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceObj",SqlDbType.Int),
             new SqlParameter("@errorReason",SqlDbType.VarChar),
             new SqlParameter("@repairNumber",SqlDbType.Int),
             new SqlParameter("@repairDate",SqlDbType.DateTime),
             new SqlParameter("@repairPalce",SqlDbType.VarChar),
             new SqlParameter("@repairMan",SqlDbType.VarChar),
             new SqlParameter("@repairTime",SqlDbType.VarChar),
             new SqlParameter("@repairMoney",SqlDbType.Float),
             new SqlParameter("@repairMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = deviceRepair.deviceObj; //损坏的设备
            parm[1].Value = deviceRepair.errorReason; //故障原因
            parm[2].Value = deviceRepair.repairNumber; //故障数量
            parm[3].Value = deviceRepair.repairDate; //送修日期
            parm[4].Value = deviceRepair.repairPalce; //送修地点
            parm[5].Value = deviceRepair.repairMan; //维修人
            parm[6].Value = deviceRepair.repairTime; //维修工时
            parm[7].Value = deviceRepair.repairMoney; //维修费用
            parm[8].Value = deviceRepair.repairMemo; //备注信息

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据repairId获取某条设备维修记录*/
        public static ENTITY.DeviceRepair getSomeDeviceRepair(int repairId)
        {
            /*构建查询sql*/
            string sql = "select * from DeviceRepair where repairId=" + repairId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.DeviceRepair deviceRepair = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                deviceRepair = new ENTITY.DeviceRepair();
                deviceRepair.repairId = Convert.ToInt32(DataRead["repairId"]);
                deviceRepair.deviceObj = Convert.ToInt32(DataRead["deviceObj"]);
                deviceRepair.errorReason = DataRead["errorReason"].ToString();
                deviceRepair.repairNumber = Convert.ToInt32(DataRead["repairNumber"]);
                deviceRepair.repairDate = Convert.ToDateTime(DataRead["repairDate"].ToString());
                deviceRepair.repairPalce = DataRead["repairPalce"].ToString();
                deviceRepair.repairMan = DataRead["repairMan"].ToString();
                deviceRepair.repairTime = DataRead["repairTime"].ToString();
                deviceRepair.repairMoney = float.Parse(DataRead["repairMoney"].ToString());
                deviceRepair.repairMemo = DataRead["repairMemo"].ToString();
            }
            return deviceRepair;
        }

        /*更新设备维修实现*/
        public static bool EditDeviceRepair(ENTITY.DeviceRepair deviceRepair)
        {
            string sql = "update DeviceRepair set deviceObj=@deviceObj,errorReason=@errorReason,repairNumber=@repairNumber,repairDate=@repairDate,repairPalce=@repairPalce,repairMan=@repairMan,repairTime=@repairTime,repairMoney=@repairMoney,repairMemo=@repairMemo where repairId=@repairId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceObj",SqlDbType.Int),
             new SqlParameter("@errorReason",SqlDbType.VarChar),
             new SqlParameter("@repairNumber",SqlDbType.Int),
             new SqlParameter("@repairDate",SqlDbType.DateTime),
             new SqlParameter("@repairPalce",SqlDbType.VarChar),
             new SqlParameter("@repairMan",SqlDbType.VarChar),
             new SqlParameter("@repairTime",SqlDbType.VarChar),
             new SqlParameter("@repairMoney",SqlDbType.Float),
             new SqlParameter("@repairMemo",SqlDbType.VarChar),
             new SqlParameter("@repairId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = deviceRepair.deviceObj;
            parm[1].Value = deviceRepair.errorReason;
            parm[2].Value = deviceRepair.repairNumber;
            parm[3].Value = deviceRepair.repairDate;
            parm[4].Value = deviceRepair.repairPalce;
            parm[5].Value = deviceRepair.repairMan;
            parm[6].Value = deviceRepair.repairTime;
            parm[7].Value = deviceRepair.repairMoney;
            parm[8].Value = deviceRepair.repairMemo;
            parm[9].Value = deviceRepair.repairId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除设备维修*/
        public static bool DelDeviceRepair(string p)
        {
            string sql = "delete from DeviceRepair where repairId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询设备维修*/
        public static DataSet GetDeviceRepair(string strWhere)
        {
            try
            {
                string strSql = "select * from DeviceRepair" + strWhere + " order by repairId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询设备维修*/
        public static System.Data.DataTable GetDeviceRepair(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from DeviceRepair";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "repairId", strShow, strSql, strWhere, " repairId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllDeviceRepair()
        {
            try
            {
                string strSql = "select * from DeviceRepair";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
