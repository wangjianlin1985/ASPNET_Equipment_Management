using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�豸����ҵ���߼���*/
    public class bllDeviceLend{
        /*����豸����*/
        public static bool AddDeviceLend(ENTITY.DeviceLend deviceLend)
        {
            return DAL.dalDeviceLend.AddDeviceLend(deviceLend);
        }

        /*����lendId��ȡĳ���豸���ü�¼*/
        public static ENTITY.DeviceLend getSomeDeviceLend(int lendId)
        {
            return DAL.dalDeviceLend.getSomeDeviceLend(lendId);
        }

        /*�����豸����*/
        public static bool EditDeviceLend(ENTITY.DeviceLend deviceLend)
        {
            return DAL.dalDeviceLend.EditDeviceLend(deviceLend);
        }

        /*ɾ���豸����*/
        public static bool DelDeviceLend(string p)
        {
            return DAL.dalDeviceLend.DelDeviceLend(p);
        }

        /*��ѯ�豸����*/
        public static System.Data.DataSet GetDeviceLend(string strWhere)
        {
            return DAL.dalDeviceLend.GetDeviceLend(strWhere);
        }

        /*����������ҳ��ѯ�豸����*/
        public static System.Data.DataTable GetDeviceLend(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalDeviceLend.GetDeviceLend(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е��豸����*/
        public static System.Data.DataSet getAllDeviceLend()
        {
            return DAL.dalDeviceLend.getAllDeviceLend();
        }
    }
}
