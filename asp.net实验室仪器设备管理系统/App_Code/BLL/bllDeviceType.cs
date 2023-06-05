using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*设备类别业务逻辑层*/
    public class bllDeviceType{
        /*添加设备类别*/
        public static bool AddDeviceType(ENTITY.DeviceType deviceType)
        {
            return DAL.dalDeviceType.AddDeviceType(deviceType);
        }

        /*根据deviceTypeId获取某条设备类别记录*/
        public static ENTITY.DeviceType getSomeDeviceType(int deviceTypeId)
        {
            return DAL.dalDeviceType.getSomeDeviceType(deviceTypeId);
        }

        /*更新设备类别*/
        public static bool EditDeviceType(ENTITY.DeviceType deviceType)
        {
            return DAL.dalDeviceType.EditDeviceType(deviceType);
        }

        /*删除设备类别*/
        public static bool DelDeviceType(string p)
        {
            return DAL.dalDeviceType.DelDeviceType(p);
        }

        /*查询设备类别*/
        public static System.Data.DataSet GetDeviceType(string strWhere)
        {
            return DAL.dalDeviceType.GetDeviceType(strWhere);
        }

        /*根据条件分页查询设备类别*/
        public static System.Data.DataTable GetDeviceType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalDeviceType.GetDeviceType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的设备类别*/
        public static System.Data.DataSet getAllDeviceType()
        {
            return DAL.dalDeviceType.getAllDeviceType();
        }
    }
}
