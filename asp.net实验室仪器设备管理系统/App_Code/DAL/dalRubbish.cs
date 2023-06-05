using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�����豸ҵ���߼���ʵ��*/
    public class dalRubbish
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӱ����豸ʵ��*/
        public static bool AddRubbish(ENTITY.Rubbish rubbish)
        {
            string sql = "insert into Rubbish(deviceObj,rubbishReason,rubbishNumber,deprecitionMoney,rubbishDate,rubbishMemo) values(@deviceObj,@rubbishReason,@rubbishNumber,@deprecitionMoney,@rubbishDate,@rubbishMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceObj",SqlDbType.Int),
             new SqlParameter("@rubbishReason",SqlDbType.VarChar),
             new SqlParameter("@rubbishNumber",SqlDbType.Int),
             new SqlParameter("@deprecitionMoney",SqlDbType.Float),
             new SqlParameter("@rubbishDate",SqlDbType.DateTime),
             new SqlParameter("@rubbishMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = rubbish.deviceObj; //���ϵ��豸
            parm[1].Value = rubbish.rubbishReason; //����ԭ��
            parm[2].Value = rubbish.rubbishNumber; //��������
            parm[3].Value = rubbish.deprecitionMoney; //�۾ɽ��
            parm[4].Value = rubbish.rubbishDate; //��������
            parm[5].Value = rubbish.rubbishMemo; //��ע��Ϣ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����rubbishId��ȡĳ�������豸��¼*/
        public static ENTITY.Rubbish getSomeRubbish(int rubbishId)
        {
            /*������ѯsql*/
            string sql = "select * from Rubbish where rubbishId=" + rubbishId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Rubbish rubbish = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���±����豸ʵ��*/
        public static bool EditRubbish(ENTITY.Rubbish rubbish)
        {
            string sql = "update Rubbish set deviceObj=@deviceObj,rubbishReason=@rubbishReason,rubbishNumber=@rubbishNumber,deprecitionMoney=@deprecitionMoney,rubbishDate=@rubbishDate,rubbishMemo=@rubbishMemo where rubbishId=@rubbishId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@deviceObj",SqlDbType.Int),
             new SqlParameter("@rubbishReason",SqlDbType.VarChar),
             new SqlParameter("@rubbishNumber",SqlDbType.Int),
             new SqlParameter("@deprecitionMoney",SqlDbType.Float),
             new SqlParameter("@rubbishDate",SqlDbType.DateTime),
             new SqlParameter("@rubbishMemo",SqlDbType.VarChar),
             new SqlParameter("@rubbishId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = rubbish.deviceObj;
            parm[1].Value = rubbish.rubbishReason;
            parm[2].Value = rubbish.rubbishNumber;
            parm[3].Value = rubbish.deprecitionMoney;
            parm[4].Value = rubbish.rubbishDate;
            parm[5].Value = rubbish.rubbishMemo;
            parm[6].Value = rubbish.rubbishId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�������豸*/
        public static bool DelRubbish(string p)
        {
            string sql = "delete from Rubbish where rubbishId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�����豸*/
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

        /*��ѯ�����豸*/
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
