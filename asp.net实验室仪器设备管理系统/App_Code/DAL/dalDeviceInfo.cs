using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*设备业务逻辑层实现*/
    public class dalDeviceInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加设备实现*/
        public static bool AddDeviceInfo(ENTITY.DeviceInfo deviceInfo)
        {
            string sql = "insert into DeviceInfo(deviceName,deviceTypeObj,devicePhoto,deviceSign,deviceModel,madePlace,outDate,devicePrice,deviceNumber,deviceDesc) values(@deviceName,@deviceTypeObj,@devicePhoto,@deviceSign,@deviceModel,@madePlace,@outDate,@devicePrice,@deviceNumber,@deviceDesc)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceName",SqlDbType.VarChar),
             new SqlParameter("@deviceTypeObj",SqlDbType.Int),
             new SqlParameter("@devicePhoto",SqlDbType.VarChar),
             new SqlParameter("@deviceSign",SqlDbType.VarChar),
             new SqlParameter("@deviceModel",SqlDbType.VarChar),
             new SqlParameter("@madePlace",SqlDbType.VarChar),
             new SqlParameter("@outDate",SqlDbType.DateTime),
             new SqlParameter("@devicePrice",SqlDbType.Float),
             new SqlParameter("@deviceNumber",SqlDbType.Int),
             new SqlParameter("@deviceDesc",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = deviceInfo.deviceName; //设备名称
            parm[1].Value = deviceInfo.deviceTypeObj; //设备类型
            parm[2].Value = deviceInfo.devicePhoto; //设备图片
            parm[3].Value = deviceInfo.deviceSign; //设备品牌
            parm[4].Value = deviceInfo.deviceModel; //设备型号
            parm[5].Value = deviceInfo.madePlace; //生产厂家
            parm[6].Value = deviceInfo.outDate; //出厂日期
            parm[7].Value = deviceInfo.devicePrice; //设备价格
            parm[8].Value = deviceInfo.deviceNumber; //设备库存
            parm[9].Value = deviceInfo.deviceDesc; //设备描述

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据deviceId获取某条设备记录*/
        public static ENTITY.DeviceInfo getSomeDeviceInfo(int deviceId)
        {
            /*构建查询sql*/
            string sql = "select * from DeviceInfo where deviceId=" + deviceId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.DeviceInfo deviceInfo = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                deviceInfo = new ENTITY.DeviceInfo();
                deviceInfo.deviceId = Convert.ToInt32(DataRead["deviceId"]);
                deviceInfo.deviceName = DataRead["deviceName"].ToString();
                deviceInfo.deviceTypeObj = Convert.ToInt32(DataRead["deviceTypeObj"]);
                deviceInfo.devicePhoto = DataRead["devicePhoto"].ToString();
                deviceInfo.deviceSign = DataRead["deviceSign"].ToString();
                deviceInfo.deviceModel = DataRead["deviceModel"].ToString();
                deviceInfo.madePlace = DataRead["madePlace"].ToString();
                deviceInfo.outDate = Convert.ToDateTime(DataRead["outDate"].ToString());
                deviceInfo.devicePrice = float.Parse(DataRead["devicePrice"].ToString());
                deviceInfo.deviceNumber = Convert.ToInt32(DataRead["deviceNumber"]);
                deviceInfo.deviceDesc = DataRead["deviceDesc"].ToString();
            }
            return deviceInfo;
        }

        /*更新设备实现*/
        public static bool EditDeviceInfo(ENTITY.DeviceInfo deviceInfo)
        {
            string sql = "update DeviceInfo set deviceName=@deviceName,deviceTypeObj=@deviceTypeObj,devicePhoto=@devicePhoto,deviceSign=@deviceSign,deviceModel=@deviceModel,madePlace=@madePlace,outDate=@outDate,devicePrice=@devicePrice,deviceNumber=@deviceNumber,deviceDesc=@deviceDesc where deviceId=@deviceId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceName",SqlDbType.VarChar),
             new SqlParameter("@deviceTypeObj",SqlDbType.Int),
             new SqlParameter("@devicePhoto",SqlDbType.VarChar),
             new SqlParameter("@deviceSign",SqlDbType.VarChar),
             new SqlParameter("@deviceModel",SqlDbType.VarChar),
             new SqlParameter("@madePlace",SqlDbType.VarChar),
             new SqlParameter("@outDate",SqlDbType.DateTime),
             new SqlParameter("@devicePrice",SqlDbType.Float),
             new SqlParameter("@deviceNumber",SqlDbType.Int),
             new SqlParameter("@deviceDesc",SqlDbType.VarChar),
             new SqlParameter("@deviceId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = deviceInfo.deviceName;
            parm[1].Value = deviceInfo.deviceTypeObj;
            parm[2].Value = deviceInfo.devicePhoto;
            parm[3].Value = deviceInfo.deviceSign;
            parm[4].Value = deviceInfo.deviceModel;
            parm[5].Value = deviceInfo.madePlace;
            parm[6].Value = deviceInfo.outDate;
            parm[7].Value = deviceInfo.devicePrice;
            parm[8].Value = deviceInfo.deviceNumber;
            parm[9].Value = deviceInfo.deviceDesc;
            parm[10].Value = deviceInfo.deviceId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除设备*/
        public static bool DelDeviceInfo(string p)
        {
            string sql = "delete from DeviceInfo where deviceId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询设备*/
        public static DataSet GetDeviceInfo(string strWhere)
        {
            try
            {
                string strSql = "select * from DeviceInfo" + strWhere + " order by deviceId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询设备*/
        public static System.Data.DataTable GetDeviceInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from DeviceInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "deviceId", strShow, strSql, strWhere, " deviceId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllDeviceInfo()
        {
            try
            {
                string strSql = "select * from DeviceInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
