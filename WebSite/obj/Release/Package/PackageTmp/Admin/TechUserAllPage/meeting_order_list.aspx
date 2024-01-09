<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meeting_order_list.aspx.cs" Inherits="WebSite.Admin.TechUserAllPage.meeting_order_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Xenon Boostrap Admin Panel" />
    <meta name="author" content="" />
    <title>后台管理系统</title>
    <link rel="stylesheet" href="/Admin/Xenon/assets/css/fonts/linecons/css/linecons.css">
    <link rel="stylesheet" href="/Admin/Xenon/assets/css/fonts/fontawesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="/Admin/Xenon/assets/css/bootstrap.css">
    <link rel="stylesheet" href="/Admin/Xenon/assets/css/xenon-core.css">
    <link rel="stylesheet" href="/Admin/Xenon/assets/css/xenon-forms.css">
    <link rel="stylesheet" href="/Admin/Xenon/assets/css/xenon-components.css">
    <link rel="stylesheet" href="/Admin/Xenon/assets/css/xenon-skins.css">
    <link rel="stylesheet" href="/Admin/Xenon/assets/css/custom.css">
    <script src="/Admin/Xenon/assets/js/jquery-1.11.1.min.js"></script>
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
		<script src="/Admin/Xenon/assets/js/html5shiv.min.js"></script>
		<script src="/Admin/Xenon/assets/js/respond.min.js"></script>
	<![endif]-->
</head>
<body class="page-body">
    <form id="form1" runat="server" class="form-horizontal">
        <div class="page-container">

            <div class="main-content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-default">

                            <table border="1" style="height:30px;">
                                <tr>
                                    <td style="padding:5px;"><strong>用户ID</strong></td>
                                    <td style="padding:5px;"><%=user_code %></td>
                                    <td style="padding:5px;"><strong>姓名</strong></td>
                                    <td style="padding:5px;"><%=full_name %></td>
                                    <td style="padding:5px;"><strong>性别</strong></td>
                                    <td style="padding:5px;"><%=gender_title %></td>
                                    <td style="padding:5px;"><strong>省市</strong></td>
                                    <td style="padding:5px;"><%=province_name %></td>
                                    <td style="padding:5px;"><strong>单位</strong></td>
                                    <td style="padding:5px;"><%=unit_name %></td>
                                    <td style="padding:5px;"><strong>科室</strong></td>
                                    <td style="padding:5px;"><%=offices %></td>
                                </tr>
                            </table>

                            <div class="table-responsive" data-pattern="priority-columns" data-focus-btn-icon="fa-asterisk" data-sticky-table-header="false" data-add-display-all-btn="false" data-add-focus-btn="false">
                                
                                <table cellspacing="0" class="table table-small-font table-bordered table-striped">
                                    <thead>
                                        <tr>
                                            <th>订单号</th>
                                            <th>价格</th>
                                            <th>已收</th>
                                            <th>会议编码</th>
                                            <th>会议名称</th>
                                            <th>会议地址</th>
                                            <th>会议开始时间</th>
                                            <th>会议结束时间</th>
                                        </tr>
                                    </thead>
                                    <asp:Repeater ID="rpt_orders" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("order_id") %></td>
                                                <td><%#Eval("ying_shou").ToString() %></td>
                                                <td><%#Eval("yi_shou") %></td>
                                                <td><%#Eval("mid") %></td>
                                                <td><%#Eval("mname") %></td>
                                                <td><%#Eval("address") %></td>
                                                <td><%#DateTime.Parse(Eval("begindate").ToString()).ToString("yy年MM月dd日") %></td>
                                                <td><%#DateTime.Parse(Eval("enddate").ToString()).ToString("yy年MM月dd日") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
