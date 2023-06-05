using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�豸���ҵ���߼���ʵ��*/
    public class dalDeviceType
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*����豸���ʵ��*/
        public static bool AddDeviceType(ENTITY.DeviceType deviceType)
        {
            string sql = "insert into DeviceType(deviceTypeName) values(@deviceTypeName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceTypeName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = deviceType.deviceTypeName; //�豸�������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����deviceTypeId��ȡĳ���豸����¼*/
        public static ENTITY.DeviceType getSomeDeviceType(int deviceTypeId)
        {
            /*������ѯsql*/
            string sql = "select * from DeviceType where deviceTypeId=" + deviceTypeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.DeviceType deviceType = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                deviceType = new ENTITY.DeviceType();
                deviceType.deviceTypeId = Convert.ToInt32(DataRead["deviceTypeId"]);
                deviceType.deviceTypeName = DataRead["deviceTypeName"].ToString();
            }
            return deviceType;
        }

        /*�����豸���ʵ��*/
        public static bool EditDeviceType(ENTITY.DeviceType deviceType)
        {
            string sql = "update DeviceType set deviceTypeName=@deviceTypeName where deviceTypeId=@deviceTypeId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceTypeName",SqlDbType.VarChar),
             new SqlParameter("@deviceTypeId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = deviceType.deviceTypeName;
            parm[1].Value = deviceType.deviceTypeId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���豸���*/
        public static bool DelDeviceType(string p)
        {
            string sql = "delete from DeviceType where deviceTypeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�豸���*/
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

        /*��ѯ�豸���*/
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
