using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ClassInfo_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sqlstr = " where 1=1 ";
            if (Request["classNo"] != null && Request["classNo"].ToString() != "")
            {
                sqlstr += "  and classNo like '%" + Request["classNo"].ToString() + "%'";
                classNo.Text = Request["classNo"].ToString();
            }
            if (Request["className"] != null && Request["className"].ToString() != "")
            {
                sqlstr += "  and className like '%" + Request["className"].ToString() + "%'";
                className.Text = Request["className"].ToString();
            }
            if (Request["bornDate"] != null && Request["bornDate"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,bornDate,120) like '" + Request["bornDate"].ToString() + "%'";
                bornDate.Text = Request["bornDate"].ToString();
            }
            if (Request["mainTeacher"] != null && Request["mainTeacher"].ToString() != "")
            {
                sqlstr += "  and mainTeacher like '%" + Request["mainTeacher"].ToString() + "%'";
                mainTeacher.Text = Request["mainTeacher"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
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
        DataTable dsLog = BLL.bllClassInfo.GetClassInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
        RpClassInfo.DataSource = dsLog;
        RpClassInfo.DataBind();
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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?classNo=" + classNo.Text.Trim() + "&&className=" + className.Text.Trim()+ "&&bornDate=" + bornDate.Text.Trim()+ "&&mainTeacher=" + mainTeacher.Text.Trim());
        }

}
