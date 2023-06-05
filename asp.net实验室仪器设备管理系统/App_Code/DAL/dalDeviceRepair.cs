using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�豸ά��ҵ���߼���ʵ��*/
    public class dalDeviceRepair
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*����豸ά��ʵ��*/
        public static bool AddDeviceRepair(ENTITY.DeviceRepair deviceRepair)
        {
            string sql = "insert into DeviceRepair(deviceObj,errorReason,repairNumber,repairDate,repairPalce,repairMan,repairTime,repairMoney,repairMemo) values(@deviceObj,@errorReason,@repairNumber,@repairDate,@repairPalce,@repairMan,@repairTime,@repairMoney,@repairMemo)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = deviceRepair.deviceObj; //�𻵵��豸
            parm[1].Value = deviceRepair.errorReason; //����ԭ��
            parm[2].Value = deviceRepair.repairNumber; //��������
            parm[3].Value = deviceRepair.repairDate; //��������
            parm[4].Value = deviceRepair.repairPalce; //���޵ص�
            parm[5].Value = deviceRepair.repairMan; //ά����
            parm[6].Value = deviceRepair.repairTime; //ά�޹�ʱ
            parm[7].Value = deviceRepair.repairMoney; //ά�޷���
            parm[8].Value = deviceRepair.repairMemo; //��ע��Ϣ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����repairId��ȡĳ���豸ά�޼�¼*/
        public static ENTITY.DeviceRepair getSomeDeviceRepair(int repairId)
        {
            /*������ѯsql*/
            string sql = "select * from DeviceRepair where repairId=" + repairId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.DeviceRepair deviceRepair = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*�����豸ά��ʵ��*/
        public static bool EditDeviceRepair(ENTITY.DeviceRepair deviceRepair)
        {
            string sql = "update DeviceRepair set deviceObj=@deviceObj,errorReason=@errorReason,repairNumber=@repairNumber,repairDate=@repairDate,repairPalce=@repairPalce,repairMan=@repairMan,repairTime=@repairTime,repairMoney=@repairMoney,repairMemo=@repairMemo where repairId=@repairId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
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
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���豸ά��*/
        public static bool DelDeviceRepair(string p)
        {
            string sql = "delete from DeviceRepair where repairId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�豸ά��*/
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

        /*��ѯ�豸ά��*/
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
