using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�豸ҵ���߼���ʵ��*/
    public class dalDeviceInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*����豸ʵ��*/
        public static bool AddDeviceInfo(ENTITY.DeviceInfo deviceInfo)
        {
            string sql = "insert into DeviceInfo(deviceName,deviceTypeObj,devicePhoto,deviceSign,deviceModel,madePlace,outDate,devicePrice,deviceNumber,deviceDesc) values(@deviceName,@deviceTypeObj,@devicePhoto,@deviceSign,@deviceModel,@madePlace,@outDate,@devicePrice,@deviceNumber,@deviceDesc)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = deviceInfo.deviceName; //�豸����
            parm[1].Value = deviceInfo.deviceTypeObj; //�豸����
            parm[2].Value = deviceInfo.devicePhoto; //�豸ͼƬ
            parm[3].Value = deviceInfo.deviceSign; //�豸Ʒ��
            parm[4].Value = deviceInfo.deviceModel; //�豸�ͺ�
            parm[5].Value = deviceInfo.madePlace; //��������
            parm[6].Value = deviceInfo.outDate; //��������
            parm[7].Value = deviceInfo.devicePrice; //�豸�۸�
            parm[8].Value = deviceInfo.deviceNumber; //�豸���
            parm[9].Value = deviceInfo.deviceDesc; //�豸����

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����deviceId��ȡĳ���豸��¼*/
        public static ENTITY.DeviceInfo getSomeDeviceInfo(int deviceId)
        {
            /*������ѯsql*/
            string sql = "select * from DeviceInfo where deviceId=" + deviceId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.DeviceInfo deviceInfo = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*�����豸ʵ��*/
        public static bool EditDeviceInfo(ENTITY.DeviceInfo deviceInfo)
        {
            string sql = "update DeviceInfo set deviceName=@deviceName,deviceTypeObj=@deviceTypeObj,devicePhoto=@devicePhoto,deviceSign=@deviceSign,deviceModel=@deviceModel,madePlace=@madePlace,outDate=@outDate,devicePrice=@devicePrice,deviceNumber=@deviceNumber,deviceDesc=@deviceDesc where deviceId=@deviceId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
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
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���豸*/
        public static bool DelDeviceInfo(string p)
        {
            string sql = "delete from DeviceInfo where deviceId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�豸*/
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

        /*��ѯ�豸*/
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
