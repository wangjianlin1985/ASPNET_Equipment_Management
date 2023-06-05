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
    ///Accident 的摘要说明：设备事故实体
    /// </summary>

    public class Accident
    {
        /*事故id*/
        private int _accidentId;
        public int accidentId
        {
            get { return _accidentId; }
            set { _accidentId = value; }
        }

        /*事故的设备*/
        private int _deviceObj;
        public int deviceObj
        {
            get { return _deviceObj; }
            set { _deviceObj = value; }
        }

        /*事故原因*/
        private string _reason;
        public string reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        /*事故内容*/
        private string _accidentContent;
        public string accidentContent
        {
            get { return _accidentContent; }
            set { _accidentContent = value; }
        }

        /*事故时间*/
        private DateTime _accidentTime;
        public DateTime accidentTime
        {
            get { return _accidentTime; }
            set { _accidentTime = value; }
        }

        /*上报的用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

    }
}
