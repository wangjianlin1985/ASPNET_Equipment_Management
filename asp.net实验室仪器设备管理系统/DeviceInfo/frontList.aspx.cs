using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class DeviceInfo_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BinddeviceTypeObj();
            string sqlstr = " where 1=1 ";
            if (Request["deviceName"] != null && Request["deviceName"].ToString() != "")
            {
                sqlstr += "  and deviceName like '%" + Request["deviceName"].ToString() + "%'";
                deviceName.Text = Request["deviceName"].ToString();
            }
            if (Request["deviceTypeObj"] != null && Request["deviceTypeObj"].ToString() != "0")
            {
                    sqlstr += "  and deviceTypeObj=" + Request["deviceTypeObj"].ToString();
                    deviceTypeObj.SelectedValue = Request["deviceTypeObj"].ToString();
            }
            if (Request["deviceSign"] != null && Request["deviceSign"].ToString() != "")
            {
                sqlstr += "  and deviceSign like '%" + Request["deviceSign"].ToString() + "%'";
                deviceSign.Text = Request["deviceSign"].ToString();
            }
            if (Request["deviceModel"] != null && Request["deviceModel"].ToString() != "")
            {
                sqlstr += "  and deviceModel like '%" + Request["deviceModel"].ToString() + "%'";
                deviceModel.Text = Request["deviceModel"].ToString();
            }
            if (Request["outDate"] != null && Request["outDate"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,outDate,120) like '" + Request["outDate"].ToString() + "%'";
                outDate.Text = Request["outDate"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BinddeviceTypeObj()
    {
        ListItem li = new ListItem("不限制", "0");
        deviceTypeObj.Items.Add(li);
        DataSet deviceTypeObjDs = BLL.bllDeviceType.getAllDeviceType();
        for (int i = 0; i < deviceTypeObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = deviceTypeObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["deviceTypeName"].ToString(),dr["deviceTypeId"].ToString());
            deviceTypeObj.Items.Add(li);
        }
        deviceTypeObj.SelectedValue = "0";
    }

    private void BindData(string strClass)
    {
        int DataCount = 0;
        int NowPage = 1;
        int AllPage = 0;
        int PageSize = Convert.ToInt32(HPageSize.Value);
        switch (strClass)
        {
            case "next":
                NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                break;
            case "up":
                NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                break;
            case "end":
                NowPage = Convert.ToInt32(HAllPage.Value);
                break;
            default:
                break;
        }
        DataTable dsLog = BLL.bllDeviceInfo.GetDeviceInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
        if (dsLog.Rows.Count == 0 || AllPage == 1)
        {
            LBEnd.Enabled = false;
            LBHome.Enabled = false;
            LBNext.Enabled = false;
            LBUp.Enabled = false;
        }
        else if (NowPage == 1)
        {
            LBHome.Enabled = false;
            LBUp.Enabled = false;
            LBNext.Enabled = true;
            LBEnd.Enabled = true;
        }
        else if (NowPage == AllPage)
        {
            LBHome.Enabled = true;
            LBUp.Enabled = true;
            LBNext.Enabled = false;
            LBEnd.Enabled = false;
        }
        else
        {
            LBEnd.Enabled = true;
            LBHome.Enabled = true;
            LBNext.Enabled = true;
            LBUp.Enabled = true;
        }
        RpDeviceInfo.DataSource = dsLog;
        RpDeviceInfo.DataBind();
        PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
        HNowPage.Value = Convert.ToString(NowPage++);
        HAllPage.Value = AllPage.ToString();
    }

    protected void LBHome_Click(object sender, EventArgs e)
    {
        BindData("");
    }
    protected void LBUp_Click(object sender, EventArgs e)
    {
        BindData("up");
    }
    protected void LBNext_Click(object sender, EventArgs e)
    {
        BindData("next");
    }
    protected void LBEnd_Click(object sender, EventArgs e)
    {
        BindData("end");
    }
        public string GetDeviceTypedeviceTypeObj(string deviceTypeObj)
        {
            return BLL.bllDeviceType.getSomeDeviceType(int.Parse(deviceTypeObj)).deviceTypeName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?deviceName=" + deviceName.Text.Trim()  + "&&deviceTypeObj=" + deviceTypeObj.SelectedValue.Trim()+ "&&deviceSign=" + deviceSign.Text.Trim()+ "&&deviceModel=" + deviceModel.Text.Trim()+ "&&outDate=" + outDate.Text.Trim());
        }

}
