using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class DeviceRepairEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindDeviceInfodeviceObj();
                if (Request["repairId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindDeviceInfodeviceObj()
        {
            deviceObj.DataSource = BLL.bllDeviceInfo.getAllDeviceInfo();
            deviceObj.DataTextField = "deviceName";
            deviceObj.DataValueField = "deviceId";
            deviceObj.DataBind();
        }

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "repairId")))
            {
                ENTITY.DeviceRepair deviceRepair = BLL.bllDeviceRepair.getSomeDeviceRepair(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "repairId")));
                deviceObj.SelectedValue = deviceRepair.deviceObj.ToString();
                errorReason.Value = deviceRepair.errorReason;
                repairNumber.Value = deviceRepair.repairNumber.ToString();
                repairDate.Text = deviceRepair.repairDate.ToShortDateString();
                repairPalce.Value = deviceRepair.repairPalce;
                repairMan.Value = deviceRepair.repairMan;
                repairTime.Value = deviceRepair.repairTime;
                repairMoney.Value = deviceRepair.repairMoney.ToString("0.00");
                repairMemo.Value = deviceRepair.repairMemo;
            }
        }

        protected void BtnDeviceRepairSave_Click(object sender, EventArgs e)
        {
            ENTITY.DeviceRepair deviceRepair = new ENTITY.DeviceRepair();
            deviceRepair.deviceObj = int.Parse(deviceObj.SelectedValue);
            deviceRepair.errorReason = errorReason.Value;
            deviceRepair.repairNumber = int.Parse(repairNumber.Value);
            deviceRepair.repairDate = Convert.ToDateTime(repairDate.Text);
            deviceRepair.repairPalce = repairPalce.Value;
            deviceRepair.repairMan = repairMan.Value;
            deviceRepair.repairTime = repairTime.Value;
            deviceRepair.repairMoney = float.Parse(float.Parse(repairMoney.Value).ToString("0.00"));
            deviceRepair.repairMemo = repairMemo.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "repairId")))
            {
                deviceRepair.repairId = int.Parse(Request["repairId"]);
                if (BLL.bllDeviceRepair.EditDeviceRepair(deviceRepair))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"DeviceRepairEdit.aspx?repairId=" + Request["repairId"] + "\"} else  {location.href=\"DeviceRepairList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllDeviceRepair.AddDeviceRepair(deviceRepair))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"DeviceRepairEdit.aspx\"} else  {location.href=\"DeviceRepairList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeviceRepairList.aspx");
        }
    }
}

