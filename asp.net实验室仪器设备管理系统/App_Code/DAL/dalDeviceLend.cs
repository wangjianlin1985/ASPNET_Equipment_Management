using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�豸����ҵ���߼���ʵ��*/
    public class dalDeviceLend
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*����豸����ʵ��*/
        public static bool AddDeviceLend(ENTITY.DeviceLend deviceLend)
        {
            string sql = "insert into DeviceLend(deviceObj,lendNumber,lendDate,lendDays,returnDate,userObj,lendMemo) values(@deviceObj,@lendNumber,@lendDate,@lendDays,@returnDate,@userObj,@lendMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceObj",SqlDbType.Int),
             new SqlParameter("@lendNumber",SqlDbType.Int),
             new SqlParameter("@lendDate",SqlDbType.DateTime),
             new SqlParameter("@lendDays",SqlDbType.Float),
             new SqlParameter("@returnDate",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@lendMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = deviceLend.deviceObj; //���õ��豸
            parm[1].Value = deviceLend.lendNumber; //��������
            parm[2].Value = deviceLend.lendDate; //��������
            parm[3].Value = deviceLend.lendDays; //��������
            parm[4].Value = deviceLend.returnDate; //�黹ʱ��
            parm[5].Value = deviceLend.userObj; //������
            parm[6].Value = deviceLend.lendMemo; //��ע��Ϣ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����lendId��ȡĳ���豸���ü�¼*/
        public static ENTITY.DeviceLend getSomeDeviceLend(int lendId)
        {
            /*������ѯsql*/
            string sql = "select * from DeviceLend where lendId=" + lendId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.DeviceLend deviceLend = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*�����豸����ʵ��*/
        public static bool EditDeviceLend(ENTITY.DeviceLend deviceLend)
        {
            string sql = "update DeviceLend set deviceObj=@deviceObj,lendNumber=@lendNumber,lendDate=@lendDate,lendDays=@lendDays,returnDate=@returnDate,userObj=@userObj,lendMemo=@lendMemo where lendId=@lendId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
            parm[0].Value = deviceLend.deviceObj;
            parm[1].Value = deviceLend.lendNumber;
            parm[2].Value = deviceLend.lendDate;
            parm[3].Value = deviceLend.lendDays;
            parm[4].Value = deviceLend.returnDate;
            parm[5].Value = deviceLend.userObj;
            parm[6].Value = deviceLend.lendMemo;
            parm[7].Value = deviceLend.lendId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���豸����*/
        public static bool DelDeviceLend(string p)
        {
            string sql = "delete from DeviceLend where lendId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�豸����*/
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

        /*��ѯ�豸����*/
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
