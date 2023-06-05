using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�豸ҵ���߼���*/
    public class bllDeviceInfo{
        /*����豸*/
        public static bool AddDeviceInfo(ENTITY.DeviceInfo deviceInfo)
        {
            return DAL.dalDeviceInfo.AddDeviceInfo(deviceInfo);
        }

        /*����deviceId��ȡĳ���豸��¼*/
        public static ENTITY.DeviceInfo getSomeDeviceInfo(int deviceId)
        {
            return DAL.dalDeviceInfo.getSomeDeviceInfo(deviceId);
        }

        /*�����豸*/
        public static bool EditDeviceInfo(ENTITY.DeviceInfo deviceInfo)
        {
            return DAL.dalDeviceInfo.EditDeviceInfo(deviceInfo);
        }

        /*ɾ���豸*/
        public static bool DelDeviceInfo(string p)
        {
            return DAL.dalDeviceInfo.DelDeviceInfo(p);
        }

        /*��ѯ�豸*/
        public static System.Data.DataSet GetDeviceInfo(string strWhere)
        {
            return DAL.dalDeviceInfo.GetDeviceInfo(strWhere);
        }

        /*����������ҳ��ѯ�豸*/
        public static System.Data.DataTable GetDeviceInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalDeviceInfo.GetDeviceInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е��豸*/
        public static System.Data.DataSet getAllDeviceInfo()
        {
            return DAL.dalDeviceInfo.getAllDeviceInfo();
        }
    }
}
