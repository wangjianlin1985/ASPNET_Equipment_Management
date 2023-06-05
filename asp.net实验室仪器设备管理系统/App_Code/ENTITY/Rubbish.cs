using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///Rubbish 的摘要说明：报废设备实体
    /// </summary>

    public class Rubbish
    {
        /*报废id*/
        private int _rubbishId;
        public int rubbishId
        {
            get { return _rubbishId; }
            set { _rubbishId = value; }
        }

        /*报废的设备*/
        private int _deviceObj;
        public int deviceObj
        {
            get { return _deviceObj; }
            set { _deviceObj = value; }
        }

        /*报废原因*/
        private string _rubbishReason;
        public string rubbishReason
        {
            get { return _rubbishReason; }
            set { _rubbishReason = value; }
        }

        /*报废数量*/
        private int _rubbishNumber;
        public int rubbishNumber
        {
            get { return _rubbishNumber; }
            set { _rubbishNumber = value; }
        }

        /*折旧金额*/
        private float _deprecitionMoney;
        public float deprecitionMoney
        {
            get { return _deprecitionMoney; }
            set { _deprecitionMoney = value; }
        }

        /*报废日期*/
        private DateTime _rubbishDate;
        public DateTime rubbishDate
        {
            get { return _rubbishDate; }
            set { _rubbishDate = value; }
        }

        /*备注信息*/
        private string _rubbishMemo;
        public string rubbishMemo
        {
            get { return _rubbishMemo; }
            set { _rubbishMemo = value; }
        }

    }
}
