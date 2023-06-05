using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*设备维修业务逻辑层*/
    public class bllDeviceRepair{
        /*添加设备维修*/
        public static bool AddDeviceRepair(ENTITY.DeviceRepair deviceRepair)
        {
            return DAL.dalDeviceRepair.AddDeviceRepair(deviceRepair);
        }

        /*根据repairId获取某条设备维修记录*/
        public static ENTITY.DeviceRepair getSomeDeviceRepair(int repairId)
        {
            return DAL.dalDeviceRepair.getSomeDeviceRepair(repairId);
        }

        /*更新设备维修*/
        public static bool EditDeviceRepair(ENTITY.DeviceRepair deviceRepair)
        {
            return DAL.dalDeviceRepair.EditDeviceRepair(deviceRepair);
        }

        /*删除设备维修*/
        public static bool DelDeviceRepair(string p)
        {
            return DAL.dalDeviceRepair.DelDeviceRepair(p);
        }

        /*查询设备维修*/
        public static System.Data.DataSet GetDeviceRepair(string strWhere)
        {
            return DAL.dalDeviceRepair.GetDeviceRepair(strWhere);
        }

        /*根据条件分页查询设备维修*/
        public static System.Data.DataTable GetDeviceRepair(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalDeviceRepair.GetDeviceRepair(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的设备维修*/
        public static System.Data.DataSet getAllDeviceRepair()
        {
            return DAL.dalDeviceRepair.getAllDeviceRepair();
        }
    }
}
