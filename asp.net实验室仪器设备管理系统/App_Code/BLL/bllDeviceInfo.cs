using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*设备业务逻辑层*/
    public class bllDeviceInfo{
        /*添加设备*/
        public static bool AddDeviceInfo(ENTITY.DeviceInfo deviceInfo)
        {
            return DAL.dalDeviceInfo.AddDeviceInfo(deviceInfo);
        }

        /*根据deviceId获取某条设备记录*/
        public static ENTITY.DeviceInfo getSomeDeviceInfo(int deviceId)
        {
            return DAL.dalDeviceInfo.getSomeDeviceInfo(deviceId);
        }

        /*更新设备*/
        public static bool EditDeviceInfo(ENTITY.DeviceInfo deviceInfo)
        {
            return DAL.dalDeviceInfo.EditDeviceInfo(deviceInfo);
        }

        /*删除设备*/
        public static bool DelDeviceInfo(string p)
        {
            return DAL.dalDeviceInfo.DelDeviceInfo(p);
        }

        /*查询设备*/
        public static System.Data.DataSet GetDeviceInfo(string strWhere)
        {
            return DAL.dalDeviceInfo.GetDeviceInfo(strWhere);
        }

        /*根据条件分页查询设备*/
        public static System.Data.DataTable GetDeviceInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalDeviceInfo.GetDeviceInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的设备*/
        public static System.Data.DataSet getAllDeviceInfo()
        {
            return DAL.dalDeviceInfo.getAllDeviceInfo();
        }
    }
}
