using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*设备借用业务逻辑层*/
    public class bllDeviceLend{
        /*添加设备借用*/
        public static bool AddDeviceLend(ENTITY.DeviceLend deviceLend)
        {
            return DAL.dalDeviceLend.AddDeviceLend(deviceLend);
        }

        /*根据lendId获取某条设备借用记录*/
        public static ENTITY.DeviceLend getSomeDeviceLend(int lendId)
        {
            return DAL.dalDeviceLend.getSomeDeviceLend(lendId);
        }

        /*更新设备借用*/
        public static bool EditDeviceLend(ENTITY.DeviceLend deviceLend)
        {
            return DAL.dalDeviceLend.EditDeviceLend(deviceLend);
        }

        /*删除设备借用*/
        public static bool DelDeviceLend(string p)
        {
            return DAL.dalDeviceLend.DelDeviceLend(p);
        }

        /*查询设备借用*/
        public static System.Data.DataSet GetDeviceLend(string strWhere)
        {
            return DAL.dalDeviceLend.GetDeviceLend(strWhere);
        }

        /*根据条件分页查询设备借用*/
        public static System.Data.DataTable GetDeviceLend(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalDeviceLend.GetDeviceLend(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的设备借用*/
        public static System.Data.DataSet getAllDeviceLend()
        {
            return DAL.dalDeviceLend.getAllDeviceLend();
        }
    }
}
