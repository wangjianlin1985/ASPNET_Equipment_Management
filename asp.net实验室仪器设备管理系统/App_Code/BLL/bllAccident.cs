using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�豸�¹�ҵ���߼���*/
    public class bllAccident{
        /*����豸�¹�*/
        public static bool AddAccident(ENTITY.Accident accident)
        {
            return DAL.dalAccident.AddAccident(accident);
        }

        /*����accidentId��ȡĳ���豸�¹ʼ�¼*/
        public static ENTITY.Accident getSomeAccident(int accidentId)
        {
            return DAL.dalAccident.getSomeAccident(accidentId);
        }

        /*�����豸�¹�*/
        public static bool EditAccident(ENTITY.Accident accident)
        {
            return DAL.dalAccident.EditAccident(accident);
        }

        /*ɾ���豸�¹�*/
        public static bool DelAccident(string p)
        {
            return DAL.dalAccident.DelAccident(p);
        }

        /*��ѯ�豸�¹�*/
        public static System.Data.DataSet GetAccident(string strWhere)
        {
            return DAL.dalAccident.GetAccident(strWhere);
        }

        /*����������ҳ��ѯ�豸�¹�*/
        public static System.Data.DataTable GetAccident(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalAccident.GetAccident(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е��豸�¹�*/
        public static System.Data.DataSet getAllAccident()
        {
            return DAL.dalAccident.getAllAccident();
        }
    }
}
