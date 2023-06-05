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
    public partial class RubbishList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BinddeviceObj();
                string sqlstr = " where 1=1 ";
                if (Request["deviceObj"] != null && Request["deviceObj"].ToString() != "0")
                {
                    sqlstr += "  and deviceObj=" + Request["deviceObj"].ToString();
                    deviceObj.SelectedValue = Request["deviceObj"].ToString();
                }
                if (Request["rubbishReason"] != null && Request["rubbishReason"].ToString() != "")
                {
                    sqlstr += "  and rubbishReason like '%" + Request["rubbishReason"].ToString() + "%'";
                    rubbishReason.Text = Request["rubbishReason"].ToString();
                }
                if (Request["rubbishDate"] != null && Request["rubbishDate"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,rubbishDate,120) like '" + Request["rubbishDate"].ToString() + "%'";
                    rubbishDate.Text = Request["rubbishDate"].ToString();
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
                li = new ListItem(dr["deviceName"].ToString(), dr["deviceName"].ToString());
                deviceObj.Items.Add(li);
            }
            deviceObj.SelectedValue = "0";
        }

        protected void BtnRubbishAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("RubbishEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllRubbish.DelRubbish(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "RubbishList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
                }
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
            DataTable dsLog = BLL.bllRubbish.GetRubbish(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpRubbish.DataSource = dsLog;
            RpRubbish.DataBind();
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
        protected void RpRubbish_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllRubbish.DelRubbish((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "RubbishList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "RubbishList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "RubbishList.aspx");
                }
            }
        }
        public string GetDeviceInfodeviceObj(string deviceObj)
        {
            return BLL.bllDeviceInfo.getSomeDeviceInfo(int.Parse(deviceObj)).deviceName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("RubbishList.aspx?deviceObj=" + deviceObj.SelectedValue.Trim()+ "&&rubbishReason=" + rubbishReason.Text.Trim()+ "&&rubbishDate=" + rubbishDate.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet rubbishDataSet = BLL.bllRubbish.GetRubbish(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='6'>报废设备记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>报废id</th>");
            sb.Append("<th>报废的设备</th>");
            sb.Append("<th>报废原因</th>");
            sb.Append("<th>报废数量</th>");
            sb.Append("<th>折旧金额</th>");
            sb.Append("<th>报废日期</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < rubbishDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = rubbishDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["rubbishId"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllDeviceInfo.getSomeDeviceInfo(Convert.ToInt32(dr["deviceObj"])).deviceName + "</td>");
                sb.Append("<td>" + dr["rubbishReason"].ToString() + "</td>");
                sb.Append("<td>" + dr["rubbishNumber"].ToString() + "</td>");
                sb.Append("<td>" + dr["deprecitionMoney"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["rubbishDate"]).ToShortDateString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "报废设备记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
