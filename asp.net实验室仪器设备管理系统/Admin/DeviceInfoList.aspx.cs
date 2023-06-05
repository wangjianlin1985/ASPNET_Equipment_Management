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
    public partial class DeviceInfoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
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
                li = new ListItem(dr["deviceTypeName"].ToString(), dr["deviceTypeName"].ToString());
                deviceTypeObj.Items.Add(li);
            }
            deviceTypeObj.SelectedValue = "0";
        }

        protected void BtnDeviceInfoAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeviceInfoEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllDeviceInfo.DelDeviceInfo(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "DeviceInfoList.aspx");
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
        protected void RpDeviceInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllDeviceInfo.DelDeviceInfo((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "DeviceInfoList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "DeviceInfoList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "DeviceInfoList.aspx");
                }
            }
        }
        public string GetDeviceTypedeviceTypeObj(string deviceTypeObj)
        {
            return BLL.bllDeviceType.getSomeDeviceType(int.Parse(deviceTypeObj)).deviceTypeName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeviceInfoList.aspx?deviceName=" + deviceName.Text.Trim()  + "&&deviceTypeObj=" + deviceTypeObj.SelectedValue.Trim()+ "&&deviceSign=" + deviceSign.Text.Trim()+ "&&deviceModel=" + deviceModel.Text.Trim()+ "&&outDate=" + outDate.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet deviceInfoDataSet = BLL.bllDeviceInfo.GetDeviceInfo(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='10'>设备记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>设备编号</th>");
            sb.Append("<th>设备名称</th>");
            sb.Append("<th>设备类型</th>");
            sb.Append("<th>设备图片</th>");
            sb.Append("<th>设备品牌</th>");
            sb.Append("<th>设备型号</th>");
            sb.Append("<th>生产厂家</th>");
            sb.Append("<th>出厂日期</th>");
            sb.Append("<th>设备价格</th>");
            sb.Append("<th>设备库存</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < deviceInfoDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = deviceInfoDataSet.Tables[0].Rows[i];
                sb.Append("<tr height='60' class=content>");
                sb.Append("<td>" + dr["deviceId"].ToString() + "</td>");
                sb.Append("<td>" + dr["deviceName"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllDeviceType.getSomeDeviceType(Convert.ToInt32(dr["deviceTypeObj"])).deviceTypeName + "</td>");
                sb.Append("<td width=80><span align='center'><img width='80' height='60' border='0' src='" + GetBaseUrl() + "/" +  dr["devicePhoto"].ToString() + "'/></span></td>");
                sb.Append("<td>" + dr["deviceSign"].ToString() + "</td>");
                sb.Append("<td>" + dr["deviceModel"].ToString() + "</td>");
                sb.Append("<td>" + dr["madePlace"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["outDate"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + dr["devicePrice"].ToString() + "</td>");
                sb.Append("<td>" + dr["deviceNumber"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "设备记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
