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
    ///DeviceType ��ժҪ˵�����豸���ʵ��
    /// </summary>

    public class DeviceType
    {
        /*�豸�����*/
        private int _deviceTypeId;
        public int deviceTypeId
        {
            get { return _deviceTypeId; }
            set { _deviceTypeId = value; }
        }

        /*�豸�������*/
        private string _deviceTypeName;
        public string deviceTypeName
        {
            get { return _deviceTypeName; }
            set { _deviceTypeName = value; }
        }

    }
}
