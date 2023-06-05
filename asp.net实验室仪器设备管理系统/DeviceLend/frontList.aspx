<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="DeviceLend_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>设备借用查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-9 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#deviceLendListPanel" aria-controls="deviceLendListPanel" role="tab" data-toggle="tab">设备借用列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加设备借用</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="deviceLendListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>借用编号</td><td>借用的设备</td><td>借用数量</td><td>借用日期</td><td>借用天数</td><td>归还时间</td><td>借用人</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpDeviceLend" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("lendId")%></td>
 											<td><%#GetDeviceInfodeviceObj(Eval("deviceObj").ToString())%></td>
 											<td><%#Eval("lendNumber")%></td>
 											<td><%#Eval("lendDate")%></td>
 											<td><%#Eval("lendDays")%></td>
 											<td><%#Eval("returnDate")%></td>
 											<td><%#GetUserInfouserObj(Eval("userObj").ToString())%></td>
 											<td>
 												<a href="frontshow.aspx?lendId=<%#Eval("lendId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="deviceLendEdit('<%#Eval("lendId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="deviceLendDelete('<%#Eval("lendId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

				    		<div class="row">
					            <div class="col-md-12">
						            <nav class="pull-left">
						                <ul class="pagination">
						                    <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn"
						                      onclick="LBHome_Click">[首页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
						                      onclick="LBUp_Click">[上一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
						                      onclick="LBNext_Click">[下一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn"
						                      onclick="LBEnd_Click">[尾页]</asp:LinkButton>
						                    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
						                    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
						                    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
						                    <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
						                    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						                </ul>
						            </nav>
						            <div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
					            </div>
				            </div> 
				    </div>
				</div>
			</div>
		</div>
	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>设备借用查询</h1>
		</div>
            <div class="form-group">
            	<label for="deviceObj_lendId">借用的设备：</label>
                <asp:DropDownList ID="deviceObj" runat="server"  CssClass="form-control" placeholder="请选择借用的设备"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="lendDate">借用日期:</label>
				<asp:TextBox ID="lendDate"  runat="server" CssClass="form-control" placeholder="请选择借用日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="userObj_lendId">借用人：</label>
                <asp:DropDownList ID="userObj" runat="server"  CssClass="form-control" placeholder="请选择借用人"></asp:DropDownList>
            </div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="deviceLendEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;设备借用信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="deviceLendEditForm" id="deviceLendEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="deviceLend_lendId_edit" class="col-md-3 text-right">借用编号:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="deviceLend_lendId_edit" name="deviceLend.lendId" class="form-control" placeholder="请输入借用编号" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="deviceLend_deviceObj_deviceId_edit" class="col-md-3 text-right">借用的设备:</label>
		  	 <div class="col-md-9">
			    <select id="deviceLend_deviceObj_deviceId_edit" name="deviceLend.deviceObj.deviceId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceLend_lendNumber_edit" class="col-md-3 text-right">借用数量:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceLend_lendNumber_edit" name="deviceLend.lendNumber" class="form-control" placeholder="请输入借用数量">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceLend_lendDate_edit" class="col-md-3 text-right">借用日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date deviceLend_lendDate_edit col-md-12" data-link-field="deviceLend_lendDate_edit"  data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="deviceLend_lendDate_edit" name="deviceLend.lendDate" size="16" type="text" value="" placeholder="请选择借用日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceLend_lendDays_edit" class="col-md-3 text-right">借用天数:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceLend_lendDays_edit" name="deviceLend.lendDays" class="form-control" placeholder="请输入借用天数">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceLend_returnDate_edit" class="col-md-3 text-right">归还时间:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceLend_returnDate_edit" name="deviceLend.returnDate" class="form-control" placeholder="请输入归还时间">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceLend_userObj_user_name_edit" class="col-md-3 text-right">借用人:</label>
		  	 <div class="col-md-9">
			    <select id="deviceLend_userObj_user_name_edit" name="deviceLend.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceLend_lendMemo_edit" class="col-md-3 text-right">备注信息:</label>
		  	 <div class="col-md-9">
			    <textarea id="deviceLend_lendMemo_edit" name="deviceLend.lendMemo" rows="8" class="form-control" placeholder="请输入备注信息"></textarea>
			 </div>
		  </div>
		</form> 
	    <style>#deviceLendEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxDeviceLendModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改设备借用界面并初始化数据*/
function deviceLendEdit(lendId) {
	$.ajax({
		url :  basePath + "DeviceLend/DeviceLendController.aspx?action=getDeviceLend&lendId=" + lendId,
		type : "get",
		dataType: "json",
		success : function (deviceLend, response, status) {
			if (deviceLend) {
				$("#deviceLend_lendId_edit").val(deviceLend.lendId);
				$.ajax({
					url: basePath + "DeviceInfo/DeviceInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(deviceInfos,response,status) { 
						$("#deviceLend_deviceObj_deviceId_edit").empty();
						var html="";
		        		$(deviceInfos).each(function(i,deviceInfo){
		        			html += "<option value='" + deviceInfo.deviceId + "'>" + deviceInfo.deviceName + "</option>";
		        		});
		        		$("#deviceLend_deviceObj_deviceId_edit").html(html);
		        		$("#deviceLend_deviceObj_deviceId_edit").val(deviceLend.deviceObjPri);
					}
				});
				$("#deviceLend_lendNumber_edit").val(deviceLend.lendNumber);
				$("#deviceLend_lendDate_edit").val(deviceLend.lendDate);
				$("#deviceLend_lendDays_edit").val(deviceLend.lendDays);
				$("#deviceLend_returnDate_edit").val(deviceLend.returnDate);
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#deviceLend_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#deviceLend_userObj_user_name_edit").html(html);
		        		$("#deviceLend_userObj_user_name_edit").val(deviceLend.userObjPri);
					}
				});
				$("#deviceLend_lendMemo_edit").val(deviceLend.lendMemo);
				$('#deviceLendEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除设备借用信息*/
function deviceLendDelete(lendId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "DeviceLend/DeviceLendController.aspx?action=delete",
			data : {
				lendId : lendId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "DeviceLend/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交设备借用信息表单给服务器端修改*/
function ajaxDeviceLendModify() {
	$.ajax({
		url :  basePath + "DeviceLend/DeviceLendController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#deviceLendEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

    /*借用日期组件*/
    $('.deviceLend_lendDate_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd',
    	minView: 2,
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
})
</script>
</body>
</html>

