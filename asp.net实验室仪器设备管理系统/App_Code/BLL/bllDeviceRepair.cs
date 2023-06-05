using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�豸ά��ҵ���߼���*/
    public class bllDeviceRepair{
        /*����豸ά��*/
        public static bool AddDeviceRepair(ENTITY.DeviceRepair deviceRepair)
        {
            return DAL.dalDeviceRepair.AddDeviceRepair(deviceRepair);
        }

        /*����repairId��ȡĳ���豸ά�޼�¼*/
        public static ENTITY.DeviceRepair getSomeDeviceRepair(int repairId)
        {
            return DAL.dalDeviceRepair.getSomeDeviceRepair(repairId);
        }

        /*�����豸ά��*/
        public static bool EditDeviceRepair(ENTITY.DeviceRepair deviceRepair)
        {
            return DAL.dalDeviceRepair.EditDeviceRepair(deviceRepair);
        }

        /*ɾ���豸ά��*/
        public static bool DelDeviceRepair(string p)
        {
            return DAL.dalDeviceRepair.DelDeviceRepair(p);
        }

        /*��ѯ�豸ά��*/
        public static System.Data.DataSet GetDeviceRepair(string strWhere)
        {
            return DAL.dalDeviceRepair.GetDeviceRepair(strWhere);
        }

        /*����������ҳ��ѯ�豸ά��*/
        public static System.Data.DataTable GetDeviceRepair(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalDeviceRepair.GetDeviceRepair(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е��豸ά��*/
        public static System.Data.DataSet getAllDeviceRepair()
        {
            return DAL.dalDeviceRepair.getAllDeviceRepair();
        }
    }
}
