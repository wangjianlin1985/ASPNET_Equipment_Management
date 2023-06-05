using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*设备事故业务逻辑层*/
    public class bllAccident{
        /*添加设备事故*/
        public static bool AddAccident(ENTITY.Accident accident)
        {
            return DAL.dalAccident.AddAccident(accident);
        }

        /*根据accidentId获取某条设备事故记录*/
        public static ENTITY.Accident getSomeAccident(int accidentId)
        {
            return DAL.dalAccident.getSomeAccident(accidentId);
        }

        /*更新设备事故*/
        public static bool EditAccident(ENTITY.Accident accident)
        {
            return DAL.dalAccident.EditAccident(accident);
        }

        /*删除设备事故*/
        public static bool DelAccident(string p)
        {
            return DAL.dalAccident.DelAccident(p);
        }

        /*查询设备事故*/
        public static System.Data.DataSet GetAccident(string strWhere)
        {
            return DAL.dalAccident.GetAccident(strWhere);
        }

        /*根据条件分页查询设备事故*/
        public static System.Data.DataTable GetAccident(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalAccident.GetAccident(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的设备事故*/
        public static System.Data.DataSet getAllAccident()
        {
            return DAL.dalAccident.getAllAccident();
        }
    }
}
