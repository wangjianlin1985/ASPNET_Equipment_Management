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
    ///Rubbish ��ժҪ˵���������豸ʵ��
    /// </summary>

    public class Rubbish
    {
        /*����id*/
        private int _rubbishId;
        public int rubbishId
        {
            get { return _rubbishId; }
            set { _rubbishId = value; }
        }

        /*���ϵ��豸*/
        private int _deviceObj;
        public int deviceObj
        {
            get { return _deviceObj; }
            set { _deviceObj = value; }
        }

        /*����ԭ��*/
        private string _rubbishReason;
        public string rubbishReason
        {
            get { return _rubbishReason; }
            set { _rubbishReason = value; }
        }

        /*��������*/
        private int _rubbishNumber;
        public int rubbishNumber
        {
            get { return _rubbishNumber; }
            set { _rubbishNumber = value; }
        }

        /*�۾ɽ��*/
        private float _deprecitionMoney;
        public float deprecitionMoney
        {
            get { return _deprecitionMoney; }
            set { _deprecitionMoney = value; }
        }

        /*��������*/
        private DateTime _rubbishDate;
        public DateTime rubbishDate
        {
            get { return _rubbishDate; }
            set { _rubbishDate = value; }
        }

        /*��ע��Ϣ*/
        private string _rubbishMemo;
        public string rubbishMemo
        {
            get { return _rubbishMemo; }
            set { _rubbishMemo = value; }
        }

    }
}
