using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*设备类别业务逻辑层实现*/
    public class dalDeviceType
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加设备类别实现*/
        public static bool AddDeviceType(ENTITY.DeviceType deviceType)
        {
            string sql = "insert into DeviceType(deviceTypeName) values(@deviceTypeName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceTypeName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = deviceType.deviceTypeName; //设备类别名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据deviceTypeId获取某条设备类别记录*/
        public static ENTITY.DeviceType getSomeDeviceType(int deviceTypeId)
        {
            /*构建查询sql*/
            string sql = "select * from DeviceType where deviceTypeId=" + deviceTypeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.DeviceType deviceType = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                deviceType = new ENTITY.DeviceType();
                deviceType.deviceTypeId = Convert.ToInt32(DataRead["deviceTypeId"]);
                deviceType.deviceTypeName = DataRead["deviceTypeName"].ToString();
            }
            return deviceType;
        }

        /*更新设备类别实现*/
        public static bool EditDeviceType(ENTITY.DeviceType deviceType)
        {
            string sql = "update DeviceType set deviceTypeName=@deviceTypeName where deviceTypeId=@deviceTypeId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceTypeName",SqlDbType.VarChar),
             new SqlParameter("@deviceTypeId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = deviceType.deviceTypeName;
            parm[1].Value = deviceType.deviceTypeId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除设备类别*/
        public static bool DelDeviceType(string p)
        {
            string sql = "delete from DeviceType where deviceTypeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询设备类别*/
        public static DataSet GetDeviceType(string strWhere)
        {
            try
            {
                string strSql = "select * from DeviceType" + strWhere + " order by deviceTypeId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询设备类别*/
        public static System.Data.DataTable GetDeviceType(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from DeviceType";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "deviceTypeId", strShow, strSql, strWhere, " deviceTypeId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllDeviceType()
        {
            try
            {
                string strSql = "select * from DeviceType";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
