using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�����豸ҵ���߼���*/
    public class bllRubbish{
        /*��ӱ����豸*/
        public static bool AddRubbish(ENTITY.Rubbish rubbish)
        {
            return DAL.dalRubbish.AddRubbish(rubbish);
        }

        /*����rubbishId��ȡĳ�������豸��¼*/
        public static ENTITY.Rubbish getSomeRubbish(int rubbishId)
        {
            return DAL.dalRubbish.getSomeRubbish(rubbishId);
        }

        /*���±����豸*/
        public static bool EditRubbish(ENTITY.Rubbish rubbish)
        {
            return DAL.dalRubbish.EditRubbish(rubbish);
        }

        /*ɾ�������豸*/
        public static bool DelRubbish(string p)
        {
            return DAL.dalRubbish.DelRubbish(p);
        }

        /*��ѯ�����豸*/
        public static System.Data.DataSet GetRubbish(string strWhere)
        {
            return DAL.dalRubbish.GetRubbish(strWhere);
        }

        /*����������ҳ��ѯ�����豸*/
        public static System.Data.DataTable GetRubbish(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalRubbish.GetRubbish(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еı����豸*/
        public static System.Data.DataSet getAllRubbish()
        {
            return DAL.dalRubbish.getAllRubbish();
        }
    }
}
