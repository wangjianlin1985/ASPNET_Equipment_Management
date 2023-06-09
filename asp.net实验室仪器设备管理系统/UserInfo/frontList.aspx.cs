using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class UserInfo_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindclassObj();
            string sqlstr = " where 1=1 ";
            if (Request["user_name"] != null && Request["user_name"].ToString() != "")
            {
                sqlstr += "  and user_name like '%" + Request["user_name"].ToString() + "%'";
                user_name.Text = Request["user_name"].ToString();
            }
            if (Request["classObj"] != null && Request["classObj"].ToString() != "")
            {
                sqlstr += "  and classObj='" + Request["classObj"].ToString() + "'";
                classObj.SelectedValue = Request["classObj"].ToString();
            }
            if (Request["name"] != null && Request["name"].ToString() != "")
            {
                sqlstr += "  and name like '%" + Request["name"].ToString() + "%'";
                name.Text = Request["name"].ToString();
            }
            if (Request["birthDate"] != null && Request["birthDate"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,birthDate,120) like '" + Request["birthDate"].ToString() + "%'";
                birthDate.Text = Request["birthDate"].ToString();
            }
            if (Request["telephone"] != null && Request["telephone"].ToString() != "")
            {
                sqlstr += "  and telephone like '%" + Request["telephone"].ToString() + "%'";
                telephone.Text = Request["telephone"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BindclassObj()
    {
        ListItem li = new ListItem("不限制", "");
        classObj.Items.Add(li);
        DataSet classObjDs = BLL.bllClassInfo.getAllClassInfo();
        for (int i = 0; i < classObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = classObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["className"].ToString(),dr["classNo"].ToString());
            classObj.Items.Add(li);
        }
        classObj.SelectedValue = "";
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
        DataTable dsLog = BLL.bllUserInfo.GetUserInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
        RpUserInfo.DataSource = dsLog;
        RpUserInfo.DataBind();
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
        public string GetClassInfoclassObj(string classObj)
        {
            return BLL.bllClassInfo.getSomeClassInfo(classObj).className;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?user_name=" + user_name.Text.Trim()  + "&&classObj=" + classObj.SelectedValue.Trim()+ "&&name=" + name.Text.Trim()+ "&&birthDate=" + birthDate.Text.Trim()+ "&&telephone=" + telephone.Text.Trim());
        }

}
