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
    ///DeviceInfo 的摘要说明：设备实体
    /// </summary>

    public class DeviceInfo
    {
        /*设备编号*/
        private int _deviceId;
        public int deviceId
        {
            get { return _deviceId; }
            set { _deviceId = value; }
        }

        /*设备名称*/
        private string _deviceName;
        public string deviceName
        {
            get { return _deviceName; }
            set { _deviceName = value; }
        }

        /*设备类型*/
        private int _deviceTypeObj;
        public int deviceTypeObj
        {
            get { return _deviceTypeObj; }
            set { _deviceTypeObj = value; }
        }

        /*设备图片*/
        private string _devicePhoto;
        public string devicePhoto
        {
            get { return _devicePhoto; }
            set { _devicePhoto = value; }
        }

        /*设备品牌*/
        private string _deviceSign;
        public string deviceSign
        {
            get { return _deviceSign; }
            set { _deviceSign = value; }
        }

        /*设备型号*/
        private string _deviceModel;
        public string deviceModel
        {
            get { return _deviceModel; }
            set { _deviceModel = value; }
        }

        /*生产厂家*/
        private string _madePlace;
        public string madePlace
        {
            get { return _madePlace; }
            set { _madePlace = value; }
        }

        /*出厂日期*/
        private DateTime _outDate;
        public DateTime outDate
        {
            get { return _outDate; }
            set { _outDate = value; }
        }

        /*设备价格*/
        private float _devicePrice;
        public float devicePrice
        {
            get { return _devicePrice; }
            set { _devicePrice = value; }
        }

        /*设备库存*/
        private int _deviceNumber;
        public int deviceNumber
        {
            get { return _deviceNumber; }
            set { _deviceNumber = value; }
        }

        /*设备描述*/
        private string _deviceDesc;
        public string deviceDesc
        {
            get { return _deviceDesc; }
            set { _deviceDesc = value; }
        }

    }
}
