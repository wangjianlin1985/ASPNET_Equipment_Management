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
    ///Accident ��ժҪ˵�����豸�¹�ʵ��
    /// </summary>

    public class Accident
    {
        /*�¹�id*/
        private int _accidentId;
        public int accidentId
        {
            get { return _accidentId; }
            set { _accidentId = value; }
        }

        /*�¹ʵ��豸*/
        private int _deviceObj;
        public int deviceObj
        {
            get { return _deviceObj; }
            set { _deviceObj = value; }
        }

        /*�¹�ԭ��*/
        private string _reason;
        public string reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        /*�¹�����*/
        private string _accidentContent;
        public string accidentContent
        {
            get { return _accidentContent; }
            set { _accidentContent = value; }
        }

        /*�¹�ʱ��*/
        private DateTime _accidentTime;
        public DateTime accidentTime
        {
            get { return _accidentTime; }
            set { _accidentTime = value; }
        }

        /*�ϱ����û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

    }
}
