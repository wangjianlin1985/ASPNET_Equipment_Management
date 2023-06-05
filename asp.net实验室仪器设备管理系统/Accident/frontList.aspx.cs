using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Accident_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BinddeviceObj();
            BinduserObj();
            string sqlstr = " where 1=1 ";
            if (Request["deviceObj"] != null && Request["deviceObj"].ToString() != "0")
            {
                    sqlstr += "  and deviceObj=" + Request["deviceObj"].ToString();
                    deviceObj.SelectedValue = Request["deviceObj"].ToString();
            }
            if (Request["reason"] != null && Request["reason"].ToString() != "")
            {
                sqlstr += "  and reason like '%" + Request["reason"].ToString() + "%'";
                reason.Text = Request["reason"].ToString();
            }
            if (Request["accidentTime"] != null && Request["accidentTime"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,accidentTime,120) like '" + Request["accidentTime"].ToString() + "%'";
                accidentTime.Text = Request["accidentTime"].ToString();
            }
            if (Request["userObj"] != null && Request["userObj"].ToString() != "")
            {
                sqlstr += "  and userObj='" + Request["userObj"].ToString() + "'";
                userObj.SelectedValue = Request["userObj"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BinddeviceObj()
    {
        ListItem li = new ListItem("不限制", "0");
        deviceObj.Items.Add(li);
        DataSet deviceObjDs = BLL.bllDeviceInfo.getAllDeviceInfo();
        for (int i = 0; i < deviceObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = deviceObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["deviceName"].ToString(),dr["deviceId"].ToString());
            deviceObj.Items.Add(li);
        }
        deviceObj.SelectedValue = "0";
    }

    private void BinduserObj()
    {
        ListItem li = new ListItem("不限制", "");
        userObj.Items.Add(li);
        DataSet userObjDs = BLL.bllUserInfo.getAllUserInfo();
        for (int i = 0; i < userObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = userObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["name"].ToString(),dr["user_name"].ToString());
            userObj.Items.Add(li);
        }
        userObj.SelectedValue = "";
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
        DataTable dsLog = BLL.bllAccident.GetAccident(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
        RpAccident.DataSource = dsLog;
        RpAccident.DataBind();
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
        public string GetDeviceInfodeviceObj(string deviceObj)
        {
            return BLL.bllDeviceInfo.getSomeDeviceInfo(int.Parse(deviceObj)).deviceName;
        }

        public string GetUserInfouserObj(string userObj)
        {
            return BLL.bllUserInfo.getSomeUserInfo(userObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?deviceObj=" + deviceObj.SelectedValue.Trim()+ "&&reason=" + reason.Text.Trim()+ "&&accidentTime=" + accidentTime.Text.Trim() + "&&userObj=" + userObj.SelectedValue.Trim());
        }

}
