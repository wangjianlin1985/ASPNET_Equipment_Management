using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�豸�¹�ҵ���߼���ʵ��*/
    public class dalAccident
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*����豸�¹�ʵ��*/
        public static bool AddAccident(ENTITY.Accident accident)
        {
            string sql = "insert into Accident(deviceObj,reason,accidentContent,accidentTime,userObj) values(@deviceObj,@reason,@accidentContent,@accidentTime,@userObj)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceObj",SqlDbType.Int),
             new SqlParameter("@reason",SqlDbType.VarChar),
             new SqlParameter("@accidentContent",SqlDbType.VarChar),
             new SqlParameter("@accidentTime",SqlDbType.DateTime),
             new SqlParameter("@userObj",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = accident.deviceObj; //�¹ʵ��豸
            parm[1].Value = accident.reason; //�¹�ԭ��
            parm[2].Value = accident.accidentContent; //�¹�����
            parm[3].Value = accident.accidentTime; //�¹�ʱ��
            parm[4].Value = accident.userObj; //�ϱ����û�

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����accidentId��ȡĳ���豸�¹ʼ�¼*/
        public static ENTITY.Accident getSomeAccident(int accidentId)
        {
            /*������ѯsql*/
            string sql = "select * from Accident where accidentId=" + accidentId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Accident accident = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*�����豸�¹�ʵ��*/
        public static bool EditAccident(ENTITY.Accident accident)
        {
            string sql = "update Accident set deviceObj=@deviceObj,reason=@reason,accidentContent=@accidentContent,accidentTime=@accidentTime,userObj=@userObj where accidentId=@accidentId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceObj",SqlDbType.Int),
             new SqlParameter("@reason",SqlDbType.VarChar),
             new SqlParameter("@accidentContent",SqlDbType.VarChar),
             new SqlParameter("@accidentTime",SqlDbType.DateTime),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@accidentId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = accident.deviceObj;
            parm[1].Value = accident.reason;
            parm[2].Value = accident.accidentContent;
            parm[3].Value = accident.accidentTime;
            parm[4].Value = accident.userObj;
            parm[5].Value = accident.accidentId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���豸�¹�*/
        public static bool DelAccident(string p)
        {
            string sql = "delete from Accident where accidentId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�豸�¹�*/
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

        /*��ѯ�豸�¹�*/
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
