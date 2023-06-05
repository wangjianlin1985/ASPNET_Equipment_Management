<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
    
        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;用户管理</div>
        <div class="MenuNote" style="display:none;" id="UserInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="ClassInfoEdit.aspx" target="main">添加班级</a></li>
                <li><a href="ClassInfoList.aspx" target="main">班级查询</a></li> 
                <li><a href="UserInfoEdit.aspx" target="main">添加用户</a></li>
                <li><a href="UserInfoList.aspx" target="main">用户查询</a></li> 
            </ul>
        </div>

      

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;设备管理</div>
        <div class="MenuNote" style="display:none;" id="DeviceInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="DeviceTypeEdit.aspx" target="main">添加设备类别</a></li>
                <li><a href="DeviceTypeList.aspx" target="main">设备类别查询</a></li>
                <li><a href="DeviceInfoEdit.aspx" target="main">添加设备</a></li>
                <li><a href="DeviceInfoList.aspx" target="main">设备查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;设备业务管理</div>
        <div class="MenuNote" style="display:none;" id="DeviceLendDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="DeviceLendEdit.aspx" target="main">添加设备借用</a></li>
                <li><a href="DeviceLendList.aspx" target="main">设备借用查询</a></li> 
                <li><a href="DeviceRepairEdit.aspx" target="main">添加设备维修</a></li>
                <li><a href="DeviceRepairList.aspx" target="main">设备维修查询</a></li>
                <li><a href="RubbishEdit.aspx" target="main">添加报废设备</a></li>
                <li><a href="RubbishList.aspx" target="main">报废设备查询</a></li> 
                <li><a href="AccidentEdit.aspx" target="main">添加设备事故</a></li>
                <li><a href="AccidentList.aspx" target="main">设备事故查询</a></li> 
            </ul>
        </div>
         

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;新闻公告管理</div>
        <div class="MenuNote" style="display:none;" id="NoticeDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="NoticeEdit.aspx" target="main">添加新闻公告</a></li>
                <li><a href="NoticeList.aspx" target="main">新闻公告查询</a></li> 
            </ul>
        </div>

 
         <!--
         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;客户信息管理</div>
        <div class="MenuNote" style="display:none;" id="Div2" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
          
                <li><a href="M_CusList.aspx" target="main">客户信息列表</a></li>  
            </ul>
        </div> -->
        
       <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统信息管理</div>
        <div class="MenuNote" style="display:none;" id="sysDiv"  runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
           <li><a href="M_AddUsersInfo.aspx" target="main">添加管理员</a></li>
             <li><a href="M_UsersList.aspx" target="main">管理员列表</a></li>           
            </ul>
        </div>
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
