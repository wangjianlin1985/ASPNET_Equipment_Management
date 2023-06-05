<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="DeviceRepair_frontList" %>
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
<title>设备维修查询</title>
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
			    	<li role="presentation" class="active"><a href="#deviceRepairListPanel" aria-controls="deviceRepairListPanel" role="tab" data-toggle="tab">设备维修列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加设备维修</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="deviceRepairListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>维修编号</td><td>损坏的设备</td><td>故障原因</td><td>故障数量</td><td>送修日期</td><td>送修地点</td><td>维修人</td><td>维修工时</td><td>维修费用</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpDeviceRepair" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("repairId")%></td>
 											<td><%#GetDeviceInfodeviceObj(Eval("deviceObj").ToString())%></td>
 											<td><%#Eval("errorReason")%></td>
 											<td><%#Eval("repairNumber")%></td>
 											<td><%#Eval("repairDate")%></td>
 											<td><%#Eval("repairPalce")%></td>
 											<td><%#Eval("repairMan")%></td>
 											<td><%#Eval("repairTime")%></td>
 											<td><%#Eval("repairMoney")%></td>
 											<td>
 												<a href="frontshow.aspx?repairId=<%#Eval("repairId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="deviceRepairEdit('<%#Eval("repairId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="deviceRepairDelete('<%#Eval("repairId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
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
    		<h1>设备维修查询</h1>
		</div>
            <div class="form-group">
            	<label for="deviceObj_repairId">损坏的设备：</label>
                <asp:DropDownList ID="deviceObj" runat="server"  CssClass="form-control" placeholder="请选择损坏的设备"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="errorReason">故障原因:</label>
				<asp:TextBox ID="errorReason" runat="server"  CssClass="form-control" placeholder="请输入故障原因"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="repairDate">送修日期:</label>
				<asp:TextBox ID="repairDate"  runat="server" CssClass="form-control" placeholder="请选择送修日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="repairPalce">送修地点:</label>
				<asp:TextBox ID="repairPalce" runat="server"  CssClass="form-control" placeholder="请输入送修地点"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="repairMan">维修人:</label>
				<asp:TextBox ID="repairMan" runat="server"  CssClass="form-control" placeholder="请输入维修人"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="deviceRepairEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;设备维修信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="deviceRepairEditForm" id="deviceRepairEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="deviceRepair_repairId_edit" class="col-md-3 text-right">维修编号:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="deviceRepair_repairId_edit" name="deviceRepair.repairId" class="form-control" placeholder="请输入维修编号" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="deviceRepair_deviceObj_deviceId_edit" class="col-md-3 text-right">损坏的设备:</label>
		  	 <div class="col-md-9">
			    <select id="deviceRepair_deviceObj_deviceId_edit" name="deviceRepair.deviceObj.deviceId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceRepair_errorReason_edit" class="col-md-3 text-right">故障原因:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceRepair_errorReason_edit" name="deviceRepair.errorReason" class="form-control" placeholder="请输入故障原因">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceRepair_repairNumber_edit" class="col-md-3 text-right">故障数量:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceRepair_repairNumber_edit" name="deviceRepair.repairNumber" class="form-control" placeholder="请输入故障数量">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceRepair_repairDate_edit" class="col-md-3 text-right">送修日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date deviceRepair_repairDate_edit col-md-12" data-link-field="deviceRepair_repairDate_edit"  data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="deviceRepair_repairDate_edit" name="deviceRepair.repairDate" size="16" type="text" value="" placeholder="请选择送修日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceRepair_repairPalce_edit" class="col-md-3 text-right">送修地点:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceRepair_repairPalce_edit" name="deviceRepair.repairPalce" class="form-control" placeholder="请输入送修地点">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceRepair_repairMan_edit" class="col-md-3 text-right">维修人:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceRepair_repairMan_edit" name="deviceRepair.repairMan" class="form-control" placeholder="请输入维修人">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceRepair_repairTime_edit" class="col-md-3 text-right">维修工时:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceRepair_repairTime_edit" name="deviceRepair.repairTime" class="form-control" placeholder="请输入维修工时">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceRepair_repairMoney_edit" class="col-md-3 text-right">维修费用:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceRepair_repairMoney_edit" name="deviceRepair.repairMoney" class="form-control" placeholder="请输入维修费用">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceRepair_repairMemo_edit" class="col-md-3 text-right">备注信息:</label>
		  	 <div class="col-md-9">
			    <textarea id="deviceRepair_repairMemo_edit" name="deviceRepair.repairMemo" rows="8" class="form-control" placeholder="请输入备注信息"></textarea>
			 </div>
		  </div>
		</form> 
	    <style>#deviceRepairEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxDeviceRepairModify();">提交</button>
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
/*弹出修改设备维修界面并初始化数据*/
function deviceRepairEdit(repairId) {
	$.ajax({
		url :  basePath + "DeviceRepair/DeviceRepairController.aspx?action=getDeviceRepair&repairId=" + repairId,
		type : "get",
		dataType: "json",
		success : function (deviceRepair, response, status) {
			if (deviceRepair) {
				$("#deviceRepair_repairId_edit").val(deviceRepair.repairId);
				$.ajax({
					url: basePath + "DeviceInfo/DeviceInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(deviceInfos,response,status) { 
						$("#deviceRepair_deviceObj_deviceId_edit").empty();
						var html="";
		        		$(deviceInfos).each(function(i,deviceInfo){
		        			html += "<option value='" + deviceInfo.deviceId + "'>" + deviceInfo.deviceName + "</option>";
		        		});
		        		$("#deviceRepair_deviceObj_deviceId_edit").html(html);
		        		$("#deviceRepair_deviceObj_deviceId_edit").val(deviceRepair.deviceObjPri);
					}
				});
				$("#deviceRepair_errorReason_edit").val(deviceRepair.errorReason);
				$("#deviceRepair_repairNumber_edit").val(deviceRepair.repairNumber);
				$("#deviceRepair_repairDate_edit").val(deviceRepair.repairDate);
				$("#deviceRepair_repairPalce_edit").val(deviceRepair.repairPalce);
				$("#deviceRepair_repairMan_edit").val(deviceRepair.repairMan);
				$("#deviceRepair_repairTime_edit").val(deviceRepair.repairTime);
				$("#deviceRepair_repairMoney_edit").val(deviceRepair.repairMoney);
				$("#deviceRepair_repairMemo_edit").val(deviceRepair.repairMemo);
				$('#deviceRepairEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除设备维修信息*/
function deviceRepairDelete(repairId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "DeviceRepair/DeviceRepairController.aspx?action=delete",
			data : {
				repairId : repairId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "DeviceRepair/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交设备维修信息表单给服务器端修改*/
function ajaxDeviceRepairModify() {
	$.ajax({
		url :  basePath + "DeviceRepair/DeviceRepairController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#deviceRepairEditForm")[0]),
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

    /*送修日期组件*/
    $('.deviceRepair_repairDate_edit').datetimepicker({
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

