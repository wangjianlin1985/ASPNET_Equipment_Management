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
    ///DeviceRepair ��ժҪ˵�����豸ά��ʵ��
    /// </summary>

    public class DeviceRepair
    {
        /*ά�ޱ��*/
        private int _repairId;
        public int repairId
        {
            get { return _repairId; }
            set { _repairId = value; }
        }

        /*�𻵵��豸*/
        private int _deviceObj;
        public int deviceObj
        {
            get { return _deviceObj; }
            set { _deviceObj = value; }
        }

        /*����ԭ��*/
        private string _errorReason;
        public string errorReason
        {
            get { return _errorReason; }
            set { _errorReason = value; }
        }

        /*��������*/
        private int _repairNumber;
        public int repairNumber
        {
            get { return _repairNumber; }
            set { _repairNumber = value; }
        }

        /*��������*/
        private DateTime _repairDate;
        public DateTime repairDate
        {
            get { return _repairDate; }
            set { _repairDate = value; }
        }

        /*���޵ص�*/
        private string _repairPalce;
        public string repairPalce
        {
            get { return _repairPalce; }
            set { _repairPalce = value; }
        }

        /*ά����*/
        private string _repairMan;
        public string repairMan
        {
            get { return _repairMan; }
            set { _repairMan = value; }
        }

        /*ά�޹�ʱ*/
        private string _repairTime;
        public string repairTime
        {
            get { return _repairTime; }
            set { _repairTime = value; }
        }

        /*ά�޷���*/
        private float _repairMoney;
        public float repairMoney
        {
            get { return _repairMoney; }
            set { _repairMoney = value; }
        }

        /*��ע��Ϣ*/
        private string _repairMemo;
        public string repairMemo
        {
            get { return _repairMemo; }
            set { _repairMemo = value; }
        }

    }
}
