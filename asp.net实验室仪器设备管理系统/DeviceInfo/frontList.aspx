<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="DeviceInfo_frontList" %>
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
<title>设备查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form1" runat="server">
	<div class="col-md-9 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="../index.aspx">首页</a></li>
  			<li><a href="frontList.aspx">设备信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加设备</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpDeviceInfo" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?deviceId=<%#Eval("deviceId")%>"><img class="img-responsive" src="../<%#Eval("devicePhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		设备编号: <%#Eval("deviceId")%>
			     	</div>
			     	<div class="field">
	            		设备名称: <%#Eval("deviceName")%>
			     	</div>
			     	<div class="field">
	            		设备类型:<%#GetDeviceTypedeviceTypeObj(Eval("deviceTypeObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		设备品牌: <%#Eval("deviceSign")%>
			     	</div>
			     	<div class="field">
	            		设备型号: <%#Eval("deviceModel")%>
			     	</div>
			     	<div class="field">
	            		生产厂家: <%#Eval("madePlace")%>
			     	</div>
			     	<div class="field">
	            		出厂日期: <%#Eval("outDate")%>
			     	</div>
			     	<div class="field">
	            		设备价格: <%#Eval("devicePrice")%>
			     	</div>
			     	<div class="field">
	            		设备库存: <%#Eval("deviceNumber")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?deviceId=<%#Eval("deviceId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="deviceInfoEdit('<%#Eval("deviceId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="deviceInfoDelete('<%#Eval("deviceId")%>');" style="display:none;">删除</a>
			     </div>
			</div>
			</ItemTemplate>
			</asp:Repeater>

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

	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>设备查询</h1>
		</div>
			<div class="form-group">
				<label for="deviceName">设备名称:</label>
				<asp:TextBox ID="deviceName" runat="server"  CssClass="form-control" placeholder="请输入设备名称"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="deviceTypeObj_deviceTypeId">设备类型：</label>
                <asp:DropDownList ID="deviceTypeObj" runat="server"  CssClass="form-control" placeholder="请选择设备类型"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="deviceSign">设备品牌:</label>
				<asp:TextBox ID="deviceSign" runat="server"  CssClass="form-control" placeholder="请输入设备品牌"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="deviceModel">设备型号:</label>
				<asp:TextBox ID="deviceModel" runat="server"  CssClass="form-control" placeholder="请输入设备型号"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="outDate">出厂日期:</label>
				<asp:TextBox ID="outDate"  runat="server" CssClass="form-control" placeholder="请选择出厂日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="deviceInfoEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;设备信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="deviceInfoEditForm" id="deviceInfoEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="deviceInfo_deviceId_edit" class="col-md-3 text-right">设备编号:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="deviceInfo_deviceId_edit" name="deviceInfo.deviceId" class="form-control" placeholder="请输入设备编号" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="deviceInfo_deviceName_edit" class="col-md-3 text-right">设备名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceInfo_deviceName_edit" name="deviceInfo.deviceName" class="form-control" placeholder="请输入设备名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceInfo_deviceTypeObj_deviceTypeId_edit" class="col-md-3 text-right">设备类型:</label>
		  	 <div class="col-md-9">
			    <select id="deviceInfo_deviceTypeObj_deviceTypeId_edit" name="deviceInfo.deviceTypeObj.deviceTypeId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceInfo_devicePhoto_edit" class="col-md-3 text-right">设备图片:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="deviceInfo_devicePhotoImg" border="0px"/><br/>
			    <input type="hidden" id="deviceInfo_devicePhoto" name="deviceInfo.devicePhoto"/>
			    <input id="devicePhotoFile" name="devicePhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceInfo_deviceSign_edit" class="col-md-3 text-right">设备品牌:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceInfo_deviceSign_edit" name="deviceInfo.deviceSign" class="form-control" placeholder="请输入设备品牌">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceInfo_deviceModel_edit" class="col-md-3 text-right">设备型号:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceInfo_deviceModel_edit" name="deviceInfo.deviceModel" class="form-control" placeholder="请输入设备型号">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceInfo_madePlace_edit" class="col-md-3 text-right">生产厂家:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceInfo_madePlace_edit" name="deviceInfo.madePlace" class="form-control" placeholder="请输入生产厂家">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceInfo_outDate_edit" class="col-md-3 text-right">出厂日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date deviceInfo_outDate_edit col-md-12" data-link-field="deviceInfo_outDate_edit" data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="deviceInfo_outDate_edit" name="deviceInfo.outDate" size="16" type="text" value="" placeholder="请选择出厂日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceInfo_devicePrice_edit" class="col-md-3 text-right">设备价格:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceInfo_devicePrice_edit" name="deviceInfo.devicePrice" class="form-control" placeholder="请输入设备价格">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceInfo_deviceNumber_edit" class="col-md-3 text-right">设备库存:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="deviceInfo_deviceNumber_edit" name="deviceInfo.deviceNumber" class="form-control" placeholder="请输入设备库存">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="deviceInfo_deviceDesc_edit" class="col-md-3 text-right">设备描述:</label>
		  	 <div class="col-md-9">
			    <textarea id="deviceInfo_deviceDesc_edit" name="deviceInfo.deviceDesc" rows="8" class="form-control" placeholder="请输入设备描述"></textarea>
			 </div>
		  </div>
		</form> 
	    <style>#deviceInfoEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxDeviceInfoModify();">提交</button>
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
/*弹出修改设备界面并初始化数据*/
function deviceInfoEdit(deviceId) {
	$.ajax({
		url :  basePath + "DeviceInfo/DeviceInfoController.aspx?action=getDeviceInfo&deviceId=" + deviceId,
		type : "get",
		dataType: "json",
		success : function (deviceInfo, response, status) {
			if (deviceInfo) {
				$("#deviceInfo_deviceId_edit").val(deviceInfo.deviceId);
				$("#deviceInfo_deviceName_edit").val(deviceInfo.deviceName);
				$.ajax({
					url: basePath + "DeviceType/DeviceTypeController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(deviceTypes,response,status) { 
						$("#deviceInfo_deviceTypeObj_deviceTypeId_edit").empty();
						var html="";
		        		$(deviceTypes).each(function(i,deviceType){
		        			html += "<option value='" + deviceType.deviceTypeId + "'>" + deviceType.deviceTypeName + "</option>";
		        		});
		        		$("#deviceInfo_deviceTypeObj_deviceTypeId_edit").html(html);
		        		$("#deviceInfo_deviceTypeObj_deviceTypeId_edit").val(deviceInfo.deviceTypeObjPri);
					}
				});
				$("#deviceInfo_devicePhoto").val(deviceInfo.devicePhoto);
				$("#deviceInfo_devicePhotoImg").attr("src", basePath +　deviceInfo.devicePhoto);
				$("#deviceInfo_deviceSign_edit").val(deviceInfo.deviceSign);
				$("#deviceInfo_deviceModel_edit").val(deviceInfo.deviceModel);
				$("#deviceInfo_madePlace_edit").val(deviceInfo.madePlace);
				$("#deviceInfo_outDate_edit").val(deviceInfo.outDate);
				$("#deviceInfo_devicePrice_edit").val(deviceInfo.devicePrice);
				$("#deviceInfo_deviceNumber_edit").val(deviceInfo.deviceNumber);
				$("#deviceInfo_deviceDesc_edit").val(deviceInfo.deviceDesc);
				$('#deviceInfoEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除设备信息*/
function deviceInfoDelete(deviceId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "DeviceInfo/DeviceInfoController.aspx?action=delete",
			data : {
				deviceId : deviceId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "DeviceInfo/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交设备信息表单给服务器端修改*/
function ajaxDeviceInfoModify() {
	$.ajax({
		url :  basePath + "DeviceInfo/DeviceInfoController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#deviceInfoEditForm")[0]),
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

    /*出厂日期组件*/
    $('.deviceInfo_outDate_edit').datetimepicker({
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

