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
    ///DeviceLend 的摘要说明：设备借用实体
    /// </summary>

    public class DeviceLend
    {
        /*借用编号*/
        private int _lendId;
        public int lendId
        {
            get { return _lendId; }
            set { _lendId = value; }
        }

        /*借用的设备*/
        private int _deviceObj;
        public int deviceObj
        {
            get { return _deviceObj; }
            set { _deviceObj = value; }
        }

        /*借用数量*/
        private int _lendNumber;
        public int lendNumber
        {
            get { return _lendNumber; }
            set { _lendNumber = value; }
        }

        /*借用日期*/
        private DateTime _lendDate;
        public DateTime lendDate
        {
            get { return _lendDate; }
            set { _lendDate = value; }
        }

        /*借用天数*/
        private float _lendDays;
        public float lendDays
        {
            get { return _lendDays; }
            set { _lendDays = value; }
        }

        /*归还时间*/
        private string _returnDate;
        public string returnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; }
        }

        /*借用人*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*备注信息*/
        private string _lendMemo;
        public string lendMemo
        {
            get { return _lendMemo; }
            set { _lendMemo = value; }
        }

    }
}
