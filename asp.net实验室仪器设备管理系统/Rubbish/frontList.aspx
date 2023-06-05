<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Rubbish_frontList" %>
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
<title>报废设备查询</title>
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
			    	<li role="presentation" class="active"><a href="#rubbishListPanel" aria-controls="rubbishListPanel" role="tab" data-toggle="tab">报废设备列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加报废设备</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="rubbishListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>报废id</td><td>报废的设备</td><td>报废原因</td><td>报废数量</td><td>折旧金额</td><td>报废日期</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpRubbish" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("rubbishId")%></td>
 											<td><%#GetDeviceInfodeviceObj(Eval("deviceObj").ToString())%></td>
 											<td><%#Eval("rubbishReason")%></td>
 											<td><%#Eval("rubbishNumber")%></td>
 											<td><%#Eval("deprecitionMoney")%></td>
 											<td><%#Eval("rubbishDate")%></td>
 											<td>
 												<a href="frontshow.aspx?rubbishId=<%#Eval("rubbishId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="rubbishEdit('<%#Eval("rubbishId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="rubbishDelete('<%#Eval("rubbishId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
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
    		<h1>报废设备查询</h1>
		</div>
            <div class="form-group">
            	<label for="deviceObj_rubbishId">报废的设备：</label>
                <asp:DropDownList ID="deviceObj" runat="server"  CssClass="form-control" placeholder="请选择报废的设备"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="rubbishReason">报废原因:</label>
				<asp:TextBox ID="rubbishReason" runat="server"  CssClass="form-control" placeholder="请输入报废原因"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="rubbishDate">报废日期:</label>
				<asp:TextBox ID="rubbishDate"  runat="server" CssClass="form-control" placeholder="请选择报废日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="rubbishEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;报废设备信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="rubbishEditForm" id="rubbishEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="rubbish_rubbishId_edit" class="col-md-3 text-right">报废id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="rubbish_rubbishId_edit" name="rubbish.rubbishId" class="form-control" placeholder="请输入报废id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="rubbish_deviceObj_deviceId_edit" class="col-md-3 text-right">报废的设备:</label>
		  	 <div class="col-md-9">
			    <select id="rubbish_deviceObj_deviceId_edit" name="rubbish.deviceObj.deviceId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="rubbish_rubbishReason_edit" class="col-md-3 text-right">报废原因:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="rubbish_rubbishReason_edit" name="rubbish.rubbishReason" class="form-control" placeholder="请输入报废原因">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="rubbish_rubbishNumber_edit" class="col-md-3 text-right">报废数量:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="rubbish_rubbishNumber_edit" name="rubbish.rubbishNumber" class="form-control" placeholder="请输入报废数量">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="rubbish_deprecitionMoney_edit" class="col-md-3 text-right">折旧金额:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="rubbish_deprecitionMoney_edit" name="rubbish.deprecitionMoney" class="form-control" placeholder="请输入折旧金额">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="rubbish_rubbishDate_edit" class="col-md-3 text-right">报废日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date rubbish_rubbishDate_edit col-md-12" data-link-field="rubbish_rubbishDate_edit"  data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="rubbish_rubbishDate_edit" name="rubbish.rubbishDate" size="16" type="text" value="" placeholder="请选择报废日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="rubbish_rubbishMemo_edit" class="col-md-3 text-right">备注信息:</label>
		  	 <div class="col-md-9">
			    <textarea id="rubbish_rubbishMemo_edit" name="rubbish.rubbishMemo" rows="8" class="form-control" placeholder="请输入备注信息"></textarea>
			 </div>
		  </div>
		</form> 
	    <style>#rubbishEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxRubbishModify();">提交</button>
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
/*弹出修改报废设备界面并初始化数据*/
function rubbishEdit(rubbishId) {
	$.ajax({
		url :  basePath + "Rubbish/RubbishController.aspx?action=getRubbish&rubbishId=" + rubbishId,
		type : "get",
		dataType: "json",
		success : function (rubbish, response, status) {
			if (rubbish) {
				$("#rubbish_rubbishId_edit").val(rubbish.rubbishId);
				$.ajax({
					url: basePath + "DeviceInfo/DeviceInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(deviceInfos,response,status) { 
						$("#rubbish_deviceObj_deviceId_edit").empty();
						var html="";
		        		$(deviceInfos).each(function(i,deviceInfo){
		        			html += "<option value='" + deviceInfo.deviceId + "'>" + deviceInfo.deviceName + "</option>";
		        		});
		        		$("#rubbish_deviceObj_deviceId_edit").html(html);
		        		$("#rubbish_deviceObj_deviceId_edit").val(rubbish.deviceObjPri);
					}
				});
				$("#rubbish_rubbishReason_edit").val(rubbish.rubbishReason);
				$("#rubbish_rubbishNumber_edit").val(rubbish.rubbishNumber);
				$("#rubbish_deprecitionMoney_edit").val(rubbish.deprecitionMoney);
				$("#rubbish_rubbishDate_edit").val(rubbish.rubbishDate);
				$("#rubbish_rubbishMemo_edit").val(rubbish.rubbishMemo);
				$('#rubbishEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除报废设备信息*/
function rubbishDelete(rubbishId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Rubbish/RubbishController.aspx?action=delete",
			data : {
				rubbishId : rubbishId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Rubbish/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交报废设备信息表单给服务器端修改*/
function ajaxRubbishModify() {
	$.ajax({
		url :  basePath + "Rubbish/RubbishController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#rubbishEditForm")[0]),
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

    /*报废日期组件*/
    $('.rubbish_rubbishDate_edit').datetimepicker({
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

