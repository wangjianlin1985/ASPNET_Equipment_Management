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
    ///DeviceType 的摘要说明：设备类别实体
    /// </summary>

    public class DeviceType
    {
        /*设备类别编号*/
        private int _deviceTypeId;
        public int deviceTypeId
        {
            get { return _deviceTypeId; }
            set { _deviceTypeId = value; }
        }

        /*设备类别名称*/
        private string _deviceTypeName;
        public string deviceTypeName
        {
            get { return _deviceTypeName; }
            set { _deviceTypeName = value; }
        }

    }
}
