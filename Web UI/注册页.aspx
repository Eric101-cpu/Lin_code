<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="注册页.aspx.cs" Inherits="注册页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" href="App_Themes/前台样式/UserRegisterStyleSheet.css" type="text/css" />
    <div class="register-title">
        用户注册
        <asp:Label ID="lbInfo" runat="server"  CssClass="msg"></asp:Label>
    </div>
    <div class="reg-label">用户ID</div>
    <asp:TextBox ID="txtID" CssClass="reg-input" Text="自动编号" Enabled="false" runat="server"></asp:TextBox>

    <div class="reg-label">用户名</div>
    <asp:TextBox ID="txtUserName" CssClass="reg-input"  runat="server"></asp:TextBox>   

    <div class="reg-label">密码</div>
    <asp:TextBox ID="txtPwd" TextMode="Password" CssClass="reg-input"  runat="server"></asp:TextBox>

    <div class="reg-label">确认密码</div>
    <asp:TextBox ID="txtConfirmPwd" TextMode="Password" CssClass="reg-input"  runat="server"></asp:TextBox>

    <div style="text-align:center;margin-top:20px;">
        <asp:Button ID="btnBack" runat="server" Text="返回"  CssClass="reg-btn" CausesValidation="false" PostBackUrl="~/主页面.aspx"/>
        <asp:Button ID="btnRegister" runat="server" Text="注册" CssClass="reg-btn" OnClick="btnRegister_Click" />
    </div>

</asp:Content>

