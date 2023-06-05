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
    ///DeviceInfo ��ժҪ˵�����豸ʵ��
    /// </summary>

    public class DeviceInfo
    {
        /*�豸���*/
        private int _deviceId;
        public int deviceId
        {
            get { return _deviceId; }
            set { _deviceId = value; }
        }

        /*�豸����*/
        private string _deviceName;
        public string deviceName
        {
            get { return _deviceName; }
            set { _deviceName = value; }
        }

        /*�豸����*/
        private int _deviceTypeObj;
        public int deviceTypeObj
        {
            get { return _deviceTypeObj; }
            set { _deviceTypeObj = value; }
        }

        /*�豸ͼƬ*/
        private string _devicePhoto;
        public string devicePhoto
        {
            get { return _devicePhoto; }
            set { _devicePhoto = value; }
        }

        /*�豸Ʒ��*/
        private string _deviceSign;
        public string deviceSign
        {
            get { return _deviceSign; }
            set { _deviceSign = value; }
        }

        /*�豸�ͺ�*/
        private string _deviceModel;
        public string deviceModel
        {
            get { return _deviceModel; }
            set { _deviceModel = value; }
        }

        /*��������*/
        private string _madePlace;
        public string madePlace
        {
            get { return _madePlace; }
            set { _madePlace = value; }
        }

        /*��������*/
        private DateTime _outDate;
        public DateTime outDate
        {
            get { return _outDate; }
            set { _outDate = value; }
        }

        /*�豸�۸�*/
        private float _devicePrice;
        public float devicePrice
        {
            get { return _devicePrice; }
            set { _devicePrice = value; }
        }

        /*�豸���*/
        private int _deviceNumber;
        public int deviceNumber
        {
            get { return _deviceNumber; }
            set { _deviceNumber = value; }
        }

        /*�豸����*/
        private string _deviceDesc;
        public string deviceDesc
        {
            get { return _deviceDesc; }
            set { _deviceDesc = value; }
        }

    }
}
