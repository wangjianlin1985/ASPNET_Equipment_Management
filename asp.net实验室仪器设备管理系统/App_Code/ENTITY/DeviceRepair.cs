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
    ///DeviceRepair 的摘要说明：设备维修实体
    /// </summary>

    public class DeviceRepair
    {
        /*维修编号*/
        private int _repairId;
        public int repairId
        {
            get { return _repairId; }
            set { _repairId = value; }
        }

        /*损坏的设备*/
        private int _deviceObj;
        public int deviceObj
        {
            get { return _deviceObj; }
            set { _deviceObj = value; }
        }

        /*故障原因*/
        private string _errorReason;
        public string errorReason
        {
            get { return _errorReason; }
            set { _errorReason = value; }
        }

        /*故障数量*/
        private int _repairNumber;
        public int repairNumber
        {
            get { return _repairNumber; }
            set { _repairNumber = value; }
        }

        /*送修日期*/
        private DateTime _repairDate;
        public DateTime repairDate
        {
            get { return _repairDate; }
            set { _repairDate = value; }
        }

        /*送修地点*/
        private string _repairPalce;
        public string repairPalce
        {
            get { return _repairPalce; }
            set { _repairPalce = value; }
        }

        /*维修人*/
        private string _repairMan;
        public string repairMan
        {
            get { return _repairMan; }
            set { _repairMan = value; }
        }

        /*维修工时*/
        private string _repairTime;
        public string repairTime
        {
            get { return _repairTime; }
            set { _repairTime = value; }
        }

        /*维修费用*/
        private float _repairMoney;
        public float repairMoney
        {
            get { return _repairMoney; }
            set { _repairMoney = value; }
        }

        /*备注信息*/
        private string _repairMemo;
        public string repairMemo
        {
            get { return _repairMemo; }
            set { _repairMemo = value; }
        }

    }
}
