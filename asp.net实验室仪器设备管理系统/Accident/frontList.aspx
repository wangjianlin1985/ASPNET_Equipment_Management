<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Accident_frontList" %>
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
<title>设备事故查询</title>
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
			    	<li role="presentation" class="active"><a href="#accidentListPanel" aria-controls="accidentListPanel" role="tab" data-toggle="tab">设备事故列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加设备事故</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="accidentListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>事故id</td><td>事故的设备</td><td>事故原因</td><td>事故时间</td><td>上报的用户</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpAccident" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("accidentId")%></td>
 											<td><%#GetDeviceInfodeviceObj(Eval("deviceObj").ToString())%></td>
 											<td><%#Eval("reason")%></td>
 											<td><%#Eval("accidentTime")%></td>
 											<td><%#GetUserInfouserObj(Eval("userObj").ToString())%></td>
 											<td>
 												<a href="frontshow.aspx?accidentId=<%#Eval("accidentId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="accidentEdit('<%#Eval("accidentId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="accidentDelete('<%#Eval("accidentId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
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
    		<h1>设备事故查询</h1>
		</div>
            <div class="form-group">
            	<label for="deviceObj_accidentId">事故的设备：</label>
                <asp:DropDownList ID="deviceObj" runat="server"  CssClass="form-control" placeholder="请选择事故的设备"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="reason">事故原因:</label>
				<asp:TextBox ID="reason" runat="server"  CssClass="form-control" placeholder="请输入事故原因"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="accidentTime">事故时间:</label>
				<asp:TextBox ID="accidentTime"  runat="server" CssClass="form-control" placeholder="请选择事故时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="userObj_accidentId">上报的用户：</label>
                <asp:DropDownList ID="userObj" runat="server"  CssClass="form-control" placeholder="请选择上报的用户"></asp:DropDownList>
            </div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="accidentEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;设备事故信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="accidentEditForm" id="accidentEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="accident_accidentId_edit" class="col-md-3 text-right">事故id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="accident_accidentId_edit" name="accident.accidentId" class="form-control" placeholder="请输入事故id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="accident_deviceObj_deviceId_edit" class="col-md-3 text-right">事故的设备:</label>
		  	 <div class="col-md-9">
			    <select id="accident_deviceObj_deviceId_edit" name="accident.deviceObj.deviceId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="accident_reason_edit" class="col-md-3 text-right">事故原因:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="accident_reason_edit" name="accident.reason" class="form-control" placeholder="请输入事故原因">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="accident_accidentContent_edit" class="col-md-3 text-right">事故内容:</label>
		  	 <div class="col-md-9">
			    <textarea id="accident_accidentContent_edit" name="accident.accidentContent" rows="8" class="form-control" placeholder="请输入事故内容"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="accident_accidentTime_edit" class="col-md-3 text-right">事故时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date accident_accidentTime_edit col-md-12" data-link-field="accident_accidentTime_edit">
                    <input class="form-control" id="accident_accidentTime_edit" name="accident.accidentTime" size="16" type="text" value="" placeholder="请选择事故时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="accident_userObj_user_name_edit" class="col-md-3 text-right">上报的用户:</label>
		  	 <div class="col-md-9">
			    <select id="accident_userObj_user_name_edit" name="accident.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		</form> 
	    <style>#accidentEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxAccidentModify();">提交</button>
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
/*弹出修改设备事故界面并初始化数据*/
function accidentEdit(accidentId) {
	$.ajax({
		url :  basePath + "Accident/AccidentController.aspx?action=getAccident&accidentId=" + accidentId,
		type : "get",
		dataType: "json",
		success : function (accident, response, status) {
			if (accident) {
				$("#accident_accidentId_edit").val(accident.accidentId);
				$.ajax({
					url: basePath + "DeviceInfo/DeviceInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(deviceInfos,response,status) { 
						$("#accident_deviceObj_deviceId_edit").empty();
						var html="";
		        		$(deviceInfos).each(function(i,deviceInfo){
		        			html += "<option value='" + deviceInfo.deviceId + "'>" + deviceInfo.deviceName + "</option>";
		        		});
		        		$("#accident_deviceObj_deviceId_edit").html(html);
		        		$("#accident_deviceObj_deviceId_edit").val(accident.deviceObjPri);
					}
				});
				$("#accident_reason_edit").val(accident.reason);
				$("#accident_accidentContent_edit").val(accident.accidentContent);
				$("#accident_accidentTime_edit").val(accident.accidentTime);
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#accident_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#accident_userObj_user_name_edit").html(html);
		        		$("#accident_userObj_user_name_edit").val(accident.userObjPri);
					}
				});
				$('#accidentEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除设备事故信息*/
function accidentDelete(accidentId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Accident/AccidentController.aspx?action=delete",
			data : {
				accidentId : accidentId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Accident/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交设备事故信息表单给服务器端修改*/
function ajaxAccidentModify() {
	$.ajax({
		url :  basePath + "Accident/AccidentController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#accidentEditForm")[0]),
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

    /*事故时间组件*/
    $('.accident_accidentTime_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd hh:ii:ss',
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

