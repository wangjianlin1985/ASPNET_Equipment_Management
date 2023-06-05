using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�豸���ҵ���߼���*/
    public class bllDeviceType{
        /*����豸���*/
        public static bool AddDeviceType(ENTITY.DeviceType deviceType)
        {
            return DAL.dalDeviceType.AddDeviceType(deviceType);
        }

        /*����deviceTypeId��ȡĳ���豸����¼*/
        public static ENTITY.DeviceType getSomeDeviceType(int deviceTypeId)
        {
            return DAL.dalDeviceType.getSomeDeviceType(deviceTypeId);
        }

        /*�����豸���*/
        public static bool EditDeviceType(ENTITY.DeviceType deviceType)
        {
            return DAL.dalDeviceType.EditDeviceType(deviceType);
        }

        /*ɾ���豸���*/
        public static bool DelDeviceType(string p)
        {
            return DAL.dalDeviceType.DelDeviceType(p);
        }

        /*��ѯ�豸���*/
        public static System.Data.DataSet GetDeviceType(string strWhere)
        {
            return DAL.dalDeviceType.GetDeviceType(strWhere);
        }

        /*����������ҳ��ѯ�豸���*/
        public static System.Data.DataTable GetDeviceType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalDeviceType.GetDeviceType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е��豸���*/
        public static System.Data.DataSet getAllDeviceType()
        {
            return DAL.dalDeviceType.getAllDeviceType();
        }
    }
}
