<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_update_system.aspx.cs" Inherits="MpConsoleWebSite.home.system_manager.add_update_system" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理用户信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/admin_main.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js"  charset="gb2312"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script type="text/javascript">
    var sys_code = '<%=sys_code %>';
    $(document).ready(function(){
        if(sys_code != "")
        {
            LoadTable();
        }
    });
    //加载
    function LoadTable()
    {
        $('#system_data').html('');
        $.ajax({
            type:"post",
            url:'/AjaxResponse/tv_competenceHandler.ashx?type=3&postvalue='+sys_code,
            data:$("#form1").serialize(),
            success:function(data){
                $('#system_data').html(data);
            }
        });
    }
    //验证信息
    function CheckData()
    {
        var error = 0;
        if($("#sys_name").val().replace(/(^\s*)|(\s*$)/g,"") == "")
        {
            dialogTime('请输入管理员姓名！','');
            error += 1;
        }
        else if($("#system_level").val() == "9999")
        {
            dialogTime('请输入管理员级别！','');
            error += 1;
        }
        else if($("#login_id").val().replace(/(^\s*)|(\s*$)/g,"") == "")
        {
            dialogTime('请输入登录ID！','');
            error += 1;
        }
        else if($("#login_pwd").val().replace(/(^\s*)|(\s*$)/g,"") == "")
        {
            dialogTime('请输入登录密码！','');
            error += 1;
        }
        else if($("#sys_mobile").val().replace(/(^\s*)|(\s*$)/g,"") == "")
        {
            dialogTime('请输入管理员手机号码！','');
            error += 1;
        }
        else if($("#sys_mobile").val().replace(/(^\s*)|(\s*$)/g,"") != "" && $("#sys_mobile").val().match('^[1][0-9]{10}$') == null)
        {
            dialogTime('手机号码只能由11位数字组成！','');
            error += 1;
        }
        return parseInt(error);
    }
    //保存数据
    function SaveData()
    {
        if(CheckData() == 0)
        {
            if(sys_code != "")
            {
                $.ajax({
                    type:"post",
                    url:'/AjaxResponse/tv_competenceHandler.ashx?type=4&postvalue='+sys_code,
                    data:$("#form1").serialize(),
                    success:function(data){
                        if(data == "OK")
                        {
                            dialogTimeClose('操作成功！','',"yes");
                        }
                        else
                        {
                            dialogTime(''+data+'','');
                        }
                    }
                });
            }
            else
            {
                $.ajax({
                    type:"post",
                    url:'/AjaxResponse/tv_competenceHandler.ashx?type=5',
                    data:$("#form1").serialize(),
                    success:function(data){
                        if(data == "OK")
                        {
                            dialogTimeClose('操作成功！','',"yes");
                        }
                        else
                        {
                            dialogTime(''+data+'','');
                        }
                    }
                });
            }
        }
    }
    </script>
</head>
<body>
    <form id="form1">
        <input type="hidden" name="mid" value="<%=mid %>" />
        <div class="Content">
            <div class="listtable" id="system_data">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                    <tr>
                        <th scope="row">管理员姓名</th>
                        <td><input class="txt" id="sys_name" name="sys_name" type="text" /></td>
                    </tr>
                    <tr>
                        <th scope="row">级别名称</th>
                        <td>
                            <select id="system_level" name="system_level">
                                <option value="9999">请选择</option>
                                <option value="1">超级管理员</option>
                                <option value="2">普通管理员</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">登录ID</th>
                        <td><input class="txt" id="login_id" name="login_id" type="text" /></td>
                    </tr>
                    <tr>
                        <th scope="row">登录密码</th>
                        <td><input class="txt" id="login_pwd" name="login_pwd" type="password" /></td>
                    </tr>
                    <tr>
                        <th scope="row">手机号码</th>
                        <td><input class="txt" id="sys_mobile"  name="sys_mobile" maxlength="11" type="text" /></td>
                    </tr>
                    <tr>
                        <th scope="row"></th>
                        <td>
                            <input type="hidden" id="sys_code" name="sys_code" />
                            <a class="btnblue" href="javascript:void(0)" onclick="SaveData()">确定</a>
                        </td>
                    </tr>
                </table>
                <div class="h10"></div>
            </div>
        </div>
    </form>
</body>
</html>