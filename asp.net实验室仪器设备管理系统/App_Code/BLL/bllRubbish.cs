using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*报废设备业务逻辑层*/
    public class bllRubbish{
        /*添加报废设备*/
        public static bool AddRubbish(ENTITY.Rubbish rubbish)
        {
            return DAL.dalRubbish.AddRubbish(rubbish);
        }

        /*根据rubbishId获取某条报废设备记录*/
        public static ENTITY.Rubbish getSomeRubbish(int rubbishId)
        {
            return DAL.dalRubbish.getSomeRubbish(rubbishId);
        }

        /*更新报废设备*/
        public static bool EditRubbish(ENTITY.Rubbish rubbish)
        {
            return DAL.dalRubbish.EditRubbish(rubbish);
        }

        /*删除报废设备*/
        public static bool DelRubbish(string p)
        {
            return DAL.dalRubbish.DelRubbish(p);
        }

        /*查询报废设备*/
        public static System.Data.DataSet GetRubbish(string strWhere)
        {
            return DAL.dalRubbish.GetRubbish(strWhere);
        }

        /*根据条件分页查询报废设备*/
        public static System.Data.DataTable GetRubbish(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalRubbish.GetRubbish(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的报废设备*/
        public static System.Data.DataSet getAllRubbish()
        {
            return DAL.dalRubbish.getAllRubbish();
        }
    }
}
