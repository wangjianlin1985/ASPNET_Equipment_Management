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
    ///DeviceLend ��ժҪ˵�����豸����ʵ��
    /// </summary>

    public class DeviceLend
    {
        /*���ñ��*/
        private int _lendId;
        public int lendId
        {
            get { return _lendId; }
            set { _lendId = value; }
        }

        /*���õ��豸*/
        private int _deviceObj;
        public int deviceObj
        {
            get { return _deviceObj; }
            set { _deviceObj = value; }
        }

        /*��������*/
        private int _lendNumber;
        public int lendNumber
        {
            get { return _lendNumber; }
            set { _lendNumber = value; }
        }

        /*��������*/
        private DateTime _lendDate;
        public DateTime lendDate
        {
            get { return _lendDate; }
            set { _lendDate = value; }
        }

        /*��������*/
        private float _lendDays;
        public float lendDays
        {
            get { return _lendDays; }
            set { _lendDays = value; }
        }

        /*�黹ʱ��*/
        private string _returnDate;
        public string returnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; }
        }

        /*������*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*��ע��Ϣ*/
        private string _lendMemo;
        public string lendMemo
        {
            get { return _lendMemo; }
            set { _lendMemo = value; }
        }

    }
}
